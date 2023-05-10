using Newtonsoft.Json;

namespace dnd_character_sheet
{
    public abstract class SheetCombatAbilities
    {
        private Dictionary<EnumCombatStatsDND5e, int> _combatStats;
        
        [JsonProperty("CombatStats")]
        public Dictionary<EnumCombatStatsDND5e, int> CombatStats
        {
            get
            {
                return _combatStats;
            }
            protected set
            {
                _combatStats = value;
            }
        }
        
        public abstract void ChangeStat(Enum stat, int value);
        public abstract void ResetDeathSaves();
    }
}
