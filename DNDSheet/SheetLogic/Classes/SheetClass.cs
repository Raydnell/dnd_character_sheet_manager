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

        private int _hitDice;

        [JsonProperty("HitDice")]
        public int HitDice
        {
            get
            {
                return _hitDice;
            }
            protected set
            {
                _hitDice = value;
            }
        }

        public abstract void SetClass(Enum sheetClass);
    }
}
