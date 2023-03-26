namespace dnd_character_sheet
{
    public class SkillsDnd5E : SheetSkills
    {
        public SkillsDnd5E()
        {
            Skills = new Dictionary<string, bool>()
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

        public override bool CheckSkill(string skill)
        {
            return Skills[skill];
        }

        public override void AddSkill(string skill)
        {
            if(Skills.ContainsKey(skill))
            {
                Skills[skill] = true;
            }
        }

        public override string SkillAbilityName(string skill)
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