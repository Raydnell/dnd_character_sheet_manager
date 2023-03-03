namespace dnd_character_sheet
{
    public class PaladinClassDnd5E : ClassDnd5EBase
    {
        private string _className;

        public PaladinClassDnd5E()
        {
            _className = "paladin";
        }

        public string GetName()
        {
            return _className;
        }
    }
}
