namespace dnd_character_sheet
{
    public class CharacterSheetFactory
    {
        public CharacterSheetBase? CreateCharacterSheet(string edition)
        {
            if(edition == "Dnd5E")
            {
                return new CharacterSheetDnd5E();
            }
            else
            {
                return null;
            }
        }
    }
}
