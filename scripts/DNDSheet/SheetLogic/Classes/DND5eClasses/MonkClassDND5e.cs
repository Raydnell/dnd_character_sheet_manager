namespace dnd_character_sheet
{
    public class MonkClassDND5e : SheetClassBase
    {
        public MonkClassDND5e()
        {
            Name = EnumClassesDnd5E.Monk;
            HitDice = 8;
            SaveThrows = new List<EnumAbilitiesDnd5E>()
            {
                EnumAbilitiesDnd5E.Dexterity,
                EnumAbilitiesDnd5E.Strength
            };
        }
    }
}