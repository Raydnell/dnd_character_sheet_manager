namespace dnd_character_sheet
{
    public class SkillsDnd5E : ISkills
    {
        private Dictionary<string, bool> _sheetSkills;

        public SkillsDnd5E()
        {
            _sheetSkills = new Dictionary<string, bool>()
            {
                ["athletics"] = false,
                ["acrobatics"] = false,
                ["sleight"] = false,
                ["stealth"] = false,
                ["arcana"] = false,
                ["history"] = false,
                ["investigation"] = false,
                ["nature"] = false,
                ["religion"] = false,
                ["animal"] = false,
                ["insight"] = false,
                ["medicine"] = false,
                ["perception"] = false,
                ["surival"] = false,
                ["deception"] = false,
                ["intimidation"] = false,
                ["perfomance"] = false,
                ["persuasion"] = false
            };
        }

        public bool CheckSkill(string skill)
        {
            return _sheetSkills[skill];
        }

        public void AddSkill(string skill)
        {
            if(_sheetSkills.ContainsKey(skill))
            {
                _sheetSkills[skill] = true;
            }
        }
    }
}