namespace dnd_character_sheet
{
    internal class ScreenMain
    {
        private bool _isSheetLoaded;
        private int _choosenPoint;

        private CheckInput _checkInput;
        private CharacterSheetBase? _currentHeroSheet;
        private ScreenLoadSheet _loadingScreen;
        private ScreenRollDice _screenRollDice;
        private ScreenSheetCreate _screenSheetCreate;
        private ScreenWorkWithSheet _screenWorkWithSheet;
        private JsonSaveLoad _jsonSaveLoad;
        private IUserOutput _userOutput;

        public ScreenMain()
        {
            _checkInput = new CheckInput();
            _loadingScreen = new ScreenLoadSheet();
            _screenRollDice = new ScreenRollDice();
            _screenSheetCreate = new ScreenSheetCreate();
            _screenWorkWithSheet = new ScreenWorkWithSheet();
            _jsonSaveLoad = new JsonSaveLoad();
            _userOutput = new ConsoleOutput();
        }
        
        public void ShowMainScreen()
        {
            while (true)
            {
                _userOutput.Clear();
                _userOutput.Print("\nМеню:");
                _userOutput.Print("1. Создание листа");
                _userOutput.Print("2. Загрузить лист");
                _userOutput.Print("3. Вывести информацию о текущем листе персонажа");
                _userOutput.Print("Добро пожаловать в программу создания листов персонажей!");
                _userOutput.Print("4. Свободные броски кубика");
                _userOutput.Print("5. Работа с листом");
                _userOutput.Print("6. Сохранить текущий лист");
                _userOutput.Print("10. Выход");
                _userOutput.Print("\nВведите число, для перехода по меню: ", false);

                _choosenPoint = _checkInput.CheckIntInput();
                switch (_choosenPoint)
                {
                    case 0:
                    default:
                        _userOutput.Print("Введено неверное число, нужно ввести число из списка.");
                        Console.ReadKey();
                        break;

                    case 1:
                        _currentHeroSheet = _screenSheetCreate.SheetCreate(_currentHeroSheet);
                        _isSheetLoaded = true;
                        break;

                    case 2:
                        _currentHeroSheet = _loadingScreen.LoadSheetFromFile();
                        _isSheetLoaded = true;
                        break;

                    case 3:
                        if (_isSheetLoaded == true)
                        {
                            _userOutput.Clear();
                            _userOutput.Print("Экран информации о текущем листе персонажа.\n");
                        }
                        else
                        {
                            _userOutput.Clear();
                            _userOutput.Print("Сначала нужно создать или загрузить лист персонажа.");
                            Console.ReadKey();
                        }
                        break;

                    case 4:
                        _screenRollDice.RollDice();
                        break;

                    case 5:
                        if (_isSheetLoaded == true)
                        {
                            _screenWorkWithSheet.ChooseSheetRolls(_currentHeroSheet);
                        }
                        else
                        {
                            _userOutput.Clear();
                            _userOutput.Print("Сначала нужно создать или загрузить лист персонажа.");
                            Console.ReadKey();
                        }
                        break;

                    case 6:
                        if (_isSheetLoaded == true)
                        {
                            //_jsonSaveLoad.JsonSave(_currentHeroSheet.GetName(), _currentHeroSheet);
                        }
                        else
                        {
                            _userOutput.Clear();
                            _userOutput.Print("Сначала нужно создать или загрузить лист персонажа.");
                            Console.ReadKey();
                        }
                        break;

                    case 10:
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }
}
