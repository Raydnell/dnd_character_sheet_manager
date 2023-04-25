namespace dnd_character_sheet
{
    class Program
    {
        static void Main(string[] args)
        {
            ShowMenusCursor showMenusCursor = new ShowMenusCursor();
            Enum language;
            IScreen screen = new ScreenMain();
            CharacterSheetBase heroSheet = new CharacterSheetDnd5E();

            language = showMenusCursor.ShowMenuPoints(
                LocalizationsStash.StartScreenTitle,
                LocalizationsStash.StartScreenPoints,
                EnumLanguages.Russian,
                EnumStartMenuTitles.ChooseLang
            );
            
            screen.ShowScreen(ref heroSheet, language);
        }
    }
}