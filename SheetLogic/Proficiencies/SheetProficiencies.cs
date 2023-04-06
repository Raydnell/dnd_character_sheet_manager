using Newtonsoft.Json;

namespace dnd_character_sheet
{
    public abstract class SheetProficiencies
    {
        private List<string> _proficiencies = new List<string>();

        [JsonProperty("Proficiencies")]
        public List<string> Proficiencies
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
