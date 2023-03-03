namespace dnd_character_sheet
{
    public class RogueClassDnd5EProduct : ClassDnd5EFactory
    {
        public override IClassDnd5E CreateClassDnd5E()
        {
            return new RogueClassDnd5E();
        }
    }
}
