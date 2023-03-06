namespace dnd_character_sheet
{
    public class DruidClassDnd5E : ClassDnd5EBase
    {
        private string _name;
        
        public DruidClassDnd5E()
        {
            _name = "druid";

        }

        public override string GetName()
        {
            return _name;
        }
    }
}
