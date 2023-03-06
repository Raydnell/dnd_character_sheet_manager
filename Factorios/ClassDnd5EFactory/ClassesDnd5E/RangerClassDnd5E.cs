namespace dnd_character_sheet
{
    public class RangerClassDnd5E : ClassDnd5EBase
    {
        private string _name;
        
        public RangerClassDnd5E()
        {
            _name = "ranger";
        }

        public override string GetName()
        {
            return _name;
        }
    }
}
