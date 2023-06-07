namespace dnd_character_sheet
{
    public class DruidClassDND5e : SheetClassBase
    {
        public DruidClassDND5e()
        {
            Name = EnumClassesDnd5E.Druid;
            HitDice = EnumDices.d8;
            SaveThrows = new List<EnumAbilitiesDnd5E>()
            {
                EnumAbilitiesDnd5E.Intelligence,
                EnumAbilitiesDnd5E.Wisdom
            };
        }
    }
}