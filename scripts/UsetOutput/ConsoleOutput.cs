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

        public void Print(List<string> value)
        {
            foreach(var item in value)
            {
                Console.WriteLine(item);
            }
        }

        public void Print(Dictionary<string, string> value)
        {
            foreach(var item in value)
            {
                Console.WriteLine(item.Key + " - " + item.Value);
            }
        }

        public void Print(Dictionary<string, string>.KeyCollection value)
        {
            foreach(string item in value)
            {
                Console.WriteLine(item);
            }
        }

        public void Print(Dictionary<EnumAbilitiesDnd5E, int> value)
        {
            foreach(var item in value)
            {
                Console.WriteLine(LocalizationsStash.SelectedLocalization[item.Key] + ": " + item.Value);
            }
        }

        public void Print(List<EnumSkillsDnd5E> value)
        {
            foreach (var item in value)
            {
                Console.WriteLine(LocalizationsStash.SelectedLocalization[item]);
            }
        }

        public void Print(List<EnumAllDND5eProficiencies> value)
        {
            foreach (var item in value)
            {
                Console.WriteLine(LocalizationsStash.SelectedLocalization[item]);
            }
        }

        public void Print(Dictionary<EnumPersonalitiesDND5E, string> value)
        {
            foreach(var item in value)
            {
                Console.WriteLine(LocalizationsStash.SelectedLocalization[item.Key] + ": " + item.Value);
            }
        }

        public void Print(Dictionary<string, TraitBase> value)
        {
            foreach (var item in value)
            {
                Console.WriteLine(item.Value.Name);
                Console.WriteLine(item.Value.Source);
                Console.WriteLine(item.Value.Description + "\n");
            }
        }

        public void PrintInventory(Dictionary<int, int> inventory)
        {
            foreach (var item in inventory)
            {
                Console.WriteLine(ItemsDataBaseDND5e.ItemsDB[item.Key].Name + ": " + item.Value);
            }
        }
    }
}