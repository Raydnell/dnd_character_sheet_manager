namespace dnd_character_sheet
{
    public class ScreenMain : IScreen
    {
        private bool _isSheetLoaded;
        private bool _isPointChoose;

        private Enum _choosenPoint;

        private IScreen _screen;
        private ShowMenusCursor _showMenusCursor;

        public ScreenMain()
        {
            _showMenusCursor = new ShowMenusCursor();
        }

        public void ShowScreen()
        {
            _isPointChoose = false;
            while(_isPointChoose == false)
            {
                _choosenPoint = _showMenusCursor.ShowMenuPoints(
                    EnumMainMenuTitles.MainMenu,
                    typeof(EnumMainMenuPoints)
                );
                switch(_choosenPoint)
                {
                    case EnumMainMenuPoints.CreateSheet:
                        _screen = new ScreenCreateSheet();
                        _screen.ShowScreen();
                        _isSheetLoaded = true;
                        break;

                    case EnumMainMenuPoints.LoadSheet:
                        _screen = new ScreenLoadSheet();
                        _screen.ShowScreen();
                        _isSheetLoaded = true;
                        break;

                    case EnumMainMenuPoints.PrintSheet:
                        if(_isSheetLoaded == true)
                        {
                            Console.Clear();
                            PrintSheetInfo.ShowSheetFields(CurrentHeroSheet.HeroSheet);
                            Console.ReadKey();
                        }
                        else
                        {
                            PrintListNotLoaded();
                        }
                        break;

                    case EnumMainMenuPoints.DiceRolls:
                        _screen = new ScreenRollDice();
                        _screen.ShowScreen();
                        break;

                    case EnumMainMenuPoints.WorkWithSheet:
                        if(_isSheetLoaded == true)
                        {
                            _screen = new ScreenWorkSheetMenu();
                            _screen.ShowScreen();
                        }
                        else
                        {
                            PrintListNotLoaded();
                        }
                        break;

                    case EnumMainMenuPoints.SaveSheeet:
                        if(_isSheetLoaded == true)
                        {
                            JsonSaveLoad.JsonSave(CurrentHeroSheet.HeroSheet.Name, CurrentHeroSheet.HeroSheet, @"Character_Sheets\" + CurrentHeroSheet.HeroSheet.Edition + @"\");
                            Console.WriteLine(LocalizationsStash.SelectedLocalization[EnumMainMenuTitles.SheetSaved]);
                            Console.ReadKey();
                        }
                        else
                        {
                            PrintListNotLoaded();
                        }
                        break;

                    case EnumMainMenuPoints.SheetActions:
                        if(_isSheetLoaded == true)
                        {
                            _screen = new ScreenActionsWithSheet();
                            _screen.ShowScreen();
                        }
                        else
                        {
                            PrintListNotLoaded();
                        }
                        break;

                    case EnumMainMenuPoints.Exit:
                        Environment.Exit(0);
                        break;

                    case EnumMainMenuPoints.WorkWithItemsBase:
                        _screen = new ScreenManageItemsDB();
                        _screen.ShowScreen();
                        break;

                    case EnumMainMenuPoints.ScreenManageSpellsDB:
                        _screen = new ScreenManageSpellsDB();
                        _screen.ShowScreen();
                        break;

                    default:
                        PrintListNotLoaded();
                        break;
                }
            }
        }

        private void PrintListNotLoaded()
        {
            Console.Clear();
            Console.WriteLine(LocalizationsStash.SelectedLocalization[EnumMainMenuTitles.FirstLoadOrCreateSheet]);
            Console.ReadKey();
        }
    }
}
