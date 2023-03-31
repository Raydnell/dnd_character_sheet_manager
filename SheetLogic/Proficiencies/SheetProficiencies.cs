using Newtonsoft.Json;

namespace dnd_character_sheet
{
    public abstract class SheetProficiencies
    {
        private Dictionary<string, bool> _proficiencies = new Dictionary<string, bool>();

        [JsonProperty("Proficiencies")]
        public Dictionary<string, bool> Proficiencies
        {
            get
            {
                return _proficiencies;
            }
            protected set
            {
                _proficiencies = value;
            }
        }

        public abstract void AddProficiency(string prof);
        public abstract bool CheckProficiency(string prof);
    }
}
