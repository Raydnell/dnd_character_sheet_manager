namespace dnd_character_sheet
{
    public class BardClassDnd5E : ClassDnd5EBase
    {
        private string _name;
        
        public BardClassDnd5E()
        {
            _name = "bard";

        }

        public override string GetName()
        {
            return _name;
        }
    }
}
