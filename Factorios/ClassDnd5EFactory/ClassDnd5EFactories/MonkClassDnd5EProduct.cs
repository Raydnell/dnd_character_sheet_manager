namespace dnd_character_sheet
{
    public class MonkClassDnd5EProduct : ClassDnd5EFactory
    {
        public override IClassDnd5E CreateClassDnd5E()
        {
            return new MonkClassDnd5E();
        }
    }
}
