using Newtonsoft.Json;

namespace dnd_character_sheet
{
    public abstract class SheetAbilities
    {
        private Dictionary<EnumAbilitiesDnd5E, int> _abilities = new Dictionary<EnumAbilitiesDnd5E, int>();
        
        [JsonProperty("Abilities")]
        public  Dictionary<EnumAbilitiesDnd5E, int> Abilities
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
        
        public abstract int GetAbilityModificator(EnumAbilitiesDnd5E ability);
        public abstract int GetAbilityScore(EnumAbilitiesDnd5E ability);
        public abstract int AbilityBonus(int score);
        public abstract void SetAbilities(Dictionary<Enum, int> abilities);
        public abstract void RaiseAbilityScore(EnumAbilitiesDnd5E abilityName);
        public abstract void LowerAbilityScore(EnumAbilitiesDnd5E abilityName);
    }
}
