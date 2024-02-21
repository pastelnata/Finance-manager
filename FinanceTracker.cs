using System.Collections.Generic;
using System.Text.Json;
using System.Transactions;

namespace FinanceTracker
{
    public interface IFinance
    {
        void AddTransaction();
        void ViewTransactions();
        void CategorizeTransaction();
        void Summary();

    }
    class FinanceTracker : IFinance
    {
        //list of transactions
        public List<Transaction> transactions = new List <Transaction> ();

        public void AddTransaction()
        {
            Console.Write("Description: ");
            string? description = Console.ReadLine();

            Console.Write("Amount: ");
            decimal amount;
            while (!decimal.TryParse(Console.ReadLine(), out amount))
            {
                Console.Write("Please enter a decimal: ");
            }

            Console.Write("Category: ");
            string? category = Console.ReadLine();
        }

        public void ViewTransactions()
        {

        }

        public void CategorizeTransaction()
        {

        }

        public void Summary()
        {

        }
    }
}