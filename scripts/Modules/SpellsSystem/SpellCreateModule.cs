namespace dnd_character_sheet
{
    public class SpellCreateModule
    {
        private SpellBase _newSpell;
        
        public SpellCreateModule()
        {
            _newSpell = new SpellDND5e();
        }

        public SpellBase CreateSpell()
        {
            Console.Clear();
            Console.WriteLine($"{LocalizationsStash.SelectedLocalization[EnumCreateNewSpell.WriteNewSpellName]}:\n");
            _newSpell.SetName(Console.ReadLine());

            Console.Clear();
            Console.WriteLine($"{LocalizationsStash.SelectedLocalization[EnumCreateNewSpell.WriteNewSpellLevel]}:\n");
            _newSpell.SetLevel(ConsoleInput.InputInt());

            _newSpell.SetID();
            while (SpellsDataBaseDND5e.SpellsDB.ContainsKey(_newSpell.Id))
            {
                _newSpell.SetID();
            }

            Console.Clear();
            Console.WriteLine(
                $"{LocalizationsStash.SelectedLocalization[EnumCreateNewSpell.NewSpellDescription]}:\n\n{LocalizationsStash.SelectedLocalization[EnumItemStatsDND5e.Name]}: {_newSpell.Name}\n{LocalizationsStash.SelectedLocalization[EnumPrintSheetInfoTitles.Level]}: {_newSpell.Level}\n{LocalizationsStash.SelectedLocalization[EnumCreateNewSpell.ID]}: {_newSpell.Id}"
            );

            return _newSpell;
        }
    }
}