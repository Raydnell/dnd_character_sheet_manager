namespace dnd_character_sheet
{
    public class MonkClassDnd5E : ClassDnd5EBase
    {
        private string _className;

        public MonkClassDnd5E()
        {
            _className = "monk";
        }

        public string GetName()
        {
            return _className;
        }
    }
}
