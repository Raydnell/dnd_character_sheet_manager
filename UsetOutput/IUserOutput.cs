namespace dnd_character_sheet
{
    public interface IUserOutput
    {
        public void Print(string value, bool transfer = true);
        public void Print(int value, bool transfer = true);
        public void Print(Dictionary<string, int> value);
        public void Print(Dictionary<string, bool> value);
        public void Print(Dictionary<int, Item> value);
        public void Print(Dictionary<string, string> value);
        public void Print(Type value, bool orderNumber = true);
        public void Print(List<string> value);
        public void Clear();
    }
}