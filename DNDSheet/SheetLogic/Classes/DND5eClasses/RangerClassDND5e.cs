namespace dnd_character_sheet
{
    public class RangerClassDND5e : SheetClassBase
    {
        public RangerClassDND5e()
        {
            Name = EnumClassesDnd5E.Ranger;
            HitDice = 10;
            SaveThrows = new List<EnumAbilitiesDnd5E>()
            {
                EnumAbilitiesDnd5E.Dexterity,
                EnumAbilitiesDnd5E.Strength
            };
        }
    }
}