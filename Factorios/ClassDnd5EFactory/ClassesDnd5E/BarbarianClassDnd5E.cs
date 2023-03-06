namespace dnd_character_sheet
{
    public class BarbarianClassDnd5E : ClassDnd5EBase
    {
        private string _name;
        
        public BarbarianClassDnd5E()
        {
            _name = "barbarian";

        }

        public override string GetName()
        {
            return _name;
        }
    }
}
