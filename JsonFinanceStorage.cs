using System.Text.Json;

namespace FinanceStorage
{
    public interface IFinanceStorage
    {
        void SaveTransactionData();
        void LoadTransactionData();
    }
    class JsonFinanceStorage : IFinanceStorage
    {
        public void SaveTransactionData()
        {
            // string transactionsJson = JsonSerializer.Serialize(transactions);
        }

        public void LoadTransactionData()
        {
            //deserialization
        }
    }
}
