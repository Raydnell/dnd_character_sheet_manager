using System;

namespace dnd_character_sheet
{
    internal class ScreenMain
    {
        private bool _isSheetLoaded;

        private CheckInput _checkInput;
        private CharacterSheetDnd5E _currentHeroSheet;
        private ScreenLoadSheet _loadingScreen;
        private ScreenRollDice _screenRollDice;
        private ScreenSheetCreate _screenSheetCreate;
        private ScreenWorkWithSheet _screenWorkWithSheet;
        private JsonSaveLoad _jsonSaveLoad;

        public ScreenMain()
        {
            _isSheetLoaded = false;
            
            _checkInput = new CheckInput();
            _currentHeroSheet = new CharacterSheetDnd5E();
            _loadingScreen = new ScreenLoadSheet();
            _screenRollDice = new ScreenRollDice();
            _screenSheetCreate = new ScreenSheetCreate();
            _screenWorkWithSheet = new ScreenWorkWithSheet();
            _jsonSaveLoad = new JsonSaveLoad();
        }
        
        public void ShowMainScreen()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Добро пожаловать в программу создания листов персонажей!");
                Console.WriteLine("\nМеню:");
                Console.WriteLine("1. Создание листа");
                Console.WriteLine("2. Загрузить лист");
                Console.WriteLine("3. Вывести информацию о текущем листе персонажа");
                Console.WriteLine("4. Свободные броски кубика");
                Console.WriteLine("5. Работа с листом");
                Console.WriteLine("6. Сохранить текущий лист");
                Console.WriteLine("10. Выход");
                Console.Write("\nВведите число, для перехода по меню: ");

                int _choosenPoint = _checkInput.CheckIntInput();
                switch (_choosenPoint)
                {
                    case 0:
                    default:
                        Console.WriteLine("Введено неверное число, нужно ввести число из списка.");
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
                            Console.Clear();
                            Console.WriteLine("Экран информации о текущем листе персонажа.\n");
                            _currentHeroSheet.PrintSheetInfoAll();
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Сначала нужно создать или загрузить лист персонажа.");
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
                            Console.Clear();
                            Console.WriteLine("Сначала нужно создать или загрузить лист персонажа.");
                            Console.ReadKey();
                        }
                        break;

                    case 6:
                        if (_isSheetLoaded == true)
                        {
                            _jsonSaveLoad.JsonSave(_currentHeroSheet.GetName(), _currentHeroSheet);
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Сначала нужно создать или загрузить лист персонажа.");
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
