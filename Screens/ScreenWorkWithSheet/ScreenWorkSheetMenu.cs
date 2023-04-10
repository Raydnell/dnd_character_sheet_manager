namespace dnd_character_sheet
{
    public class ScreenWorkSheetMenu : IScreen
    {
        private bool _isPointChoose;
        private IScreen _screen;
        private IUserInput _userInput;
        private IUserOutput _userOutput;

        public ScreenWorkSheetMenu()
        {
            _userInput = new ConsoleInput();
            _userOutput = new ConsoleOutput();
        }
        
        public void ShowScreen(ref CharacterSheetBase heroSheet)
        {
            _userOutput.Clear();
            _userOutput.Print("Меню: \n");
            _userOutput.Print("");
        }
    }
}