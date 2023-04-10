using Newtonsoft.Json;

namespace dnd_character_sheet
{
    public abstract class SheetAbilities
    {
        private Dictionary<string, int> _abilities = new Dictionary<string, int>();
        
        [JsonProperty("Abilities")]
        public  Dictionary<string, int> Abilities
        {
            get
            {
                return _abilities;
            }
            protected set
            {
                _abilities = value;
            }
        }
        
        public abstract int GetAbilityModificator(string ability);
        public abstract int GetAbilityScore(string ability);
        public abstract int AbilityBonus(int score);
        public abstract void SetAbilities(Dictionary<string, int> abilities);
    }
}
