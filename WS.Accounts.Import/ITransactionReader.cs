namespace WS.Accounts.Import
{
    public interface ITransactionReader
    {
        void Import();

        int GetProgress();
    }
}