using Newtonsoft.Json;

namespace dnd_character_sheet
{
    public abstract class TraitsListBase
    {
        private Dictionary<string, TraitBase> _traitsList;

        [JsonProperty("TraitsList")]
        public Dictionary<string, TraitBase> TraitsList
        {
            get
            {
                return _traitsList;
            }
            protected set
            {
                _traitsList = value;
            }
        }

        public abstract void AddTrait(string name, string source, string description);
    }
}