using Newtonsoft.Json;

namespace dnd_character_sheet
{
    public abstract class TraitBase
    {
        private string _name;
        
        [JsonProperty("Name")]
        public string Name
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

        private string _source;

        [JsonProperty("Source")]
        public string Source
        {
            get
            {
                return _source;
            }
            protected set
            {
                _source = value;
            }
        }

        private string _description;

        [JsonProperty("Description")]
        public string Description
        {
            get
            {
                return _description;
            }
            protected set
            {
                _description = value;
            }
        }

        private int _id;

        [JsonProperty("Id")]
        public int Id
        {
            get
            {
                return _id;
            }
            protected set
            {
                _id = value;
            }
        }

        private int _levelGained;

        [JsonProperty("LevelGained")]
        public int LevelGained
        {
            get
            {
                return _levelGained;
            }
            protected set
            {
                _levelGained = value;
            }
        }

        public void SetID()
        {
            _id = RollRandom.LetsRoll.Next(1000, 10000);
        }

        public void SetName(string name)
        {
            _name = name;
        }

        public void SetDescription(string description)
        {
            _description = description;
        }

        public void SetSource(string source)
        {
            _source = source;
        }

        public void SetLevel(int level)
        {
            _levelGained = level;
        }
    }
}