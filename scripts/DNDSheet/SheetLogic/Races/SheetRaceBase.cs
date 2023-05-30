using Newtonsoft.Json;

namespace dnd_character_sheet
{
    public abstract class SheetRaceBase
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

        private int _speed;

        [JsonProperty("Speed")]
        public int Speed
        {
            get
            {
                return _speed;
            }
            protected set
            {
                _speed = value;
            }
        }

        private EnumCreaturesSizesDND5e _size;

        [JsonProperty("Size")]
        public EnumCreaturesSizesDND5e Size
        {
            get
            {
                return _size;
            }
            protected set
            {
                _size = value;
            }
        }
    }
}