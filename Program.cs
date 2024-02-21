namespace FinanceManager
{
    class Program
    {
        static void Main()
        {
            bool applicationRunning = true;

            while (applicationRunning)
            {
                Console.WriteLine("Select an option:");
                Console.WriteLine("1. Add transaction");
                Console.WriteLine("2. View transaction history");
                Console.WriteLine("3. View financial summaries based on category");
                Console.WriteLine("4. Exit");

                string? userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                    // ADD TRANSACTION
                    break;

                    case "2":
                    // VIEW TRANSACTION HISTORY
                    break;

                    case "3":
                    // SEE FINANCIAL SUMMARIES BASED ON CATEGORIES
                    break;

                    case "4":
                    applicationRunning = false;
                    break;

                    default:
                    break;
                }
            }   
        }
    }
}
