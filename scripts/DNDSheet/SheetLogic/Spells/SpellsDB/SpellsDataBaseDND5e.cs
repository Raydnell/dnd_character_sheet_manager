namespace dnd_character_sheet
{
    public class SpellsDataBaseDND5e
    {
        public static Dictionary<int, SpellBase> SpellsDB = new Dictionary<int, SpellBase>();

        public static void LoadDB()
        {
            JsonSaveLoad.JsonLoad(@"DB\DND5eSpellsDB.json", ref SpellsDB);
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
            JsonSaveLoad.JsonSave("DND5eSpellsDB", SpellsDB, @"DB\");
        }

        public static SpellBase GetSpell(int id)
        {
            return SpellsDB[id];
        }

    }
}