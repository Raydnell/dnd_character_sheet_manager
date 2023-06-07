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

        public void AddSpell(SpellBase spell)
        {
            if (!_sheetSpells.ContainsKey(spell.Id))
            {
                _sheetSpells[spell.Id] = spell.Level;
            }
        }

        public void RemoveSpell(SpellBase spell)
        {
            if (_sheetSpells.ContainsKey(spell.Id))
            {
                _sheetSpells.Remove(spell.Id);
            }
        }
    }
}