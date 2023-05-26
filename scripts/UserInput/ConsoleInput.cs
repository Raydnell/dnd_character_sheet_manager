namespace dnd_character_sheet
{
    public class ConsoleInput
    {
        public static int InputInt()
        {
            string consoleInput = Console.ReadLine();
            if (int.TryParse(consoleInput, out int inputInt))
            {
                return inputInt;
            }
            else
            {
                return 0;
            }
        }
    }
}
