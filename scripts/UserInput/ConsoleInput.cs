public class ConsoleInput : IUserInput
{
    public string InputString()
    {
        return Console.ReadLine();
    }

    public int InputInt()
    {
        string consoleInput = Console.ReadLine();
        if (int.TryParse(consoleInput, out int inputInt))
        {
            return inputInt;
        }
        else
        {
            return 0;
        }
    }

    public void InputKey()
    {
        Console.ReadKey();
    }
}