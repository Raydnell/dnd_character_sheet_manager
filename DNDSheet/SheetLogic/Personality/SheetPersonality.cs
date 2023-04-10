using Newtonsoft.Json;

namespace dnd_character_sheet
{
    public abstract class SheetPersonality
    {
        private Dictionary<string, string> _personalityList;

        [JsonProperty("PersonalityList")]
        public Dictionary<string, string> PersonalityList
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

        public abstract void AddPersonality(string personality, string value);
    }
}
