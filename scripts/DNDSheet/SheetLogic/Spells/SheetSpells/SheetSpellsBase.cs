using Newtonsoft.Json;

namespace dnd_character_sheet
{
    public abstract class SheetSpellsBase
    {
        private Dictionary<int, int> _sheetSpells;

        [JsonProperty("Name")]
        public Dictionary<int, int> SheetSpells 
        { 
            get { return _sheetSpells; } 
            protected set { _sheetSpells = value; }
        }

        public void AddSpell(SpellBase spell)
        {

        }

        public void RemoveSpell(SpellBase spell)
        {
            
        }
    }
}