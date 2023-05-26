namespace dnd_character_sheet
{
    public class ModuleCreateNewSpell
    {
        public static SpellBase CreateNewSpell()
        {
            SpellBase newSpell = new SpellDND5e();

            while (SpellsDataBaseDND5e.SpellsDB.ContainsKey(newSpell.Id))
            {
                newSpell.SetID();
            }

            Console.Clear();
            Console.WriteLine(LocalizationsStash.SelectedLocalization[EnumCreateNewSpell.Name] + "\n");
            newSpell.SetName(Console.ReadLine());

            Console.Clear();
            Console.WriteLine(LocalizationsStash.SelectedLocalization[EnumCreateNewSpell.Level] + "\n");
            newSpell.SetLevel(ConsoleInput.InputInt());

            Console.Clear();
            Console.WriteLine(LocalizationsStash.SelectedLocalization[EnumCreateNewSpell.ThisIsNewSpell] + "\n");
            Console.WriteLine("[" + newSpell.Level + "] " + newSpell.Name);
            Console.ReadKey();
            
            return newSpell;
        }
    }
}