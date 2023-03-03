namespace dnd_character_sheet
{
    public class WizardClassDnd5EProduct : ClassDnd5EFactory
    {
        public override IClassDnd5E CreateClassDnd5E()
        {
            return new WizardClassDnd5E();
        }
    }
}
