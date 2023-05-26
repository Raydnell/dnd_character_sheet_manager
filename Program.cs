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

            //Console.InputEncoding = System.Text.Encoding.UTF8;
            //Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.SetWindowSize(200, 50);

            language = showMenusCursor.ShowMenuPoints(
                EnumStartMenuTitles.ChooseLang,
                typeof(EnumLanguages)
            );

            localizationsStash.SetUpLanguage(language);
            ItemsDataBaseDND5e.LoadItemsBase();
            SpellsDataBaseDND5e.LoadDB();
            //выбор редакции, но т.к. она сейчас одна, поэтому и выбора нет
            
            screen.ShowScreen();
        }
    }
}