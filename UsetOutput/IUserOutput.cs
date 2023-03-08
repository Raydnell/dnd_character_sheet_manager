public interface IUserOutput
{
    public void Print(string value, bool transfer = true);
    public void Print(int value, bool transfer = true);
    public void Print(Dictionary<string, int> value);
    public void Print(Dictionary<string, bool> value);
    public void Print(Type value);
    public void Clear();
}