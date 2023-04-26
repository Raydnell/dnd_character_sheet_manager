using Newtonsoft.Json;

namespace dnd_character_sheet
{
    public abstract class SheetRace
    {
        private EnumRacesDnd5E _name;

        [JsonProperty("Name")]
        public EnumRacesDnd5E Name
        {
            get
            {
                return _name;
            }
            protected set
            {
                _name = value;
            }
        }

        public abstract void SetRace(Enum race);
    }
}
