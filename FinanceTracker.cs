using System.Collections.Generic;
using System.Text.Json;
using System.Transactions;
using System;

namespace Finance
{
    interface IFinance
    {
        abstract void AddTransaction(string description, decimal amount, string category);
        abstract void ViewTransactions();
        abstract void CategorizeTransaction();
        abstract void Summary();
    }
    class FinanceTracker : IFinance
    {
        //list of transactions
        public static List<Transaction> transactions = new List <Transaction> ();
        public JsonFinanceStorage JsonStorage = new JsonFinanceStorage();

        private decimal income;
        private decimal expenses;
        public decimal income_
        {
            get {return income;}
            set {income = value;}
        }
        public decimal expenses_
        {
            get {return expenses;}
            set {expenses = value;}
        }


        public void AddTransaction(string description, decimal amount, string category)
        {
            // creates a new transaction
            Transaction newTransaction = new Transaction(description, amount, category);
            Console.WriteLine($"New Transaction: Description: {newTransaction.Description}, Amount: {newTransaction.Amount}, Category: {newTransaction.Category}");
            // saves transaction to 
            JsonStorage.SaveTransactionData(newTransaction);
        }

        public void ViewTransactions()
        {
            foreach (var transaction in transactions)
            {
                Console.WriteLine($"Category: {transaction.Category}");
                Console.WriteLine($"Description: {transaction.Description}");
                Console.WriteLine($"Amount: {transaction.Amount}");
                Console.WriteLine($"Date: {transaction.Date}");
                Console.WriteLine($"Transaction ID: {transaction.ID}");
                Console.WriteLine("");
            }
        }

        public void CategorizeTransaction()
        {
            //group transactions with the same category
            var transactionsByCategory = transactions.GroupBy(pair => pair.Category);
            //for each group
            foreach (var groupOfTransactions in transactionsByCategory)
            {
                // get the current category
                string category = groupOfTransactions.Key;
                // make a list of the group of the current category
                List<Transaction> transactionsInCategory = groupOfTransactions.ToList();

                Console.WriteLine("");
                Console.WriteLine("_______________________________");
                Console.WriteLine($"Category: {category}");
                Console.WriteLine("");
                foreach (var transaction in transactionsInCategory)
                {
                    Console.WriteLine($"Description: {transaction.Description}");
                    Console.WriteLine($"Amount: {transaction.Amount}");
                    Console.WriteLine($"Date: {transaction.Date}");
                    Console.WriteLine($"Transaction ID: {transaction.ID}");
                    Console.WriteLine("");
                }
            }
        }

        public void Summary()
        {
            foreach (var transaction in transactions)
            {
                if (transaction.Amount > 0)
                {
                    income += transaction.Amount;
                }
                else
                {
                    expenses -= transaction.Amount;
                }
            }
        }
    }
}