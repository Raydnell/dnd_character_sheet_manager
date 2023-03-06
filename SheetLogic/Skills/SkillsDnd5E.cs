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

        public Dictionary<string, bool> GetSkills()
        {
            return _sheetSkills;
        }

        public string SkillAbilityName(string skill)
        {
            switch(skill)
            {
                case "athletics":
                    return "strength";

                case "acrobatics":
                case "sleight":
                case "stealth":
                    return "dexterity";
                
                case "arcana":
                case "history":
                case "investigation":
                case "nature":
                case "religion":
                    return "intelligence";

                case "animal":
                case "insight":
                case "medicine":
                case "perception":
                case "surival":
                    return "wisdom";

                case "deception":
                case "intimidation":
                case "perfomance":
                case "persuasion":
                    return "charisma";

                default:
                    return "null";
            }
        }
    }
}