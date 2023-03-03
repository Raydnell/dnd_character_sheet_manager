namespace dnd_character_sheet
{
    public class BardClassDnd5E : ClassDnd5EBase
    {
        private string _className;

        public BardClassDnd5E()
        {
            _className = "bard";
        }

        public string GetName()
        {
            return _className;
        }
    }
}
