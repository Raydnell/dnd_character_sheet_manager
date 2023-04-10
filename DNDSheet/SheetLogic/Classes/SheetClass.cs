using Newtonsoft.Json;

namespace dnd_character_sheet
{
    public abstract class SheetClass
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

        public abstract void SetClass(string sheetClass);
    }
}
