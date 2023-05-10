namespace dnd_character_sheet
{
    public class ClericClassDND5e : SheetClassBase
    {
        public ClericClassDND5e()
        {
            Name = EnumClassesDnd5E.Cleric;
            HitDice = 8;
            SaveThrows = new List<EnumAbilitiesDnd5E>()
            {
                EnumAbilitiesDnd5E.Wisdom,
                EnumAbilitiesDnd5E.Charisma
            };
        }
    }
}