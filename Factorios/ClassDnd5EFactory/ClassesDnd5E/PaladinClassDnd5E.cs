namespace dnd_character_sheet
{
    public class PaladinClassDnd5E : ClassDnd5EBase
    {
        private string _name;
        
        public PaladinClassDnd5E()
        {
            _name = "paladin";
        }

        public override string GetName()
        {
            return _name;
        }
    }
}
