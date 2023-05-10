namespace dnd_character_sheet
{
    public class ScreenAddItemInDB : IScreen
    {
        private Enum _choosenPoint;
        private ShowMenusCursor _showMenuCursor;
        private IUserInput _input;
        private IUserOutput _output;
        private bool _isNeedToStay;
        private PrintItemInfo _printItemInfo;
        private ItemBaseDND5e _newItem;
        private ModuleCreateNewItem _createNewItem;

        public ScreenAddItemInDB()
        {
            _showMenuCursor = new ShowMenusCursor();
            _input = new ConsoleInput();
            _output = new ConsoleOutput();
            _printItemInfo = new PrintItemInfo();
            _createNewItem = new ModuleCreateNewItem();
        }
        
        public void ShowScreen(ref CharacterSheetBase heroSheet)
        {
            _isNeedToStay = true;
            while (_isNeedToStay == true)
            {
                _newItem = _createNewItem.CreateItem();
                ItemsDataBaseDND5e.AddItem(_newItem);
                ItemsDataBaseDND5e.SaveDB();
                _output.Clear();
                _printItemInfo.ShowItemInfo(_newItem);
                _input.InputKey();
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