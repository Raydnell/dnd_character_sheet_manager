namespace dnd_character_sheet
{
    public class SkillsDnd5E : SheetSkills
    {
        public SkillsDnd5E()
        {
            Skills = new List<string>();
        }

        public override bool CheckSkill(string skill)
        {
            return Skills.Contains(skill);
        }

        public override void AddSkill(string skill)
        {
            if(Skills.Contains(skill) == false)
            {
                Skills.Add(skill);
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