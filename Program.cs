namespace dnd_character_sheet
{
    class Program
    {
        static void Main(string[] args)
        {
            IScreen screen = new ScreenMain();
            Initialize startUp = new Initialize();

            startUp.Start();
            screen.ShowScreen();
        }
    }
}