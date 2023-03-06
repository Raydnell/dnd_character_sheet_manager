namespace dnd_character_sheet
{
    public class MonkClassDnd5E : ClassDnd5EBase
    {
        private string _name;
        
        public MonkClassDnd5E()
        {
            _name = "monk";
        }

        public override string GetName()
        {
            return _name;
        }
    }
}
