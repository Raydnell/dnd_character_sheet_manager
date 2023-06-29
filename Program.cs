namespace dnd_character_sheet
{
    class Program
    {
        static void Main(string[] args)
        {
            IScreen screen = new ScreenMain();
            Initialize startUp = new Initialize();

            try
            {
                startUp.Start();
                screen.ShowScreen();
            }
            catch (Exception error)
            {
                Console.Clear();
                Console.WriteLine("Some error happen, restart program.");
                Console.WriteLine("\nError message:\n");
                Console.WriteLine(error);
                Console.ReadLine();
            }
        }
    }
}