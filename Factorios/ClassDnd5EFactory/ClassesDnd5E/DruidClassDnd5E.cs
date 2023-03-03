namespace dnd_character_sheet
{
    public class DruidClassDnd5E : ClassDnd5EBase
    {
        private string _className;

        public DruidClassDnd5E()
        {
            _className = "druid";
        }

        public string GetName()
        {
            return _className;
        }
    }
}
