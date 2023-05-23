namespace dnd_character_sheet
{
    public class PrintTable
    {
        private static string _strokeTypeOne = "                   |                   |";
        private static string _strokeTypeTwo = "-------------------+-------------------+------------------";

        public PrintTable()
        {
            
        }

        public static void PrintMainTable()
        {
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            Console.WriteLine(_strokeTypeOne);
            Console.WriteLine(_strokeTypeTwo);
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(_strokeTypeOne);
            }
            Console.WriteLine(_strokeTypeTwo);
            Console.WriteLine(_strokeTypeOne);
            Console.WriteLine(_strokeTypeTwo);
        }
    }
}