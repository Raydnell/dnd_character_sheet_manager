namespace dnd_character_sheet
{
    public class ClericClassDnd5E : ClassDnd5EBase
    {
        private string _className;

        public ClericClassDnd5E()
        {
            _className = "cleric";
        }

        public string GetName()
        {
            return _className;
        }
    }
}
