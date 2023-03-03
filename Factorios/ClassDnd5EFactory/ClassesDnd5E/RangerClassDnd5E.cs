namespace dnd_character_sheet
{
    public class RangerClassDnd5E : IClassDnd5E
    {
        private string _className;

        public RangerClassDnd5E()
        {
            _className = "ranger";
        }

        public string GetName()
        {
            return _className;
        }
    }
}
