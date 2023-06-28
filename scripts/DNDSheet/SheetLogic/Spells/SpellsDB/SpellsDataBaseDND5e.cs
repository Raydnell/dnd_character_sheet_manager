namespace dnd_character_sheet
{
    public class SpellsDataBaseDND5e
    {
        public static Dictionary<int, SpellBase> SpellsDB = new Dictionary<int, SpellBase>();
        private static DirectoryInfo _folderInfo = new DirectoryInfo(@"Data\DND5E\DataBases");

        public static void LoadDB()
        {
            foreach (var item in _folderInfo.GetFiles())
            {
                if (item.Name == "DND5eSpellsDB.json")
                {
                    JsonSaveLoad.JsonLoad(@"Data\DND5E\DataBases\DND5eSpellsDB.json", ref SpellsDB);
                }
            }
        }

        public static void AddSpell(SpellBase spell)
        {
            SpellsDB[spell.Id] = spell;
        }

        public static void RemoveSpell(SpellBase spell)
        {
            if (SpellsDB.ContainsKey(spell.Id))
            {
                SpellsDB.Remove(spell.Id);
            }
        }

        public static void SaveDB()
        {
            JsonSaveLoad.JsonSave("DND5eSpellsDB", SpellsDB, @"Data\DND5E\DataBases\");
        }

        public static SpellBase GetSpell(int id)
        {
            return SpellsDB[id];
        }
    }
}