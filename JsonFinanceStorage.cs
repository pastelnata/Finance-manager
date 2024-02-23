using System.Text.Json;
using Newtonsoft.Json;

namespace Finance
{
    interface IFinanceStorage
    {
        abstract void SaveTransactionData(Transaction transaction);
        abstract List<Transaction> LoadTransactionData();
    }
    class JsonFinanceStorage : IFinanceStorage
    {

        List<Transaction> transactions = FinanceTracker.transactions;
        public void SaveTransactionData(Transaction transaction)
        {
            // Create a new transaction object
            var newTransaction = new Transaction(
                transaction.Description,
                transaction.Amount,
                transaction.Category
            );

            transactions.Add(newTransaction);

            // Serialize the entire list of transactions
            string jsonTransactions = JsonConvert.SerializeObject(transactions, Formatting.Indented);

            // Write the serialized JSON array to the file
            File.WriteAllText("transactions.json", jsonTransactions);
        }

        public List<Transaction> LoadTransactionData()
        {
            try
            {
                string transactionsJson = File.ReadAllText("transactions.json");
                var loadedTransactions = JsonConvert.DeserializeObject<List<Transaction>>(transactionsJson);
                if (loadedTransactions != null)
                {
                    transactions = loadedTransactions;
                    return transactions;
                }
                return new List<Transaction>();
            }
            catch (Exception)
            {
                Console.WriteLine("Error deserializing JSON file.");
                throw;
            }
        }
    }
}
