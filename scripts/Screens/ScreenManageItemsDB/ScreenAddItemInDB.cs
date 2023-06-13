namespace dnd_character_sheet
{
    public class ScreenAddItemInDB : IScreen
    {
        private bool _isNeedToStay;
        
        private Enum _choosenPoint;
        private ShowMenusCursor _showMenuCursor;
        private ItemBaseDND5e _newItem;
        private ModuleCreateNewItem _createNewItem;

        public ScreenAddItemInDB()
        {
            _showMenuCursor = new ShowMenusCursor();
            _createNewItem = new ModuleCreateNewItem();
        }
        
        public void ShowScreen()
        {
            _isNeedToStay = true;
            while (_isNeedToStay == true)
            {
                _newItem = _createNewItem.CreateItem();
                ItemsDataBaseDND5e.AddItem(_newItem);
                ItemsDataBaseDND5e.SaveDB();
                Console.Clear();
                PrintItemInfo.ShowItemInfo(_newItem);
                Console.ReadKey();
                _isNeedToStay = BreakOrContinue();
            }
        }

        private bool BreakOrContinue()
        {
            _choosenPoint = _showMenuCursor.ShowMenuPoints(EnumSheetCreateTitles.AddMore, typeof(EnumYesNo));
            if (Enum.TryParse<EnumYesNo>(_choosenPoint.ToString(), out EnumYesNo result))
            {
                switch(result)
                {
                    case EnumYesNo.Yes:
                        return true;

                    case EnumYesNo.No:
                        return false;
                }
            }

            return false;
        }
    }
}