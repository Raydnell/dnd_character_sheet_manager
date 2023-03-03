namespace dnd_character_sheet
{
    public class BarbarianClassDnd5E : ClassDnd5EBase
    {
        private string _className;

        public BarbarianClassDnd5E()
        {
            _className = "barbarian";
        }

        public string GetName()
        {
            return _className;
        }
    }
}
