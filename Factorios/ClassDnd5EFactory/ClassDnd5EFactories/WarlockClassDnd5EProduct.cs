namespace dnd_character_sheet
{
    public class WarlockClassDnd5EProduct : ClassDnd5EFactory
    {
        public override IClassDnd5E CreateClassDnd5E()
        {
            return new WarlockClassDnd5E();
        }
    }
}
