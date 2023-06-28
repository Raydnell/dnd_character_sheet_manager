namespace dnd_character_sheet
{
    public class TraitCreateModule
    {
        private TraitBase _newTrait;

        public TraitCreateModule()
        {
            _newTrait = new TraitDND5e();
        }

        public TraitBase CreateNew()
        {
            Console.Clear();
            Console.WriteLine($"{LocalizationsStash.SelectedLocalization[EnumTraitsText.ChooseName]}:\n");
            _newTrait.SetName(Console.ReadLine());

            Console.Clear();
            Console.WriteLine($"{LocalizationsStash.SelectedLocalization[EnumTraitsText.ChooseSource]}:\n");
            _newTrait.SetSource(Console.ReadLine());

            Console.Clear();
            Console.WriteLine($"{LocalizationsStash.SelectedLocalization[EnumTraitsText.ChooseLevelObtained]}:\n");
            _newTrait.SetLevel(ConsoleInput.InputInt());

            Console.Clear();
            Console.WriteLine($"{LocalizationsStash.SelectedLocalization[EnumTraitsText.ChooseDescription]}:\n");
            _newTrait.SetDescription(Console.ReadLine());

            while (TraitsDataBaseDND5e.TraitsDB.ContainsKey(_newTrait.Id))
            {
                _newTrait.SetID();
            }

            Console.Clear();
            Console.WriteLine($"{LocalizationsStash.SelectedLocalization[EnumTraitsText.ThisIsNewTrait]}!\n");
            Console.WriteLine($"{LocalizationsStash.SelectedLocalization[EnumItemStatsDND5e.Name]}: {_newTrait.Name}");
            Console.WriteLine($"{LocalizationsStash.SelectedLocalization[EnumPrintSheetInfoTitles.Level]}: {_newTrait.LevelGained}");
            Console.WriteLine($"{LocalizationsStash.SelectedLocalization[EnumTraitsText.Source]}: {_newTrait.Source}");
            Console.WriteLine($"{LocalizationsStash.SelectedLocalization[EnumItemStatsDND5e.Description]}: {_newTrait.Description}");
            Console.WriteLine($"{LocalizationsStash.SelectedLocalization[EnumTraitsText.NewIdTrait]}: {_newTrait.Id}");

            Console.ReadLine();
            return _newTrait;
        }
    }
}