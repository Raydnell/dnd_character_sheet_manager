namespace dnd_character_sheet
{
    public interface IThrowChecksSystem : IActionSystem
    {
        public string MakeAbilityCheck();
        public string MakeSaveThrowCheck();
        public string MakeSkillCheck();
        public int GetSkillModificator(EnumSkillsDnd5E skill);
    }
}