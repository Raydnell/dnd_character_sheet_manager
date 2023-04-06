namespace dnd_character_sheet
{
    public class ScreenMain : IScreen
    {
        private bool _isSheetLoaded;
        private bool _isPointChoose;

        private int _choosenPoint;

        private JsonSaveLoad _jsonSaveLoad;
        private IUserOutput _userOutput;
        private IUserInput _userInput;
        private PrintSheetInfo _printSheetInfo;
        private IScreen _screen;

        public ScreenMain()
        {
            _jsonSaveLoad = new JsonSaveLoad();
            _userOutput = new ConsoleOutput();
            _userInput = new ConsoleInput();
            _printSheetInfo = new PrintSheetInfo();
        }
        
        public void ShowScreen(CharacterSheetBase heroSheet)
        {
            _isPointChoose = false;
            while(_isPointChoose == false)
            {
                _userOutput.Clear();
                _userOutput.Print("\nМеню:");
                _userOutput.Print("1. Создание листа");
                _userOutput.Print("2. Загрузить лист");
                _userOutput.Print("3. Вывести информацию о текущем листе персонажа");
                _userOutput.Print("4. Свободные броски кубика");
                _userOutput.Print("5. Работа с листом");
                _userOutput.Print("6. Сохранить текущий лист");
                _userOutput.Print("10. Выход");
                _userOutput.Print("\nВведите число, для перехода по меню: ", false);

                _choosenPoint = _userInput.InputInt();
                switch(_choosenPoint)
                {
                    case 1:
                        _screen = new ScreenSheetCreate();
                        _screen.ShowScreen(heroSheet);
                        _isSheetLoaded = true;
                        break;

                    case 2:
                        _screen = new ScreenLoadSheet();
                        _screen.ShowScreen(heroSheet);
                        _isSheetLoaded = true;
                        break;

                    case 3:
                        if(_isSheetLoaded == true)
                        {
                            _userOutput.Clear();
                            _printSheetInfo.ShowSheetFields(heroSheet);
                            _userInput.InputKey();
                        }
                        else
                        {
                            PrintListNotLoaded();
                        }
                        break;

                    case 4:
                        _screen = new ScreenRollDice();
                        _screen.ShowScreen(heroSheet);
                        break;

                    case 5:
                        if(_isSheetLoaded == true)
                        {
                            _screen = new ScreenWorkWithSheet();
                            _screen.ShowScreen(heroSheet);
                        }
                        else
                        {
                            PrintListNotLoaded();
                        }
                        break;

                    case 6:
                        if(_isSheetLoaded == true)
                        {
                            _jsonSaveLoad.JsonSave(heroSheet.Name, heroSheet, @"Character_Sheets\" + heroSheet.Edition + @"\");
                        }
                        else
                        {
                            PrintListNotLoaded();
                        }
                        break;

                    case 10:
                        Environment.Exit(0);
                        break;

                    default:
                        PrintListNotLoaded();
                        break;
                }
            }
        }

        private void PrintListNotLoaded()
        {
            _userOutput.Clear();
            _userOutput.Print("Сначала нужно создать или загрузить лист персонажа.");
            _userInput.InputKey();
        }
    }
}
