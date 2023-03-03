namespace dnd_character_sheet
{
    interface ISaveThrows
    {
        void SetSaveTrows(string className);                
        bool CheckSaveThrow(string saveTrow);
    }
}
