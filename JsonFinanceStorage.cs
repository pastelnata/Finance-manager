using System.Text.Json;
using FinanceProgram;
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
        public void SaveTransactionData(Transaction transaction)
        {
            // Create a new transaction object
            var newTransaction = new Transaction(
                transaction.GetDescription,
                transaction.GetAmount,
                transaction.GetCategory
            );

            Program.transactions.Add(newTransaction);

            // Serialize the entire list of transactions
            string jsonTransactions = JsonConvert.SerializeObject(Program.transactions, Formatting.Indented);

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
                    return loadedTransactions; 
                }
                return loadedTransactions = new List<Transaction>();
            }
            catch (Exception)
            {
                Console.WriteLine("Error deserializing JSON file.");
                throw;
            }
        }
    }
}
