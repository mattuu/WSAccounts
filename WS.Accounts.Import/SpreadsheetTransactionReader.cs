using System.Collections.ObjectModel;
using NPOI.HSSF.UserModel;
using NPOI.SS.Formula;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.IO;

namespace WS.Accounts.Import
{
    public class SpreadsheetTransactionReader : ITransactionReader
    {
        private readonly ICollection<ISheetTransactionReader> _transactionReaders;
        private readonly HSSFWorkbook _workbook;

        public SpreadsheetTransactionReader(Stream inputStream)
        {
            _transactionReaders = new Collection<ISheetTransactionReader>();

            _workbook = new HSSFWorkbook(inputStream);
        }

        public void AddTransactionReader(ISheetTransactionReader reader)
        {
            reader.SetWorkbook(_workbook);
            _transactionReaders.Add(reader);
        }

        public void Import()
        {
            // Getting the complete workbook... 
            foreach (var transactionReader in _transactionReaders)
            {
                transactionReader.Read();
            }
        }

        public int GetProgress()
        {
            throw new NotImplementedException();
        }
    }

    public interface ISheetTransactionReader
    {
        void Read();

        void SetWorkbook(IWorkbook workbook);
    }

    public abstract class SheetTransactionReader : ISheetTransactionReader
    {
        private IWorkbook _workbook;
        private readonly string _sheetName;

        protected SheetTransactionReader(string sheetName)
        {
            if (sheetName == null) throw new ArgumentNullException("sheetName");
            _sheetName = sheetName;
        }

        internal ISheet GetSheet()
        {
            if (_workbook == null)
            {
                throw new WorkbookNotFoundException("Workbook not found!");
            }
            
            return _workbook.GetSheet(_sheetName);
        }

        public void SetWorkbook(IWorkbook workbook)
        {
            if (workbook == null) throw new ArgumentNullException("workbook");
            _workbook = workbook;
        }

        public abstract void Read();
    }

    public class ReceivedSheetTransactionReader : SheetTransactionReader
    {
        public ReceivedSheetTransactionReader() 
            : base("Received")
        {
        }

        public override void Read()
        {
            throw new NotImplementedException();
        }
    }

    public class PaidSheetTransactionReader : SheetTransactionReader
    {
        private readonly IAccountFactory<IPaidRow> _accountFactory;

        public PaidSheetTransactionReader(IAccountFactory<IPaidRow> accountFactory) 
            : base("Paid")
        {
            if (accountFactory == null) throw new ArgumentNullException("accountFactory");
            _accountFactory = accountFactory;
        }

        public override void Read()
        {
            var sheet = GetSheet();
            var rows = new List<IPaidRow>();
            for (var i = 0; i <= sheet.LastRowNum; i++)
            {
                var row = sheet.GetRow(i);
                if (row != null) //null is when the row only contains empty cells 
                {
                    rows.Add(PaidRow.Create(row));
                }
            }

            foreach (var paidRow in rows)
            {
                _accountFactory.Create(paidRow);
            }
        }
    }

    public interface ITransactionCollection : ICollection<ITransaction>
    {
        
    }

    public interface ITransaction
    {
        
    }
}
