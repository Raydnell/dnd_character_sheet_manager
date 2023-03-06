namespace dnd_character_sheet
{
    public class WarlockClassDnd5E : ClassDnd5EBase
    {
        private string _name;
        
        public WarlockClassDnd5E()
        {
            _name = "warlock";
        }

        public override string GetName()
        {
            return _name;
        }
    }
}
