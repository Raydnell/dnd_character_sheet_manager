namespace dnd_character_sheet
{
    public class SorcererClassDND5e : SheetClassBase
    {
        public SorcererClassDND5e()
        {
            Name = EnumClassesDnd5E.Sorcerer;
            HitDice = EnumDices.d8;
            SaveThrows = new List<EnumAbilitiesDnd5E>()
            {
                EnumAbilitiesDnd5E.Wisdom,
                EnumAbilitiesDnd5E.Charisma
            };
        }
    }
}