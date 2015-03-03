using System;

namespace WS.Accounts.Import
{
    public interface IPaidRow
    {
        DateTime Date { get; }

        string Reference { get; }

        string Details { get; }

        decimal? CurrentAccount { get; }

        decimal? SavingsAccount { get; }

        decimal? CompanyCreditCard { get; }

        decimal? PaidByOrToTheDirector { get; }

        decimal? VatWithin { get; }

        decimal? SubcontractorCost { get; }

        decimal? Mileage { get; }

        decimal? OtherTravel { get; }

        decimal? EntertainingCost { get; }

        decimal? TelephoneCharges { get; }

        decimal? OfficeExpenses { get; }

        decimal? BankCharges { get; }

        decimal? Insurance { get; }

        decimal? ComputerExpenses { get; }

        decimal? SundryExpenses { get; }

        decimal? AccountancyFees { get; }

        decimal? Payroll { get; }

        decimal? CompanyPension { get; }

        decimal? Dividend { get; }

        decimal? VatPayment { get; }

        decimal? Other { get; }
    }
}