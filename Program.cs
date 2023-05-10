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
            LocalizationsStash localizationsStash = new LocalizationsStash();

            language = showMenusCursor.ShowMenuPoints(
                EnumStartMenuTitles.ChooseLang,
                typeof(EnumLanguages)
            );

            localizationsStash.SetUpLanguage(language);
            ItemsDataBaseDND5e.LoadItemsBase();
            
            screen.ShowScreen(ref heroSheet);
        }
    }
}