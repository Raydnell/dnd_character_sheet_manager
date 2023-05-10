namespace dnd_character_sheet
{
    public class WarlockClassDND5e : SheetClassBase
    {
        public WarlockClassDND5e()
        {
            Name = EnumClassesDnd5E.Warlock;
            HitDice = 6;
            SaveThrows = new List<EnumAbilitiesDnd5E>()
            {
                EnumAbilitiesDnd5E.Constitution,
                EnumAbilitiesDnd5E.Charisma
            };
        }
    }
}