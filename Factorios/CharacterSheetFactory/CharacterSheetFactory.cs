namespace dnd_character_sheet
{
    public class CharacterSheetFactory
    {
        public CharacterSheetBase CreateCharacterSheet(string edition)
        {
            switch(edition)
            {
                case "DND5E":
                    return new CharacterSheetDnd5E();
                default:
                    return null;
            }
        }
    }
}
