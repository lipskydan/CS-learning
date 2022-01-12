namespace SeleniumTasks
{
    static class MessageToConsole
    {
        public static void RedMessage(string message)
        {
            System.Console.ForegroundColor = System.ConsoleColor.Red;
            System.Console.WriteLine(message);
            System.Console.ForegroundColor = System.ConsoleColor.White;
        }

        public static void GreenMessage(string message)
        {
            System.Console.ForegroundColor = System.ConsoleColor.Green;
            System.Console.WriteLine(message);
            System.Console.ForegroundColor = System.ConsoleColor.White;
        }
    }
}