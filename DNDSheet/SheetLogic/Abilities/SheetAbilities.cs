using Newtonsoft.Json;

namespace dnd_character_sheet
{
    public abstract class SheetAbilities
    {
        private Dictionary<Enum, int> _abilities = new Dictionary<Enum, int>();
        
        [JsonProperty("Abilities")]
        public  Dictionary<Enum, int> Abilities
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
        
        public abstract int GetAbilityModificator(Enum ability);
        public abstract int GetAbilityScore(Enum ability);
        public abstract int AbilityBonus(int score);
        public abstract void SetAbilities(Dictionary<Enum, int> abilities);
        public abstract void SetAbilityScore(Enum abilityName, int abilityScore);
    }
}
