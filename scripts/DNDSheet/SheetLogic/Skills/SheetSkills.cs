using Newtonsoft.Json;

namespace dnd_character_sheet
{
    public abstract class SheetSkills
    {
        private List<EnumSkillsDnd5E> _skills;
        
        [JsonProperty("Skills")]
        public List<EnumSkillsDnd5E> Skills
        {
            get
            {
                return _skills;
            }
            protected set
            {
                _skills = value;
            }
        }
        
        public abstract bool CheckSkill(EnumSkillsDnd5E skill);
        public abstract void AddSkill(EnumSkillsDnd5E skill);
        public abstract void RemoveSkill(EnumSkillsDnd5E skill);
        public abstract EnumAbilitiesDnd5E SkillAbilityName(EnumSkillsDnd5E skill);
    }
}
