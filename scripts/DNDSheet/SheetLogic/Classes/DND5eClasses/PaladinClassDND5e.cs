namespace dnd_character_sheet
{
    public class PaladinClassDND5e : SheetClassBase
    {
        public PaladinClassDND5e()
        {
            Name = EnumClassesDnd5E.Paladin;
            HitDice = 10;
            SaveThrows = new List<EnumAbilitiesDnd5E>()
            {
                EnumAbilitiesDnd5E.Wisdom,
                EnumAbilitiesDnd5E.Charisma
            };
        }
    }
}