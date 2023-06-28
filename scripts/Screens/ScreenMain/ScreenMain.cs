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
                _choosenPoint = _showMenusCursor.ShowMenuPoints(EnumMainMenuTitles.MainMenu, typeof(EnumMainMenuPoints));
                switch(_choosenPoint)
                {
                    case EnumMainMenuPoints.CreateSheet:
                        _screen = new ScreenCreateSheet();
                        _screen.ShowScreen();
                        if (CurrentHeroSheet.HeroSheet.Name != null)
                        {
                            _screen = new ScreenActionsWithSheet();
                            _screen.ShowScreen();
                        }
                        _isSheetLoaded = true;
                        break;

                    case EnumMainMenuPoints.LoadSheet:
                        _screen = new ScreenLoadSheet();
                        _screen.ShowScreen();
                        _isSheetLoaded = true;
                        break;

                    case EnumMainMenuPoints.SaveSheeet:
                        if(_isSheetLoaded == true)
                        {
                            SaveSheet();
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

        private void SaveSheet()
        {
            CurrentHeroSheet.SaveSheet();
            Console.Clear();
            Console.WriteLine(LocalizationsStash.SelectedLocalization[EnumMainMenuTitles.SheetSaved]);
            Console.ReadKey();
        }
    }
}
