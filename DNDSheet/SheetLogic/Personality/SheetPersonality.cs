using Newtonsoft.Json;

namespace dnd_character_sheet
{
    public abstract class SheetPersonality
    {
        private Dictionary<EnumPersonalitiesDND5E, string> _personalityList;

        [JsonProperty("PersonalityList")]
        public Dictionary<EnumPersonalitiesDND5E, string> PersonalityList
        {
            get
            {
                return _personalityList;
            }
            protected set
            {
                _personalityList = value;
            }
        }

        public abstract void AddPersonality(EnumPersonalitiesDND5E personality, string value);
    }
}
