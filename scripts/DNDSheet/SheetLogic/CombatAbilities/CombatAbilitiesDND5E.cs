namespace dnd_character_sheet
{
    public class CombatAbilitiesDND5E : SheetCombatAbilities
    {
        public CombatAbilitiesDND5E()
        {
            CombatStats = new Dictionary<EnumCombatStatsDND5e, int>()
            {
                [EnumCombatStatsDND5e.ArmorClass] = 0,
                [EnumCombatStatsDND5e.CurrentHitDices] = 0,
                [EnumCombatStatsDND5e.CurrentHP] = 0,
                [EnumCombatStatsDND5e.DeathFailure] = 0,
                [EnumCombatStatsDND5e.DeathSucces] = 0,
                [EnumCombatStatsDND5e.MaximumHP] = 0,
                [EnumCombatStatsDND5e.TemporaryHP] = 0,
                [EnumCombatStatsDND5e.Round] = 1
            };
        }

        public override void ChangeStat(Enum stat, int value)
        {
            if (Enum.TryParse<EnumCombatStatsDND5e>(stat.ToString(), out EnumCombatStatsDND5e result))
            {
                CombatStats[result] = value;
            }
        }
        
        public override void ResetDeathSaves()
        {
            CombatStats[EnumCombatStatsDND5e.DeathFailure] = 0;
            CombatStats[EnumCombatStatsDND5e.DeathSucces] = 0;
        }
    }
}