namespace dnd_character_sheet
{
    public abstract class SheetSaveThrows
    {
        private Dictionary<string, bool> _saveThrows = new Dictionary<string, bool>();
        public Dictionary<string, bool> SaveThrows
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
