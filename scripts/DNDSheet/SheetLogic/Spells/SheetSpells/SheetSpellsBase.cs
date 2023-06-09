using Newtonsoft.Json;

namespace dnd_character_sheet
{
    public abstract class SheetSpellsBase
    {
        private Dictionary<int, int> _sheetSpells;

        [JsonProperty("SheetSpells")]
        public Dictionary<int, int> SheetSpells 
        { 
            get { return _sheetSpells; } 
            protected set { _sheetSpells = value; }
        }

        public void AddSpell(int id)
        {
            if (!_sheetSpells.ContainsKey(id))
            {
                _sheetSpells[id] = SpellsDataBaseDND5e.SpellsDB[id].Level;
            }
        }

        public void RemoveSpell(int id)
        {
            if (_sheetSpells.ContainsKey(id))
            {
                _sheetSpells.Remove(id);
            }
        }
    }
}