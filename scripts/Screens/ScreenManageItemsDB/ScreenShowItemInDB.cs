namespace dnd_character_sheet
{
    public class ScreenShowItemInDB : IScreen
    {
        private ShowMenusCursor _showMenuCursor;

        public ScreenShowItemInDB()
        {
            _showMenuCursor = new ShowMenusCursor();
        }
        
        public void ShowScreen(ref CharacterSheetBase heroSheet)
        {
            _showMenuCursor.ShowMenuPoints(EnumShowItemsInDBTitles.ListOfItems, ItemsDataBaseDND5e.ItemsDB);
        }
    }
}