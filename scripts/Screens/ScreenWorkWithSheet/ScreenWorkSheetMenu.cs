namespace dnd_character_sheet
{
    public class ScreenWorkSheetMenu : IScreen
    {
        private bool _isPointChoose;

        private IScreen _screen;
        private ShowMenusCursor _showMenuCursor;
        private Enum _choosenPoint;

        public ScreenWorkSheetMenu()
        {
            _showMenuCursor = new ShowMenusCursor();
        }

        public void ShowScreen()
        {
            while (_isPointChoose == false)
            {
                _choosenPoint = _showMenuCursor.ShowMenuPoints(EnumWorkWithSheetTitles.Menu, typeof(EnumWorkWithSheetPoints));
                if (Enum.TryParse<EnumWorkWithSheetPoints>(_choosenPoint.ToString(), out EnumWorkWithSheetPoints result))
                {
                    switch(result)
                    {
                        case EnumWorkWithSheetPoints.Back:
                            _isPointChoose = true;
                            break;

                        case EnumWorkWithSheetPoints.EditSheetFields:
                            break;

                        case EnumWorkWithSheetPoints.InventorySheetManage:
                            _screen = new ScreenWorkWithInventory();
                            _screen.ShowScreen();
                            break;

                        case EnumWorkWithSheetPoints.SheetDiceRolls:
                            break;

                        case EnumWorkWithSheetPoints.SpellsSheetManage:
                            break;
                    }
                }
            }
        }
    }
}