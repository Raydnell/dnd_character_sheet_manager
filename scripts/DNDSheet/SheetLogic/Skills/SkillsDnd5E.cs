namespace dnd_character_sheet
{
    public class SkillsDnd5E : SheetSkills
    {
        public SkillsDnd5E()
        {
            Skills = new List<EnumSkillsDnd5E>();
        }

        public override bool CheckSkill(EnumSkillsDnd5E skill)
        {
            return Skills.Contains(skill);
        }

        public override void AddSkill(EnumSkillsDnd5E skill)
        {
            if(Skills.Contains(skill) == false)
            {
                Skills.Add(skill);
            }
        }

        public override EnumAbilitiesDnd5E SkillAbilityName(EnumSkillsDnd5E skill)
        {
            switch(skill)
            {
                case EnumSkillsDnd5E.Athletics:
                    return EnumAbilitiesDnd5E.Strength;

                case EnumSkillsDnd5E.Acrobatics:
                case EnumSkillsDnd5E.Sleight:
                case EnumSkillsDnd5E.Stealth:
                    return EnumAbilitiesDnd5E.Dexterity;
                
                case EnumSkillsDnd5E.Arcana:
                case EnumSkillsDnd5E.History:
                case EnumSkillsDnd5E.Investigation:
                case EnumSkillsDnd5E.Nature:
                case EnumSkillsDnd5E.Religion:
                    return EnumAbilitiesDnd5E.Intelligence;

                case EnumSkillsDnd5E.Animal:
                case EnumSkillsDnd5E.Insight:
                case EnumSkillsDnd5E.Medicine:
                case EnumSkillsDnd5E.Perception:
                case EnumSkillsDnd5E.Surival:
                    return EnumAbilitiesDnd5E.Wisdom;

                case EnumSkillsDnd5E.Deception:
                case EnumSkillsDnd5E.Intimidation:
                case EnumSkillsDnd5E.Perfomance:
                case EnumSkillsDnd5E.Persuasion:
                    return EnumAbilitiesDnd5E.Charisma;

                default:
                    return EnumAbilitiesDnd5E.Strength;
            }
        }

        public override void RemoveSkill(EnumSkillsDnd5E skill)
        {
            if (Skills.Contains(skill))
            {
                Skills.Remove(skill);
            }
        }
    }
}