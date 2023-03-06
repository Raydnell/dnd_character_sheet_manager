namespace dnd_character_sheet
{
    public class RogueClassDnd5E : ClassDnd5EBase
    {
        private string _name;
        
        public RogueClassDnd5E()
        {
            _name = "rogue";
        }

        public override string GetName()
        {
            return _name;
        }
    }
}
