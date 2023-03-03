namespace dnd_character_sheet
{
    public class RangerClassDnd5EProduct : ClassDnd5EFactory
    {
        public override IClassDnd5E CreateClassDnd5E()
        {
            return new RangerClassDnd5E();
        }
    }
}
