namespace dnd_character_sheet
{
    public interface ISkills
    {
        public bool CheckSkill(string skill);
        public void AddSkill(string skill);
        public Dictionary<string, bool> GetSkills();
        public string SkillAbilityName(string skill);
    }
}
