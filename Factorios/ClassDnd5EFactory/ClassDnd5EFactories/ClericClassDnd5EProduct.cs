namespace dnd_character_sheet
{
    public class ClericClassDnd5EProduct : ClassDnd5EFactory
    {
        public override IClassDnd5E CreateClassDnd5E()
        {
            return new ClericClassDnd5E();
        }
    }
}
