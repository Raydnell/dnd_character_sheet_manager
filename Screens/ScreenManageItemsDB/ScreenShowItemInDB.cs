namespace dnd_character_sheet
{
    public class ScreenShowItemInDB : IScreen
    {
        private ItemsDataBaseDND5e _itemDB;
        private ShowMenusCursor _showMenuCursor;

        public ScreenShowItemInDB()
        {
            _itemDB = new ItemsDataBaseDND5e();
            _showMenuCursor = new ShowMenusCursor();
        }
        
        public void ShowScreen(ref CharacterSheetBase heroSheet)
        {
            JsonSaveLoad.JsonLoad(@"DB\DND5eItemsDB.json", ref _itemDB);
            _showMenuCursor.ShowMenuPoints(EnumShowItemsInDBTitles.ListOfItems, _itemDB);
        }
    }
}