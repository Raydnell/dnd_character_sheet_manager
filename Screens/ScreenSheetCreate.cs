namespace dnd_character_sheet
{
    public class ScreenSheetCreate
    {
        private int _choosenPoint;
        
        private string _input;

        private bool _pointChoose;
        private bool _isSet;

        private JsonSaveLoad _jsonSaveLoad;
        private CharacterSheetFactory _sheetFactory;
        private IUserOutput _userOutput;
        private IUserInput _userInput;

        public ScreenSheetCreate() 
        {
            _jsonSaveLoad = new JsonSaveLoad();
            _sheetFactory = new CharacterSheetFactory();
            _userOutput = new ConsoleOutput();
            _userInput = new ConsoleInput();
            _input = string.Empty;
        }

        public CharacterSheetBase SheetCreate(CharacterSheetBase currentHeroSheet)
        {
            _userOutput.Clear();
            _userOutput.Print("Пришло время создать героя!\n");
            _userOutput.Print("Выбери редакцию из списка:");

            currentHeroSheet = SetEdition();
            
            _userOutput.Clear();
            _userOutput.Print("Введите имя героя: ");
            currentHeroSheet.Name = _userInput.InputString();

            _userOutput.Clear();
            currentHeroSheet.SetRace(ChooseRace());
            _userOutput.Print("Выбранная раса: " + currentHeroSheet.SheetRace.Name);
            _userInput.InputKey();

            _userOutput.Clear();
            currentHeroSheet.SetClass(ChooseClass());
            currentHeroSheet.SheetSaveThrows.SetSaveTrows(currentHeroSheet.SheetClass.Name);
            _userOutput.Print("Выбранный класс: " + currentHeroSheet.SheetClass.Name);
            _userInput.InputKey();

            _isSet = false;
            while(_isSet == false)
            {
                _userOutput.Clear();
                currentHeroSheet.SheetSkills.AddSkill(ChooseSkills());

                _userOutput.Print("Добавить ещё навыки? 1 - да, 2 - нет");
                _input = _userInput.InputString();
                if (_input == "1")
                {
                    _isSet = false;
                }
                else
                {
                    _isSet = true;
                }
            }

            _userOutput.Clear();
            _userOutput.Print("Впишите характеристики героя:");
            currentHeroSheet.SheetAbilities.SetAbilities(ChooseAbilities());

            _userOutput.Clear();
            _userOutput.Print("Вот ваш новый герой!\n");
            _userOutput.Print(currentHeroSheet.Name);
            _userOutput.Print(currentHeroSheet.SheetRace.Name);
            _userOutput.Print(currentHeroSheet.SheetClass.Name);
            _userOutput.Print(currentHeroSheet.SheetAbilities.GetAbilities());
            _userOutput.Print(currentHeroSheet.SheetSkills.GetSkills());
            _userOutput.Print(currentHeroSheet.SheetSaveThrows.GetSaveThrows());
            _userInput.InputKey();

            return currentHeroSheet;
        }

        private CharacterSheetBase SetEdition()
        {
            _isSet = false;
            while(_isSet == false)
            {
                _userOutput.Print("Укажите редакцию, по которой нужно создать лист персонажа:");
                
                foreach (var item in Enum.GetValues(typeof(EnumEditions)))
                {
                    _userOutput.Print((int)item + " - ", false);
                    _userOutput.Print(item + "\n", false);
                }

                _userOutput.Print(typeof(EnumEditions));

                Enum.GetNames<EnumEditions>();

                _input = Console.ReadLine();
                if (Enum.TryParse<EnumEditions>(_input, out EnumEditions result))
                {
                    switch(result)
                    {
                        case EnumEditions.Dnd5E:
                            return _sheetFactory.CreateCharacterSheet(Convert.ToString(result));
                        
                        default:
                            break;
                    }

                    _isSet = true;
                }
                
                return null;
            }

            return null;
        }

        private string ChooseRace()
        {
            _isSet = false;
            while(_isSet == false)
            {
                _userOutput.Print("Выберите расу из списка:");
                _userOutput.Print(typeof(EnumRacesDnd5E));

                _input = _userInput.InputString();
                if (Enum.TryParse<EnumRacesDnd5E>(_input, out EnumRacesDnd5E result))
                {
                    return result.ToString();
                }

                return string.Empty;
            }

            return string.Empty;
        }

        private string ChooseClass()
        {
            _isSet = false;
            while(_isSet == false)
            {
                _userOutput.Print("Выберите класс из списка:");
                _userOutput.Print(typeof(EnumClassesDnd5E));

                _input = _userInput.InputString();
                if (Enum.TryParse<EnumClassesDnd5E>(_input, out EnumClassesDnd5E result))
                {
                    return result.ToString();
                }

                return string.Empty;
            }

            return string.Empty;
        }

        private string? ChooseSkills()
        {
            bool isSet = false;
            while(isSet == false)
            {
                _userOutput.Print("Выберите навык из списка:");
                _userOutput.Print(typeof(EnumSkillsDnd5E));

                _input = _userInput.InputString();
                if (Enum.TryParse<EnumSkillsDnd5E>(_input, out EnumSkillsDnd5E result))
                {
                    return result.ToString();
                }

                return string.Empty;
            }

            return string.Empty;
        }

        private Dictionary<string, int> ChooseAbilities()
        {
            Dictionary<string, int> tempAbilities = new Dictionary<string, int>();
            int inputAbility;
            
            foreach (var item in Enum.GetValues(typeof(EnumAbilitiesDnd5E)))
            {
                _isSet = false;
                while(_isSet == false)
                {
                    _userOutput.Print(item.ToString() + ": ", false);
                    inputAbility = _userInput.InputInt();
                    if(inputAbility > 0 || inputAbility <= 20)
                    {
                        tempAbilities[item.ToString()] = inputAbility;
                        _isSet = true;
                    }
                    else
                    {
                        _userOutput.Print("Нужно указать значение от 1 до 20");
                        _userInput.InputKey();
                    }
                }
            }

            return tempAbilities;
        }
    }
}
