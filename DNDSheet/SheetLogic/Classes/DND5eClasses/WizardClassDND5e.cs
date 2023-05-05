namespace dnd_character_sheet
{
    public class WizardClassDND5e : SheetClassBase
    {
        public WizardClassDND5e()
        {
            Name = EnumClassesDnd5E.Wizard;
            HitDice = 6;
            SaveThrows = new List<EnumAbilitiesDnd5E>()
            {
                EnumAbilitiesDnd5E.Intelligence,
                EnumAbilitiesDnd5E.Wisdom
            };
        }
    }
}