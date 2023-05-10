namespace dnd_character_sheet
{
    public static class ItemsDataBaseDND5e
    {

        public static Dictionary<int, ItemBaseDND5e> ItemsDB = new Dictionary<int, ItemBaseDND5e>();

        public static void LoadItemsBase()
        {
            JsonSaveLoad.JsonLoad(@"DB\DND5eItemsDB.json", ref ItemsDB);
        }

        public static ItemBaseDND5e GetItem(int id)
        {
            return ItemsDB[id];
        }

        public static void AddItem(ItemBaseDND5e item)
        {
            ItemsDB[item.ItemId] = item;
        }

        public static void SaveDB()
        {
            JsonSaveLoad.JsonSave("DND5eItemsDB", ItemsDB, @"DB\");
        }
    }
}