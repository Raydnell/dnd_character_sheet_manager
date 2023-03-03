namespace dnd_character_sheet
{
    public class DruidClassDnd5EProduct : ClassDnd5EFactory
    {
        public override IClassDnd5E CreateClassDnd5E()
        {
            return new DruidClassDnd5E();
        }
    }
}
