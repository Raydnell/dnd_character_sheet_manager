using System;

namespace dnd_character_sheet
{
    public class CheckInput
    {     
        public int CheckIntInput()
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
