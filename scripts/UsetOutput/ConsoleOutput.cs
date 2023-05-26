namespace dnd_character_sheet
{
    public class ConsoleOutput
    {
        public static void Print(Dictionary<string, int> value)
        {
            foreach(var item in value)
            {
                Console.WriteLine(item);
            }
        }

        public static void Print(Dictionary<string, bool> value)
        {
            foreach(var item in value)
            {
                Console.WriteLine(item);
            }
        }

        public static void Print(Type value, bool orderNumber = true)
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

        public static void Print(List<string> value)
        {
            foreach(var item in value)
            {
                Console.WriteLine(item);
            }
        }

        public static void Print(Dictionary<string, string> value)
        {
            foreach(var item in value)
            {
                Console.WriteLine(item.Key + " - " + item.Value);
            }
        }

        public static void Print(Dictionary<string, string>.KeyCollection value)
        {
            foreach(string item in value)
            {
                Console.WriteLine(item);
            }
        }

        public static void Print(Dictionary<EnumAbilitiesDnd5E, int> value)
        {
            foreach(var item in value)
            {
                Console.WriteLine(LocalizationsStash.SelectedLocalization[item.Key] + ": " + item.Value);
            }
        }

        public static void Print(List<EnumSkillsDnd5E> value)
        {
            foreach (var item in value)
            {
                Console.WriteLine(LocalizationsStash.SelectedLocalization[item]);
            }
        }

        public static void Print(List<EnumAllDND5eProficiencies> value)
        {
            foreach (var item in value)
            {
                Console.WriteLine(LocalizationsStash.SelectedLocalization[item]);
            }
        }

        public static void Print(Dictionary<EnumPersonalitiesDND5E, string> value)
        {
            foreach(var item in value)
            {
                Console.WriteLine(LocalizationsStash.SelectedLocalization[item.Key] + ": " + item.Value);
            }
        }

        public static void Print(Dictionary<string, TraitBase> value)
        {
            foreach (var item in value)
            {
                Console.WriteLine(item.Value.Name);
                Console.WriteLine(item.Value.Source);
                Console.WriteLine(item.Value.Description + "\n");
            }
        }

        public static void PrintInventory(Dictionary<int, int> inventory)
        {
            foreach (var item in inventory)
            {
                Console.WriteLine(ItemsDataBaseDND5e.ItemsDB[item.Key].Name + ": " + item.Value);
            }
        }
    }
}