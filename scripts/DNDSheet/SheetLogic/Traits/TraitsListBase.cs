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

        public void AddTrait(string name, string source, string description)
        {
            if (TraitsList.ContainsKey(name) == false)
            {
                TraitsList[name] = new TraitDND5e(name, source, description);
            }
        }
    }
}