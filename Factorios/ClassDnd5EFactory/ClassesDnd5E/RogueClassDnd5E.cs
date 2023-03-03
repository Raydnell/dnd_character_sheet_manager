namespace dnd_character_sheet
{
    public class RogueClassDnd5E : IClassDnd5E
    {
        private string _className;

        public RogueClassDnd5E()
        {
            _className = "rogue";
        }

        public string GetName()
        {
            return _className;
        }
    }
}
