namespace dnd_character_sheet
{
    public class TraitsDataBaseDND5e
    {
        public static Dictionary<int, TraitBase> TraitsDB = new Dictionary<int, TraitBase>();
        private static DirectoryInfo _folderInfo = new DirectoryInfo(@"Data\DND5E\DataBases");

        public static void LoadDB()
        {
            foreach (var item in _folderInfo.GetFiles())
            {
                if (item.Name == "DND5eTraitsDB.json")
                {
                    JsonSaveLoad.JsonLoad(@"Data\DND5E\DataBases\DND5eTraitsDB.json", ref TraitsDB);
                }
            }
        }

        public static void SaveDB()
        {
            JsonSaveLoad.JsonSave("DND5eTraitsDB", TraitsDB, @"Data\DND5E\DataBases\");
        }
        
        public static void AddTrait(TraitBase trait)
        {
            TraitsDB[trait.Id] = trait;
        }

        public static void RemoveTrait(TraitBase trait)
        {
            if (TraitsDB.ContainsKey(trait.Id))
            {
                TraitsDB.Remove(trait.Id);
            }
        }

    }
}