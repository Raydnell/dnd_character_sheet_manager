namespace dnd_character_sheet
{
    public interface IUserOutput
    {
        public void Print(string value, bool transfer = true);
        public void Print(int value, bool transfer = true);
        public void Print(Dictionary<string, int> value);
        public void Print(Dictionary<string, bool> value);
        //public void Print(Dictionary<int, BaseItem> value);
        public void Print(Dictionary<string, string> value);
        public void Print(Type value, bool orderNumber = true);
        public void Print(List<string> value);
        public void Clear();
        public void Print(Dictionary<string, string>.KeyCollection value);
        public void Print(Dictionary<EnumAbilitiesDnd5E, int> value);
        public void Print(List<EnumSkillsDnd5E> value);
        public void Print(List<EnumAllDND5eProficiencies> value);
        public void Print(Dictionary<EnumPersonalitiesDND5E, string> value);
        public void Print(Dictionary<string, TraitBase> value);
        public void PrintInventory(Dictionary<int, int> inventory);
    }
}