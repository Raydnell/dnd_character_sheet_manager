using Newtonsoft.Json;

namespace dnd_character_sheet
{
    public abstract class TraitsListBase
    {
        private Dictionary<int, int> _traitsList;

        [JsonProperty("TraitsList")]
        public Dictionary<int, int> TraitsList
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

        public void AddTrait(int traitId)
        {
            if (!_traitsList.ContainsKey(traitId))
            {
                _traitsList[traitId] = TraitsDataBaseDND5e.TraitsDB[traitId].LevelGained;
            }
        }

        public void RemoveTrait(int traitId)
        {
            if (_traitsList.ContainsKey(traitId))
            {
                _traitsList.Remove(traitId);
            }
        }
    }
}