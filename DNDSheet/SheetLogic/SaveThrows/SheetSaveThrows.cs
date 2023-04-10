using Newtonsoft.Json;

namespace dnd_character_sheet
{
    public abstract class SheetSaveThrows
    {
        private List<string> _saveThrows = new List<string>();
        
        [JsonProperty("SaveThrows")]
        public List<string> SaveThrows
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
        
        public abstract void SetSaveTrows(string className);                
        public abstract bool CheckSaveThrow(string saveTrow);
    }
}
