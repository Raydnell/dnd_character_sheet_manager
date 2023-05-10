namespace dnd_character_sheet
{
    public class FighterClassDND5e : SheetClassBase
    {
        public FighterClassDND5e()
        {
            Name = EnumClassesDnd5E.Fighter;
            HitDice = 10;
            SaveThrows = new List<EnumAbilitiesDnd5E>()
            {
                EnumAbilitiesDnd5E.Constitution,
                EnumAbilitiesDnd5E.Strength
            };
        }
    }
}