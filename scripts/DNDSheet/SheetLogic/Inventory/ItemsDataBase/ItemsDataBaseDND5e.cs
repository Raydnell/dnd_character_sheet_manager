namespace dnd_character_sheet
{
    public class ItemsDataBaseDND5e
    {
        public static Dictionary<int, ItemBaseDND5e> ItemsDB = new Dictionary<int, ItemBaseDND5e>();
        private static DirectoryInfo _folderInfo = new DirectoryInfo(@"Data\DND5E\DataBases");

        public static void LoadItemsBase()
        {
            foreach (var item in _folderInfo.GetFiles())
            {
                if (item.Name == "DND5eItemsDB.json")
                {
                    JsonSaveLoad.JsonLoad(@"Data\DND5E\DataBases\DND5eItemsDB.json", ref ItemsDB);
                }
            }
        }

        public static void AddItem(ItemBaseDND5e item)
        {
            ItemsDB[item.ItemId] = item;
        }

        public static void SaveDB()
        {
            JsonSaveLoad.JsonSave("DND5eItemsDB", ItemsDB, @"Data\DND5E\DataBases\");
        }
    }
}