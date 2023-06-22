namespace dnd_character_sheet
{
    class Program
    {
        static void Main(string[] args)
        {
            ShowMenusCursor showMenusCursor = new ShowMenusCursor();
            Enum language;
            IScreen screen = new ScreenMain();
            LocalizationsStash localizationsStash = new LocalizationsStash();

            //Если ломается кодировка
            //Console.InputEncoding = System.Text.Encoding.UTF8;
            //Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.SetWindowSize(140, 50);

            language = showMenusCursor.ShowMenuPoints(
                EnumStartMenuTitles.ChooseLang,
                typeof(EnumLanguages)
            );

            localizationsStash.SetUpLanguage(language);
            ItemsDataBaseDND5e.LoadItemsBase();
            SpellsDataBaseDND5e.LoadDB();
            
            screen.ShowScreen();
        }
    }
}