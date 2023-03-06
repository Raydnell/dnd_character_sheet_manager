namespace dnd_character_sheet
{
    public class ScreenSheetCreate
    {
        private int _choosenPoint;
        private bool _pointChoose;
        private JsonSaveLoad _jsonSaveLoad;
        private CheckInput _checkInput;

        private string? _input;

        private bool _isSet;

        private CharacterSheetFactory _sheetFactory;
        private IUserOutput _userOutput;

        public ScreenSheetCreate() 
        {
            _choosenPoint = 0;
            _pointChoose = false;
            _jsonSaveLoad = new JsonSaveLoad();
            _checkInput = new CheckInput();
            _sheetFactory = new CharacterSheetFactory();
            _userOutput = new ConsoleOutput();
        }

        public CharacterSheetBase SheetCreate(CharacterSheetBase currentHeroSheet)
        {
            Console.Clear();
            Console.WriteLine("Пришло время создать героя!\n");
            Console.WriteLine("Выбери редакцию из списка:");

            currentHeroSheet = SetEdition();
            
            Console.Clear();
            Console.Write("Введите имя героя: ");
            currentHeroSheet.SetName(Console.ReadLine());

            Console.Clear();
            currentHeroSheet.SetRace(ChooseRace());
            Console.WriteLine("Выбранная раса: " + currentHeroSheet.GetRace().GetName());
            Console.ReadKey();

            Console.Clear();
            currentHeroSheet.SetClass(ChooseClass());
            currentHeroSheet.GetSaveThrows().SetSaveTrows(currentHeroSheet.GetClass().GetName());
            Console.WriteLine("Выбранный класс: " + currentHeroSheet.GetClass().GetName());
            Console.ReadKey();

            Console.Clear();
            _isSet = false;
            while(_isSet == false)
            {
                Console.Clear();
                currentHeroSheet.GetSkills().AddSkill(ChooseSkills());

                Console.WriteLine("Добавить ещё навыки? 1 - да, 2 - нет");
                _input = Console.ReadLine();
                if (_input == "1")
                {
                    _isSet = false;
                }
                else
                {
                    _isSet = true;
                }
            }

            Console.Clear();
            Console.WriteLine("Впишите характеристики героя:");
            currentHeroSheet.GetAbilities().SetAbilities(ChooseAbilities());

            Console.Clear();
            Console.WriteLine("Вот ваш новый герой!\n");
            Console.WriteLine(currentHeroSheet.GetName());
            Console.WriteLine(currentHeroSheet.GetRace().GetName());
            Console.WriteLine(currentHeroSheet.GetClass().GetName());
            PrintContainerItems(currentHeroSheet.GetAbilities().GetAbilities());
            PrintContainerItems(currentHeroSheet.GetSkills().GetSkills());
            PrintContainerItems(currentHeroSheet.GetSaveThrows().GetSaveThrows());
            Console.ReadKey();

            return currentHeroSheet;
        }

        private CharacterSheetBase SetEdition()
        {
            _isSet = false;
            while(_isSet == false)
            {
                Console.WriteLine("Укажите редакцию, по которой нужно создать лист персонажа:");
                
                foreach (var item in Enum.GetValues(typeof(EnumEditions)))
                {
                    Console.Write((int)item + " - ");
                    Console.Write(item + "\n");
                }

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

        private string? ChooseRace()
        {
            _isSet = false;
            while(_isSet == false)
            {
                Console.WriteLine("Выберите расу из списка:");
                foreach (var item in Enum.GetValues(typeof(EnumRacesDnd5E)))
                {
                    Console.Write((int)item + " - ");
                    Console.Write(item + "\n");
                }

                _input = Console.ReadLine();
                if (Enum.TryParse<EnumRacesDnd5E>(_input, out EnumRacesDnd5E result))
                {
                    return Convert.ToString(result);
                }

                return null;
            }

            return null;
        }

        private string? ChooseClass()
        {
            _isSet = false;
            while(_isSet == false)
            {
                Console.WriteLine("Выберите класс из списка:");
                foreach (var item in Enum.GetValues(typeof(EnumClassesDnd5E)))
                {
                    Console.Write((int)item + " - ");
                    Console.Write(item + "\n");
                }

                _input = Console.ReadLine();
                if (Enum.TryParse<EnumClassesDnd5E>(_input, out EnumClassesDnd5E result))
                {
                    return Convert.ToString(result);
                }

                return null;
            }

            return null;
        }

        private string? ChooseSkills()
        {
            bool isSet = false;
            while(isSet == false)
            {
                Console.WriteLine("Выберите навык из списка:");
                foreach (var item in Enum.GetValues(typeof(EnumSkillsDnd5E)))
                {
                    Console.Write((int)item + " - ");
                    Console.Write(item + "\n");
                }

                _input = Console.ReadLine();
                if (Enum.TryParse<EnumSkillsDnd5E>(_input, out EnumSkillsDnd5E result))
                {
                    return Convert.ToString(result);
                }

                return null;
            }

            return null;
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
                    inputAbility = _checkInput.CheckIntInput();
                    if(inputAbility > 0 || inputAbility <= 20)
                    {
                        tempAbilities[Convert.ToString(item)] = inputAbility;
                        _isSet = true;
                    }
                    else
                    {
                        Console.WriteLine("Нужно указать значение от 1 до 20");
                        Console.ReadKey();
                    }
                }
            }

            return tempAbilities;
        }

        private void PrintContainerItems(Dictionary<string, int> container)
        {
            foreach(var item in container)
            {
                Console.WriteLine(item);
            }

        }

        private void PrintContainerItems(Dictionary<string, bool> container)
        {
            foreach(var item in container)
            {
                Console.WriteLine(item);
            }

        }
    }
}
