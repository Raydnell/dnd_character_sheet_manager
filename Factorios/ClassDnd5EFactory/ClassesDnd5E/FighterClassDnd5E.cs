namespace dnd_character_sheet
{
    public class FighterClassDnd5E : ClassDnd5EBase
    {
        private string _name;
        
        public FighterClassDnd5E()
        {
            _name = "fighter";

        }

        public override string GetName()
        {
            return _name;
        }
    }
}
