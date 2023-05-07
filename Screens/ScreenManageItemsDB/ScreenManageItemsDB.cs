namespace dnd_character_sheet
{
    public class ScreenManageItemsDB : IScreen
    {
        private Enum _choosenPoint;
        private ShowMenusCursor _showMenusCursor;
        private IScreen _screen;

        public ScreenManageItemsDB()
        {
            _showMenusCursor = new ShowMenusCursor();
        }
        
        public void ShowScreen(ref CharacterSheetBase heroSheet)
        {
            _choosenPoint = _showMenusCursor.ShowMenuPoints(EnumManageItemBaseTitles.WhatNeedToDoWithBase, typeof(EnumManageItemBasePoints));

            switch(_choosenPoint)
            {
                case EnumManageItemBasePoints.AddNewItem:
                    _screen = new ScreenAddItemInDB();
                    _screen.ShowScreen(ref heroSheet);
                    break;

                case EnumManageItemBasePoints.ChangeItemInBase:
                    break;

                case EnumManageItemBasePoints.RemoveItemFromBase:
                    break;

                case EnumManageItemBasePoints.Escape:
                    break;

                case EnumManageItemBasePoints.ShowItemsBase:
                    _screen = new ScreenShowItemInDB();
                    _screen.ShowScreen(ref heroSheet);
                    break;
            }
        }
    }
}