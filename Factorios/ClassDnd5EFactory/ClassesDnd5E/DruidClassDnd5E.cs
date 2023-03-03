namespace dnd_character_sheet
{
    public class DruidClassDnd5E : IClassDnd5E
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
