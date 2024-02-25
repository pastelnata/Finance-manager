using System.Collections.Generic;
using System.Text.Json;
using System.Transactions;
using System;
using FinanceProgram;

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
            Console.WriteLine($"New Transaction: Description: {newTransaction.GetDescription}, Amount: {newTransaction.GetAmount}, Category: {newTransaction.GetCategory}");
            // saves transaction to 
            Program.JsonStorage.SaveTransactionData(newTransaction);
        }

        public void ViewTransactions()
        {
            foreach (var transaction in Program.transactions)
            {
                Console.WriteLine($"Category: {transaction.GetCategory}");
                Console.WriteLine($"Description: {transaction.GetDescription}");
                Console.WriteLine($"Amount: {transaction.GetAmount}");
                Console.WriteLine($"Date: {transaction.GetDate}");
                Console.WriteLine($"Transaction ID: {transaction.GetID}");
                Console.WriteLine("");
            }
        }

        public void CategorizeTransaction()
        {
            //group transactions with the same category
            var transactionsByCategory = Program.transactions.GroupBy(pair => pair.GetCategory);
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
                Console.WriteLine("_______________________________");
                Console.WriteLine("");
                foreach (var transaction in transactionsInCategory)
                {
                    Console.WriteLine($"Description: {transaction.GetDescription}");
                    Console.WriteLine($"Amount: {transaction.GetAmount}");
                    Console.WriteLine($"Date: {transaction.GetDate}");
                    Console.WriteLine($"Transaction ID: {transaction.GetID}");
                    Console.WriteLine("");
                }
            }
        }

        public void Summary()
        {
            foreach (var transaction in Program.transactions)
            {
                if (transaction.GetAmount > 0)
                {
                    income += transaction.GetAmount;
                }
                else
                {
                    expenses -= transaction.GetAmount;
                }
            }
        }
    }
}