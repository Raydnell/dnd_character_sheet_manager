using Newtonsoft.Json;

namespace dnd_character_sheet
{
    public abstract class SheetSaveThrows
    {
        private List<EnumAbilitiesDnd5E> _saveThrows = new List<EnumAbilitiesDnd5E>();
        
        [JsonProperty("SaveThrows")]
        public List<EnumAbilitiesDnd5E> SaveThrows
        {
            get
            {
                return _saveThrows;
            }
            protected set
            {
                _saveThrows = value;
            }
        }

        public abstract void SetSaveTrows(EnumClassesDnd5E className);                
        public abstract bool CheckSaveThrow(EnumAbilitiesDnd5E saveTrow);
    }
}
