namespace dnd_character_sheet
{
    public class ScreenMain : IScreen
    {
        private bool _isSheetLoaded;
        private bool _isPointChoose;

        private string _choosenPoint;

        private JsonSaveLoad _jsonSaveLoad;
        private IUserOutput _userOutput;
        private IUserInput _userInput;
        private PrintSheetInfo _printSheetInfo;
        private IScreen _screen;
        private ShowMenusCursor _showMenusCursor;

        public ScreenMain()
        {
            _jsonSaveLoad = new JsonSaveLoad();
            _userOutput = new ConsoleOutput();
            _userInput = new ConsoleInput();
            _printSheetInfo = new PrintSheetInfo();
            _showMenusCursor = new ShowMenusCursor();
        }

        public void ShowScreen(ref CharacterSheetBase heroSheet, Enum language)
        {
            Enum _choosenPoint2;
            
            _isPointChoose = false;
            while(_isPointChoose == false)
            {
                _choosenPoint2 = _showMenusCursor.ShowMenuPoints(
                    LocalizationsStash.MainMenuTitles, 
                    LocalizationsStash.MainMenuPoints, 
                    language, 
                    EnumMainMenuTitles.MainMenu
                );
                switch(_choosenPoint2)
                {
                    case EnumMainMenuPoints.CreateSheet:
                        _screen = new ScreenSheetCreate();
                        _screen.ShowScreen(ref heroSheet, language);
                        _isSheetLoaded = true;
                        break;

                    case EnumMainMenuPoints.LoadSheet:
                        _screen = new ScreenLoadSheet();
                        _screen.ShowScreen(ref heroSheet, language);
                        _isSheetLoaded = true;
                        break;

                    case EnumMainMenuPoints.PrintSheet:
                        if(_isSheetLoaded == true)
                        {
                            _userOutput.Clear();
                            _printSheetInfo.ShowSheetFields(heroSheet, language);
                            _userInput.InputKey();
                        }
                        else
                        {
                            PrintListNotLoaded();
                        }
                        break;

                    case EnumMainMenuPoints.DiceRolls:
                        _screen = new ScreenRollDice();
                        _screen.ShowScreen(ref heroSheet, language);
                        break;

                    case EnumMainMenuPoints.WorkWithSheet:
                        if(_isSheetLoaded == true)
                        {
                            _screen = new ScreenWorkSheetMenu();
                            _screen.ShowScreen(ref heroSheet, language);
                        }
                        else
                        {
                            PrintListNotLoaded();
                        }
                        break;

                    case EnumMainMenuPoints.SaveSheeet:
                        if(_isSheetLoaded == true)
                        {
                            _jsonSaveLoad.JsonSave(heroSheet.Name, heroSheet, @"Character_Sheets\" + heroSheet.Edition + @"\");
                            _userOutput.Print(LocalizationsStash.MainMenuTitles[EnumMainMenuTitles.SheetSaved][EnumLanguages.Russian]);
                            _userInput.InputKey();
                        }
                        else
                        {
                            PrintListNotLoaded();
                        }
                        break;

                    case EnumMainMenuPoints.Exit:
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
