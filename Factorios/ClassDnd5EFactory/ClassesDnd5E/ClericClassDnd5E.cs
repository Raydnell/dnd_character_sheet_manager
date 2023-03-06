namespace dnd_character_sheet
{
    public class ClericClassDnd5E : ClassDnd5EBase
    {
        private string _name;
        
        public ClericClassDnd5E()
        {
            _name = "cleric";

        }

        public override string GetName()
        {
            return _name;
        }
    }
}
