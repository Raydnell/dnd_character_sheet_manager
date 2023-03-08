public class ConsoleOutput : IUserOutput
{
    public void Print(string value, bool transfer = true)
    {
        if(transfer)
        {
            Console.WriteLine(value);
        }
        else
        {
            Console.Write(value);
        }
    }

    public void Print(int value, bool transfer = true)
    {
        if(transfer)
        {
            Console.WriteLine(value);
        }
        else
        {
            Console.Write(value);
        }
    }

    public void Print(Dictionary<string, int> value)
    {
        foreach(var item in value)
        {
            Console.WriteLine(item);
        }
    }

    public void Print(Dictionary<string, bool> value)
    {
        foreach(var item in value)
        {
            Console.WriteLine(value);
        }
    }

    public void Print(Type value)
    {
        var values = Enum.GetNames(value);
        foreach(var item in values)
        {
            Console.WriteLine(item);
        }
    }

    public void Clear()
    {
        Console.Clear();
    }
}