namespace dnd_character_sheet
{
    public class BarbarianClassDND5e : SheetClassBase
    {
        public BarbarianClassDND5e()
        {
            Name = EnumClassesDnd5E.Barbarian;
            HitDice = EnumDices.d12;
            SaveThrows = new List<EnumAbilitiesDnd5E>()
            {
                EnumAbilitiesDnd5E.Constitution,
                EnumAbilitiesDnd5E.Strength
            };
        }
    }
}