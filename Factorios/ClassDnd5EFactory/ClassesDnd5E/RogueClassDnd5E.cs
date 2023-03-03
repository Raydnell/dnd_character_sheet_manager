namespace dnd_character_sheet
{
    public class RogueClassDnd5E : ClassDnd5EBase
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
