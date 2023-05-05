namespace dnd_character_sheet
{
    public class BardClassDND5e : SheetClassBase
    {
        public BardClassDND5e()
        {
            Name = EnumClassesDnd5E.Bard;
            HitDice = 8;
            SaveThrows = new List<EnumAbilitiesDnd5E>()
            {
                EnumAbilitiesDnd5E.Dexterity,
                EnumAbilitiesDnd5E.Charisma
            };
        }
    }
}