namespace dnd_character_sheet
{
    public class WizardClassDnd5E : ClassDnd5EBase
    {
        private string _name;
        
        public WizardClassDnd5E()
        {
            _name = "wizard";
        }

        public override string GetName()
        {
            return _name;
        }
    }
}
