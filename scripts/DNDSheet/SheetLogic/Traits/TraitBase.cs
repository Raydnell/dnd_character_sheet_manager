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

        public TraitBase(string name, string source, string description)
        {
            Name = name;
            Source = source;
            Description = description;
        }
    }
}