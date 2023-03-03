namespace dnd_character_sheet
{
    public class SorcererClassDnd5E : ClassDnd5EBase
    {
        private string _className;

        public SorcererClassDnd5E()
        {
            _className = "sorcerer";
        }

        public string GetName()
        {
            return _className;
        }
    }
}
