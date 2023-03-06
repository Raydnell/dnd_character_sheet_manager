namespace dnd_character_sheet
{
    public class SorcererClassDnd5E : ClassDnd5EBase
    {
        private string _name;
        
        public SorcererClassDnd5E()
        {
            _name = "sorcerer";
        }

        public override string GetName()
        {
            return _name;
        }
    }
}
