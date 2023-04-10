using Newtonsoft.Json;

namespace dnd_character_sheet
{
    public abstract class SheetSkills
    {
        private List<string> _skills;
        
        [JsonProperty("Skills")]
        public List<string> Skills
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
        
        public abstract bool CheckSkill(string skill);
        public abstract void AddSkill(string skill);
        public abstract string SkillAbilityName(string skill);
    }
}
