namespace dnd_character_sheet
{
    public class FighterClassDnd5EProduct : ClassDnd5EFactory
    {
        public override IClassDnd5E CreateClassDnd5E()
        {
            return new FighterClassDnd5E();
        }
    }
}
