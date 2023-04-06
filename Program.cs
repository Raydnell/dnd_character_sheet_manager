namespace dnd_character_sheet
{
    class Program
    {
        static void Main(string[] args)
        {
            IScreen screen = new ScreenMain();
            CharacterSheetBase characterSheetBase = null;

            screen.ShowScreen(characterSheetBase);
        }
    }
}