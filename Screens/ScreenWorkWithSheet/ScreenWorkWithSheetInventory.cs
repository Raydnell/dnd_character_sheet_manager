namespace dnd_character_sheet
{
    public class ScreenWorkWithSheetInventory : IScreen
    {
        public void ShowScreen(ref CharacterSheetBase heroSheet)
        {
            Console.WriteLine("It's works!");
            Console.ReadKey();
        }
    }
}