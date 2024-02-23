using Finance;

namespace FinanceProgram
{
    class Program
    {
        static void Main()
        {
            List<Transaction> transactions = new List <Transaction> ();

            FinanceTracker financeTracker = new FinanceTracker();
            
            if (File.Exists("transactions.json"))
            {
                financeTracker.JsonStorage.LoadTransactionData();

            }
            else
            {
                File.WriteAllText("transactions.json", string.Empty);
                financeTracker.income_ = 0;
                financeTracker.expenses_ = 0; 
            }

            bool applicationRunning = true;

            while (applicationRunning)
            {
                Console.WriteLine("Select an option:");
                Console.WriteLine("1. Add transaction.");
                Console.WriteLine("2. View transaction history.");
                Console.WriteLine("3. View financial summaries.");
                Console.WriteLine("4. Exit");
                Console.Write("> ");
                string? userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":   
                    // ADD TRANSACTION
                    Console.WriteLine("");
                    AddTransactionHandler();
                    break;

                    case "2":
                    // VIEW TRANSACTIONS
                    Console.WriteLine("");
                    financeTracker.ViewTransactions();
                    ViewTransactionHandler();
                    break;

                    case "3":
                    // SEE FINANCIAL SUMMARIES
                    Console.WriteLine("");
                    FinancialSummariesHandler();
                    break;

                    case "4":
                    applicationRunning = false;
                    break;

                    default:
                    Console.WriteLine("Please select an option.");
                    break;
                }
            }


            /*---------------------------------------------------------------------------
                Handles user commands
            ----------------------------------------------------------------------------*/


            void AddTransactionHandler()
            {
                Console.Write("Category: ");
                string? category = Console.ReadLine();
                category = InputValidation(category, "a category");

                Console.Write("Description: ");
                string? description = Console.ReadLine();
                description = InputValidation(description, "a description");
                
                Console.Write("Amount: ");
                decimal amount;
                while (!decimal.TryParse(Console.ReadLine(), out amount))
                {
                    Console.Write("Please enter a decimal: ");
                }

                financeTracker.AddTransaction(description, amount, category);
                Console.WriteLine("Transaction added successfully.");
                Console.WriteLine("");
            }

            void ViewTransactionHandler()
            {
                Console.WriteLine("Type 'C' to view transactions by category.");
                Console.WriteLine("Type 'B' to go back.");
                Console.Write("> ");
                string? userInput = Console.ReadLine();
                InputValidation(userInput, "an option");

                if (userInput == "B")
                {
                    return;
                }
                else
                {
                    financeTracker.CategorizeTransaction();
                }
            }

            void FinancialSummariesHandler()
            {
                financeTracker.Summary();
                Console.WriteLine("");
                Console.WriteLine($"Total Income: {financeTracker.income_}");
                Console.WriteLine($"Total Expenses: {financeTracker.expenses_}");
                Console.WriteLine($"Total Balance:{financeTracker.income_ - financeTracker.expenses_} ");
                Console.WriteLine("");
            }


            /*------------------------------------------------------------------------------
                UTIL - To avoid code repetition
            -------------------------------------------------------------------------------*/


            static string InputValidation(string? userInput, string option)
            {
                while (string.IsNullOrEmpty(userInput))
                {
                    Console.Write($"Invalid Input. Please enter {option}: ");
                    userInput = Console.ReadLine();
                }
                return userInput;
            }   
        }
    }
}
