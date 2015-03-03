using System;
using System.IO;
using NPOI.SS.UserModel;

namespace WS.Accounts.Import
{
    public class PaidRow : IPaidRow
    {
        private PaidRow(IRow rowData)
        {
            // assumes first column is date and determines if row 
            // is transaction - any other row will be ignored..
            try
            {
                Date = rowData.Cells[0].DateCellValue;
                Reference = rowData.Cells[1].StringCellValue;
                Details = rowData.Cells[2].StringCellValue;
                CurrentAccount = GetDecimalValue(rowData.Cells[3]);
                SavingsAccount = GetDecimalValue(rowData.Cells[4]);
                CompanyCreditCard = GetDecimalValue(rowData.Cells[5]);
                PaidByOrToTheDirector = GetDecimalValue(rowData.Cells[6]);
                VatWithin = GetDecimalValue(rowData.Cells[7]);
                SubcontractorCost = GetDecimalValue(rowData.Cells[8]);
                Mileage = GetDecimalValue(rowData.Cells[9]);
                OtherTravel = GetDecimalValue(rowData.Cells[10]);
                EntertainingCost = GetDecimalValue(rowData.Cells[11]);
                TelephoneCharges = GetDecimalValue(rowData.Cells[12]);
                OfficeExpenses = GetDecimalValue(rowData.Cells[13]);
                BankCharges = GetDecimalValue(rowData.Cells[14]);
                Insurance = GetDecimalValue(rowData.Cells[15]);
                ComputerExpenses = GetDecimalValue(rowData.Cells[16]);
                SundryExpenses = GetDecimalValue(rowData.Cells[17]);
                AccountancyFees = GetDecimalValue(rowData.Cells[18]);
                Payroll = GetDecimalValue(rowData.Cells[19]);
                CompanyPension = GetDecimalValue(rowData.Cells[20]);
                Dividend = GetDecimalValue(rowData.Cells[21]);
                VatPayment = GetDecimalValue(rowData.Cells[22]);
                Other = GetDecimalValue(rowData.Cells[23]);
            }
            catch (InvalidOperationException)
            {
            }
            catch (InvalidDataException)
            {
            }
            catch (ArgumentOutOfRangeException)
            {
            }
        }

        public DateTime Date { get; private set; }

        public string Reference { get; private set; }

        public string Details { get; private set; }

        public decimal? CurrentAccount { get; private set; }

        public decimal? SavingsAccount { get; private set; }

        public decimal? CompanyCreditCard { get; private set; }

        public decimal? PaidByOrToTheDirector { get; private set; }

        public decimal? VatWithin { get; private set; }

        public decimal? SubcontractorCost { get; private set; }

        public decimal? Mileage { get; private set; }

        public decimal? OtherTravel { get; private set; }

        public decimal? EntertainingCost { get; private set; }

        public decimal? TelephoneCharges { get; private set; }

        public decimal? OfficeExpenses { get; private set; }

        public decimal? BankCharges { get; private set; }

        public decimal? Insurance { get; private set; }

        public decimal? ComputerExpenses { get; private set; }

        public decimal? SundryExpenses { get; private set; }

        public decimal? AccountancyFees { get; private set; }

        public decimal? Payroll { get; private set; }

        public decimal? CompanyPension { get; private set; }

        public decimal? Dividend { get; private set; }

        public decimal? VatPayment { get; private set; }

        public decimal? Other { get; private set; }

        public static IPaidRow Create(IRow data)
        {
            return new PaidRow(data);
        }

        private decimal? GetDecimalValue(ICell cell)
        {
            return Convert.ToDecimal(cell.NumericCellValue);
        }
    }
}