namespace dnd_character_sheet
{
    public class BarbarianClassDnd5E : IClassDnd5E
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
