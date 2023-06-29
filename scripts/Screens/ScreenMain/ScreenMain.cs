namespace dnd_character_sheet
{
    public class ScreenMain : IScreen
    {
        private bool _isSheetLoaded;
        private bool _isPointChoose;

        private Enum _choosenPoint;

        private ShowMenusCursor _showMenusCursor;
        private IScreen _screenActionsWithSheet;
        private IScreen _screenCreateSheet;
        private IScreen _screenLoadSheet;

        public ScreenMain()
        {
            _showMenusCursor = new ShowMenusCursor();
            _screenActionsWithSheet = new ScreenActionsWithSheet();
            _screenCreateSheet = new ScreenCreateSheet();
            _screenLoadSheet = new ScreenLoadSheet();
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
                        _screenCreateSheet.ShowScreen();
                        _screenActionsWithSheet.ShowScreen();
                        _isSheetLoaded = true;
                        break;

                    case EnumMainMenuPoints.LoadSheet:
                        _screenLoadSheet.ShowScreen();
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
                            _screenActionsWithSheet.ShowScreen();
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
