using Finance;

namespace FinanceProgram
{
    class Program
    {
        static void Main()
        {
            FinanceTracker FinanceTracker1 = new FinanceTracker
            {
                income_ = 0,
                expenses_ = 0
            };

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
                    FinanceTracker1.ViewTransactions();
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

                FinanceTracker1.AddTransaction(description, amount, category);
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
                    FinanceTracker1.CategorizeTransaction();
                }
            }

            void FinancialSummariesHandler()
            {
                FinanceTracker1.Summary();
                Console.WriteLine($"Total Income: {FinanceTracker1.income_}");
                Console.WriteLine($"Total Expenses: {FinanceTracker1.expenses_}");
                Console.WriteLine($"Total Balance:{FinanceTracker1.income_ - FinanceTracker1.expenses_} ");
            }


            /*------------------------------------------------------------------------------
                UTIL - To b«avoid code repetition
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
