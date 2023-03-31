namespace dnd_character_sheet
{
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
                Console.WriteLine(item);
            }
        }

        public void Print(Type value, bool orderNumber = true)
        {
            int number = 1;
            
            if(orderNumber)
            {
                var values = Enum.GetNames(value);
                foreach(var item in values)
                {
                    Console.WriteLine(number + " - " + item);
                    number++;
                }
            }
            else
            {
                var values = Enum.GetNames(value);
                foreach(var item in values)
                {
                    Console.WriteLine(item);
                }
            }
        }

        public void Clear()
        {
            Console.Clear();
        }

        public void Print(Dictionary<int, Item> value)
        {
            foreach(var item in value)
            {
                Console.WriteLine(item.Value.Name);
            }
        }
    }
}