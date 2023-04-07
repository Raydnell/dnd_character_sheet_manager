namespace dnd_character_sheet
{
    public class ScreenSheetCreate : IScreen
    {
        private int _choosenPoint;
        private int _inputInt;
        
        private string _inputString;

        private bool _pointChoose;
        private bool _isSet;

        private JsonSaveLoad _jsonSaveLoad;
        private CharacterSheetFactory _sheetFactory;
        private IUserOutput _userOutput;
        private IUserInput _userInput;
        private PrintSheetInfo _printSheetInfo;

        public ScreenSheetCreate() 
        {
            _jsonSaveLoad = new JsonSaveLoad();
            _sheetFactory = new CharacterSheetFactory();
            _userOutput = new ConsoleOutput();
            _userInput = new ConsoleInput();
            _inputString = string.Empty;
            _printSheetInfo = new PrintSheetInfo();
        }

        public void ShowScreen(ref CharacterSheetBase heroSheet)
        {
            _userOutput.Clear();
            _userOutput.Print("Пришло время создать героя!\n");
            _userInput.InputKey();

            //Указание редакции
            _userOutput.Clear();
            _userOutput.Print("Укажите редакцию, по которой нужно создать лист персонажа:");
            heroSheet = _sheetFactory.CreateCharacterSheet(ChooseFromEnum(typeof(EnumEditions)));
            
            //Указание имени
            _userOutput.Clear();
            _userOutput.Print("Введите имя героя: ", false);
            heroSheet.Name = _userInput.InputString();

            //Указание расы
            _userOutput.Clear();
            _userOutput.Print("Выберите расу из списка:");
            heroSheet.SheetRace.SetRace(ChooseFromEnum(typeof(EnumRacesDnd5E)));
            _userOutput.Print("Выбранная раса: " + heroSheet.SheetRace.Name);
            _userInput.InputKey();

            //Указание класса
            _userOutput.Clear();
            _userOutput.Print("Выберите класс из списка:");
            heroSheet.SheetClass.SetClass(ChooseFromEnum(typeof(EnumClassesDnd5E)));
            _userOutput.Print("Выбранный класс: " + heroSheet.SheetClass.Name);
            _userInput.InputKey();

            //Указание скилов
            _isSet = false;
            while(_isSet == false)
            {
                _userOutput.Clear();
                _userOutput.Print("Выберите навык из списка:");
                heroSheet.SheetSkills.AddSkill(ChooseFromEnum(typeof(EnumSkillsDnd5E)));

                _userOutput.Print("Добавить ещё навыки? 1 - да, 2 - нет");
                _inputString = _userInput.InputString();
                if (_inputString == "1")
                {
                    _isSet = false;
                }
                else
                {
                    _isSet = true;
                }
            }

            //Указание характеристик
            _userOutput.Clear();
            _userOutput.Print("Впишите характеристики героя:");
            heroSheet.SheetAbilities.SetAbilities(ChooseAbilities());

            //Указание владений
            SetUpProficiency(heroSheet);

            //Указание скорости
            heroSheet.SheetCombatAbilities.SetSpeed(GetRaceSpeed(heroSheet.SheetRace.Name));

            //Распределение спасбросков
            heroSheet.SheetSaveThrows.SetSaveTrows(heroSheet.SheetClass.Name);

            //Указание HP
            heroSheet.SheetCombatAbilities.SetMaximumHP(SetUpHeroHP(heroSheet.SheetClass.Name, heroSheet.SheetAbilities.GetAbilityModificator("constitution")));
            heroSheet.SheetCombatAbilities.SetCurrentHP(heroSheet.SheetCombatAbilities.MaximumHP);

            //Указание базового КД (без брони)
            heroSheet.SheetCombatAbilities.SetArmorClass(10 + heroSheet.SheetAbilities.GetAbilityModificator("dexterity"));

            //Указание инициативы
            heroSheet.SheetCombatAbilities.SetInitiative(heroSheet.SheetAbilities.GetAbilityModificator("dexterity"));

            //Указание кости хитов
            heroSheet.SheetCombatAbilities.SetTotalHitDices(heroSheet.SheetProgression.Level);
            heroSheet.SheetCombatAbilities.SetCurrentHitDices(heroSheet.SheetProgression.Level);
            heroSheet.SheetCombatAbilities.SetHitDice(SetUpHeroHitDice(heroSheet.SheetClass.Name));

            //Указание пассивной внимательности
            heroSheet.SheetCombatAbilities.SetPassiveWisdom(
                SetUpPassiveWisdom(
                    heroSheet.SheetAbilities.GetAbilityModificator("wisdom"),
                    heroSheet.SheetProgression.GetProficiencyBonus(),
                    heroSheet.SheetSkills.CheckSkill("perception")
                )
            );

            _userOutput.Clear();
            _userOutput.Print("Вот ваш новый герой!");
            _printSheetInfo.ShowSheetFields(heroSheet);
            _userInput.InputKey();
        }

        private string ChooseFromEnum(Type enumItems)
        {
            _userOutput.Print(enumItems);
            string[] enumNames = enumItems.GetEnumNames();

            _isSet = false;
            while(_isSet == false)
            {
                _inputInt = _userInput.InputInt();
                if(enumNames[_inputInt - 1] != null)
                {
                    return enumNames[_inputInt - 1];
                }
                else
                {
                    _userOutput.Print("Неверный ввод, повторите попытку");
                    _userInput.InputKey();
                }
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
                    if(inputAbility > 0 && inputAbility <= 20)
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

        private int GetRaceSpeed(string race)
        {
            switch(race)
            {
                case "gnome":
                case "dwarf":
                case "halfling":
                    return 25;
                
                case "dragonborn":
                case "halforc":
                case "halfelf":
                case "tiefling":
                case "human":
                case "elf":
                    return 30;

                default:
                    return 30;
            }
        }

        private int SetUpHeroHP(string sheetClass, int constitutionMod)
        {
            switch(sheetClass)
            {
                default:
                case "sorcerer":
                case "wizard":
                    return 6 + constitutionMod;

                case "bard":
                case "cleric":
                case "druid":
                case "monk":
                case "rogue":
                case "warlock":
                    return 8 + constitutionMod;
                
                case "fighter":
                case "paladin":
                case "ranger":
                    return 10 + constitutionMod;
                
                case "barbarian":
                    return 12 + constitutionMod;
            }
        }

        private int SetUpPassiveWisdom(int wisdomModificator, int perceptionModificator, bool havePerception)
        {
            if(havePerception)
            {
                return 10 + wisdomModificator + perceptionModificator;
            }
            else
            {
                return 10 + wisdomModificator;
            }
        }

        private int SetUpHeroHitDice(string sheetClass)
        {
            switch(sheetClass)
            {
                default:
                case "sorcerer":
                case "wizard":
                    return 6;

                case "bard":
                case "cleric":
                case "druid":
                case "monk":
                case "rogue":
                case "warlock":
                    return 8;
                
                case "fighter":
                case "paladin":
                case "ranger":
                    return 10;
                
                case "barbarian":
                    return 12;
            }
        }

        private void SetUpProficiency(CharacterSheetBase heroSheet)
        {
            List<Type> choosenProficiencies = new List<Type>();
            
            _userOutput.Clear();
            _userOutput.Print("Выберите группы владений, из которых будут выбираться владения");

            foreach(var prof in ProficiencyGroups.ProficienciesGroups)
            {
                _userOutput.Print("Нужны ли владения из этой группы?\n\n" + prof.ToString() + "\n\n 1 - да, 2 - нет");

                _inputString = _userInput.InputString();
                if(_inputString == "1")
                {
                    choosenProficiencies.Add(prof);
                    _userOutput.Print("Группа владений " + prof + " добавлена к выбору.");
                    _userInput.InputKey();
                }
            }

            if(choosenProficiencies.Count > 0)
            {
                foreach(var item in choosenProficiencies)
                {
                    _isSet = false;
                    while(_isSet == false) 
                    {
                        var values = Enum.GetNames(item);
                        
                        _userOutput.Clear();
                        _userOutput.Print("Какие владения нужно добавить:\n");
                        _userOutput.Print(item);

                        int _inputStringInt = _userInput.InputInt();
                        string valuesItem = values[_inputStringInt - 1];

                        if(valuesItem != null)
                        {
                            heroSheet.SheetProficiencies.AddProficiency(valuesItem);
                            _userOutput.Print("Добавлено владение " + valuesItem);
                            _userOutput.Print("Нужно ли добавить ещё владение из этого списка?\n\n1 - да, 2 - нет");

                            _inputString = _userInput.InputString();
                            if(_inputString != "1")
                            {
                                _isSet = true;
                            }
                        }
                        else
                        {
                            _userOutput.Print("Введён несуществующий пункт, повторите попытку");
                            _userInput.InputKey();
                        }
                    }
                }
            }
        }
    }
}
