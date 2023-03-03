namespace dnd_character_sheet
{
    public abstract class ClassDnd5EBase
    {
        public string _name { get; private set;}

        public ClassDnd5EBase()
        {
            _name = "empty_class";
        }

        public void SetName(string name)
        {
            _name = name;
        }
    }
}