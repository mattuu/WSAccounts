using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WS.Accounts.Entities;

namespace WS.Accounts.Import
{
    public class SpreadsheetTransactionReader : ITransactionReader
    {
        private ICollection<Account> _accounts;
        private IEnumerable<Transaction> _transactions;

        public void Import(Stream inputStream)
        {
            // Getting the complete workbook... 
            var workbook = new HSSFWorkbook(inputStream);

            ReadTransactionsFromPaidSheet(workbook);
            
        }

        public IEnumerable<Account> GetAccounts()
        {
            return _accounts;
        }

        public IEnumerable<Transaction> GetTransactions()
        {
            return _transactions;
        }

        public int GetProgress()
        {
            throw new NotImplementedException();
        }

        private void ReadAccountsFromPaid(ISheet sheet)
        {
            const int rowIndex = 9;
            const int colIndex = 3;
            var factory = new AccountFactory();

            var cells = sheet.GetRow(rowIndex).Cells;

            var index = colIndex;
            while (cells[index] != null)
            {
                var name = cells[index].StringCellValue;
                _accounts.Add(factory.Create(name));
            }
        }

        private void ReadTransactionsFromPaidSheet(IWorkbook workbook)
        {
            var sheet = workbook.GetSheet(SheetNames.Paid);
            ReadAccountsFromPaid(sheet);

            for (int i = 0; i <= sheet.LastRowNum; i++)
            {
                var row = sheet.GetRow(i);
                if (row != null) //null is when the row only contains empty cells 
                {
                    var paidRow = PaidRow.Create(row);                    
                }
            }
        }

        public void ReadTransactionsFromReceivedSheet(ISheet receivedSheet)
        {
            
        }

        //private void ReadSpreadsheet(Stream inputStream)
        //{
        //    var bw = new BackgroundWorker();

        //    bw.RunWorkerAsync(
        //}

    }

    public abstract class SheetTransactionReader
    {
        private readonly IWorkbook _workbook;
        private readonly string _sheetName;

        protected SheetTransactionReader(IWorkbook workbook, string sheetName)
        {
            if (workbook == null) throw new ArgumentNullException("workbook");
            if (sheetName == null) throw new ArgumentNullException("sheetName");
            _workbook = workbook;
            _sheetName = sheetName;
        }

        private ISheet GetSheet()
        {
            return _workbook.GetSheet(_sheetName);
        }

        public void Read()
        {
            var sheet = GetSheet();

            for (var i = 0; i <= sheet.LastRowNum; i++)
            {
                var row = sheet.GetRow(i);
                if (row != null) //null is when the row only contains empty cells 
                {
                    var paidRow = PaidRow.Create(row);
                }
            }
        }
    }

    public class ReceivedSheetTransactionReader : SheetTransactionReader
    {
        
    }

    public class PaidSheetTransactionReader : SheetTransactionReader
    {
        
    }
}
