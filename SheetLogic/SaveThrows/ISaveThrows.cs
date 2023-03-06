namespace dnd_character_sheet
{
    public interface ISaveThrows
    {
        public void SetSaveTrows(string className);                
        public bool CheckSaveThrow(string saveTrow);
        public Dictionary<string, bool> GetSaveThrows();
    }
}
