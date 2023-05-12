namespace dnd_character_sheet
{
    public class ScreenShowItemInDB : IScreen
    {
        private LookingForItemInDB _lookingForItemInDB;

        public ScreenShowItemInDB()
        {
            _lookingForItemInDB = new LookingForItemInDB();
        }
        
        public void ShowScreen(ref CharacterSheetBase heroSheet)
        {
            _lookingForItemInDB.GetItemIdFromDB();
        }
    }
}