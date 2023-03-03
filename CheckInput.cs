namespace dnd_character_sheet
{
    public class CheckInput
    {     
        private string? _consoleInput;
        
        public int CheckIntInput()
        {
            _consoleInput = Console.ReadLine();

            if (int.TryParse(_consoleInput, out int inputInt))
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