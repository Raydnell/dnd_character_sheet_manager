namespace dnd_character_sheet
{
    public class PaladinClassDnd5EProduct : ClassDnd5EFactory
    {
        public override IClassDnd5E CreateClassDnd5E()
        {
            return new PaladinClassDnd5E();
        }
    }
}
