namespace dnd_character_sheet
{
    public class ScreenWorkSheetMenu : IScreen
    {
        private bool _isPointChoose;
        private IScreen _screen;
        private IUserInput _userInput;
        private IUserOutput _userOutput;
        private int _intInput;

        public ScreenWorkSheetMenu()
        {
            _userInput = new ConsoleInput();
            _userOutput = new ConsoleOutput();
        }

        public void ShowScreen(ref CharacterSheetBase heroSheet)
        {
            while (_isPointChoose == false)
            {
                _userOutput.Clear();
                _userOutput.Print("Меню: \n");
                _userOutput.Print("1. Редактирование полей листа");
                _userOutput.Print("2. Броски кубов по листу");
                _userOutput.Print("3. Взаимодействие с инвентарём");
                _userOutput.Print("4. Подготовка заклинаний");
                _userOutput.Print("10. Вернуться в меню");

                _intInput = _userInput.InputInt();

                switch(_intInput)
                {
                    default:
                    case 0:
                        _userOutput.Clear();
                        _userOutput.Print("Выбрано неверное значение, повторить попытку или вернуться в меню?");
                        _userOutput.Print("1. Вернуться в меню");
                        _userOutput.Print("2. Повторить попытку");

                        _intInput = _userInput.InputInt();
                        if (_intInput == 1)
                        {
                            _isPointChoose = true;
                            break;
                        }

                        break;

                    case 1:
                        _screen = new ScreenWorkWithFields();
                        _screen.ShowScreen(ref heroSheet);
                        _isPointChoose = true;
                        break;

                    case 2:
                        _screen = new ScreenBasicSheetThrows();
                        _screen.ShowScreen(ref heroSheet);
                        _isPointChoose = true;
                        break;

                    case 10:
                        _isPointChoose = true;
                        break;
                }
            }
        }
    }
}