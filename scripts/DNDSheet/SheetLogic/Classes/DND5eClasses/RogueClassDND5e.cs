namespace dnd_character_sheet
{
    public class RogueClassDND5e : SheetClassBase
    {
        public RogueClassDND5e()
        {
            Name = EnumClassesDnd5E.Rogue;
            HitDice = EnumDices.d8;
            SaveThrows = new List<EnumAbilitiesDnd5E>()
            {
                EnumAbilitiesDnd5E.Dexterity,
                EnumAbilitiesDnd5E.Intelligence
            };
        }
    }
}