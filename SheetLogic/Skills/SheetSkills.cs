using Newtonsoft.Json;

namespace dnd_character_sheet
{
    public abstract class SheetSkills
    {
        private Dictionary<string, bool> _skills = new Dictionary<string, bool>();
        
        [JsonProperty("Skills")]
        public Dictionary<string, bool> Skills
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
