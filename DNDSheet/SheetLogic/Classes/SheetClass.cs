using Newtonsoft.Json;

namespace dnd_character_sheet
{
    public abstract class SheetClass
    {
        private EnumClassesDnd5E _name;
        
        [JsonProperty("Name")]
        public EnumClassesDnd5E Name
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

        public abstract void SetClass(Enum sheetClass);
    }
}
