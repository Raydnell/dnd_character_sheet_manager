namespace dnd_character_sheet
{
    public class FighterClassDnd5E : ClassDnd5EBase
    {
        private string _className;

        public FighterClassDnd5E()
        {
            _className = "fighter";
        }

        public string GetName()
        {
            return _className;
        }
    }
}
