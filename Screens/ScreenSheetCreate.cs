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
        private PrintSheetInfo _printSheetInfo;

        public ScreenSheetCreate() 
        {
            _jsonSaveLoad = new JsonSaveLoad();
            _sheetFactory = new CharacterSheetFactory();
            _userOutput = new ConsoleOutput();
            _userInput = new ConsoleInput();
            _input = string.Empty;
            _printSheetInfo = new PrintSheetInfo();
        }

        public CharacterSheetBase SheetCreate(CharacterSheetBase currentHeroSheet)
        {
            _userOutput.Clear();
            _userOutput.Print("Пришло время создать героя!\n");

            //Указание редакции
            currentHeroSheet = SetEdition();
            
            //Указание имени
            _userOutput.Clear();
            _userOutput.Print("Введите имя героя: ", false);
            currentHeroSheet.Name = _userInput.InputString();

            //Указание расы
            _userOutput.Clear();
            currentHeroSheet.SheetRace.SetRace(ChooseRace());
            _userOutput.Print("Выбранная раса: " + currentHeroSheet.SheetRace.Name);
            _userInput.InputKey();

            //Указание класса
            _userOutput.Clear();
            currentHeroSheet.SheetClass.SetClass(ChooseClass());
            _userOutput.Print("Выбранный класс: " + currentHeroSheet.SheetClass.Name);
            _userInput.InputKey();

            //Указание скилов
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

            //Указание характеристик
            _userOutput.Clear();
            _userOutput.Print("Впишите характеристики героя:");
            currentHeroSheet.SheetAbilities.SetAbilities(ChooseAbilities());

            //Указание владений
            SetUpProficiency(currentHeroSheet);

            //Указание скорости
            currentHeroSheet.SheetCombatAbilities.SetSpeed(GetRaceSpeed(currentHeroSheet.SheetRace.Name));

            //Распределение спасбросков
            currentHeroSheet.SheetSaveThrows.SetSaveTrows(currentHeroSheet.SheetClass.Name);

            //Указание HP
            currentHeroSheet.SheetCombatAbilities.SetMaximumHP(SetUpHeroHP(currentHeroSheet.SheetClass.Name, currentHeroSheet.SheetAbilities.GetAbilityModificator("constitution")));
            currentHeroSheet.SheetCombatAbilities.SetCurrentHP(currentHeroSheet.SheetCombatAbilities.MaximumHP);

            //Указание базового КД (без брони)
            currentHeroSheet.SheetCombatAbilities.SetArmorClass(10 + currentHeroSheet.SheetAbilities.GetAbilityModificator("dexterity"));

            //Указание инициативы
            currentHeroSheet.SheetCombatAbilities.SetInitiative(currentHeroSheet.SheetAbilities.GetAbilityModificator("dexterity"));

            //Указание кости хитов
            currentHeroSheet.SheetCombatAbilities.SetTotalHitDices(currentHeroSheet.SheetProgression.Level);
            currentHeroSheet.SheetCombatAbilities.SetCurrentHitDices(currentHeroSheet.SheetProgression.Level);
            currentHeroSheet.SheetCombatAbilities.SetHitDice(SetUpHeroHitDice(currentHeroSheet.SheetClass.Name));

            //Указание пассивной внимательности
            currentHeroSheet.SheetCombatAbilities.SetPassiveWisdom(
                SetUpPassiveWisdom(
                    currentHeroSheet.SheetAbilities.GetAbilityModificator("wisdom"),
                    currentHeroSheet.SheetProgression.GetProficiencyBonus(),
                    currentHeroSheet.SheetSkills.CheckSkill("perception")
                )
            );

            _userOutput.Clear();
            _userOutput.Print("Вот ваш новый герой!");
            _printSheetInfo.ShowSheetFields(currentHeroSheet);

            return currentHeroSheet;
        }

        private CharacterSheetBase SetEdition()
        {
            _isSet = false;
            while(_isSet == false)
            {
                _userOutput.Print("Укажите редакцию, по которой нужно создать лист персонажа:");
                _userOutput.Print(typeof(EnumEditions));

                _input = _userInput.InputString();
                if (Enum.TryParse<EnumEditions>(_input, out EnumEditions result))
                {
                    switch(result)
                    {
                        case EnumEditions.DND5E:
                            return _sheetFactory.CreateCharacterSheet(result.ToString());
                        
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

        private string ChooseSkills()
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
            Dictionary<string, bool> proficienies = new Dictionary<string, bool>()
            {
                ["SimpleMelee"] = false,
                ["SimpleRanged"] = false,
                ["MartialMelee"] = false,
                ["MartialRanged"] = false,
                ["Musician"] = false,
                ["Gaming"] = false,
                ["Instrument"] = false,
                ["Artisan"] = false,
                ["Armor"] = false,
            };

            var proficiencies = Enum.GetNames(typeof(EnumProficiencies));

            _isSet = false;
            while(_isSet == false)
            {
                _userOutput.Clear();
                _userOutput.Print("Укажите, какие владения нужно выбрать?");
                foreach(var item in proficiencies)
                {
                    _userOutput.Print(item);
                    _userOutput.Print("1 - да, 2 - нет");

                    _input = _userInput.InputString();
                    if(_input == "1")
                    {
                        proficienies[item] = true;
                    }
                }

                _isSet = true;
            }
            
            foreach(var item in proficienies)
            {
                if(item.Value == true)
                {
                    switch(item.Key)
                    {
                        case "SimpleMelee":
                            _isSet = false;
                            while(_isSet == false)
                            {
                                _userOutput.Clear();
                                _userOutput.Print("Каким простым ближним оружием владеет герой?");
                                _userOutput.Print(typeof(EnumSimpleMeleeProficienciesDND5E));
                                
                                _input = _userInput.InputString();
                                if(Enum.TryParse<EnumSimpleMeleeProficienciesDND5E>(_input, out EnumSimpleMeleeProficienciesDND5E result))
                                {
                                    heroSheet.SheetProficiencies.AddProficiency(result.ToString());
                                    _userOutput.Print("Владение добавлено, добавить ещё?");
                                    _userOutput.Print("1 - да.");
                                    _userOutput.Print("2 - нет.");

                                    _input = _userInput.InputString();
                                    if(_input == "2")
                                    {
                                        _isSet = true;
                                    }
                                }
                                else
                                {
                                    _userOutput.Print("Такого владения нет, попробуйте снова.");
                                }
                            }
                            break;

                        case "SimpleRanged":
                            _isSet = false;
                            while(_isSet == false)
                            {
                                _userOutput.Clear();
                                _userOutput.Print("Каким простым дальнобойным оружием владеет герой?");
                                _userOutput.Print(typeof(EnumSimpleRangedProficienciesDND5E));
                                
                                _input = _userInput.InputString();
                                if(Enum.TryParse<EnumSimpleRangedProficienciesDND5E>(_input, out EnumSimpleRangedProficienciesDND5E result))
                                {
                                    heroSheet.SheetProficiencies.AddProficiency(result.ToString());
                                    _userOutput.Print("Владение добавлено, добавить ещё?");
                                    _userOutput.Print("1 - да.");
                                    _userOutput.Print("2 - нет.");

                                    _input = _userInput.InputString();
                                    if(_input == "2")
                                    {
                                        _isSet = true;
                                    }
                                }
                                else
                                {
                                    _userOutput.Print("Такого владения нет, попробуйте снова.");
                                }
                            }
                            break;

                        case "MartialMelee":
                            _isSet = false;
                            while(_isSet == false)
                            {
                                _userOutput.Clear();
                                _userOutput.Print("Каким военным ближним оружием владеет герой?");
                                _userOutput.Print(typeof(EnumMartialMeleeProficienciesDND5E));
                                
                                _input = _userInput.InputString();
                                if(Enum.TryParse<EnumMartialMeleeProficienciesDND5E>(_input, out EnumMartialMeleeProficienciesDND5E result))
                                {
                                    heroSheet.SheetProficiencies.AddProficiency(result.ToString());
                                    _userOutput.Print("Владение добавлено, добавить ещё?");
                                    _userOutput.Print("1 - да.");
                                    _userOutput.Print("2 - нет.");

                                    _input = _userInput.InputString();
                                    if(_input == "2")
                                    {
                                        _isSet = true;
                                    }
                                }
                                else
                                {
                                    _userOutput.Print("Такого владения нет, попробуйте снова.");
                                }
                            }
                            break;

                        case "MartialRanged":
                            _isSet = false;
                            while(_isSet == false)
                            {
                                _userOutput.Clear();
                                _userOutput.Print("Каким военным дальнобойным оружием владеет герой?");
                                _userOutput.Print(typeof(EnumMartialRangedProficienciesDND5E));
                                
                                _input = _userInput.InputString();
                                if(Enum.TryParse<EnumMartialRangedProficienciesDND5E>(_input, out EnumMartialRangedProficienciesDND5E result))
                                {
                                    heroSheet.SheetProficiencies.AddProficiency(result.ToString());
                                    _userOutput.Print("Владение добавлено, добавить ещё?");
                                    _userOutput.Print("1 - да.");
                                    _userOutput.Print("2 - нет.");

                                    _input = _userInput.InputString();
                                    if(_input == "2")
                                    {
                                        _isSet = true;
                                    }
                                }
                                else
                                {
                                    _userOutput.Print("Такого владения нет, попробуйте снова.");
                                }
                            }
                            break;

                        case "Musician":
                            _isSet = false;
                            while(_isSet == false)
                            {
                                _userOutput.Clear();
                                _userOutput.Print("Какими музыкальными инструментами владеет герой?");
                                _userOutput.Print(typeof(EnumMusicalInstrumentProficienciesDND5E));
                                
                                _input = _userInput.InputString();
                                if(Enum.TryParse<EnumMusicalInstrumentProficienciesDND5E>(_input, out EnumMusicalInstrumentProficienciesDND5E result))
                                {
                                    heroSheet.SheetProficiencies.AddProficiency(result.ToString());
                                    _userOutput.Print("Владение добавлено, добавить ещё?");
                                    _userOutput.Print("1 - да.");
                                    _userOutput.Print("2 - нет.");

                                    _input = _userInput.InputString();
                                    if(_input == "2")
                                    {
                                        _isSet = true;
                                    }
                                }
                                else
                                {
                                    _userOutput.Print("Такого владения нет, попробуйте снова.");
                                }
                            }
                            break;

                        case "Gaming":
                            _isSet = false;
                            while(_isSet == false)
                            {
                                _userOutput.Clear();
                                _userOutput.Print("Какими игровыми наборами владеет герой?");
                                _userOutput.Print(typeof(EnumGamingSetProficienciesDND5E));
                                
                                _input = _userInput.InputString();
                                if(Enum.TryParse<EnumGamingSetProficienciesDND5E>(_input, out EnumGamingSetProficienciesDND5E result))
                                {
                                    heroSheet.SheetProficiencies.AddProficiency(result.ToString());
                                    _userOutput.Print("Владение добавлено, добавить ещё?");
                                    _userOutput.Print("1 - да.");
                                    _userOutput.Print("2 - нет.");

                                    _input = _userInput.InputString();
                                    if(_input == "2")
                                    {
                                        _isSet = true;
                                    }
                                }
                                else
                                {
                                    _userOutput.Print("Такого владения нет, попробуйте снова.");
                                }
                            }
                            break;

                        case "Instrument":
                            _isSet = false;
                            while(_isSet == false)
                            {
                                _userOutput.Clear();
                                _userOutput.Print("Какими простыми инструментами владеет герой?");
                                _userOutput.Print(typeof(EnumOrdinaryToolProficienciesDND5E));
                                
                                _input = _userInput.InputString();
                                if(Enum.TryParse<EnumOrdinaryToolProficienciesDND5E>(_input, out EnumOrdinaryToolProficienciesDND5E result))
                                {
                                    heroSheet.SheetProficiencies.AddProficiency(result.ToString());
                                    _userOutput.Print("Владение добавлено, добавить ещё?");
                                    _userOutput.Print("1 - да.");
                                    _userOutput.Print("2 - нет.");

                                    _input = _userInput.InputString();
                                    if(_input == "2")
                                    {
                                        _isSet = true;
                                    }
                                }
                                else
                                {
                                    _userOutput.Print("Такого владения нет, попробуйте снова.");
                                }
                            }
                            break;

                        case "Artisan":
                            _isSet = false;
                            while(_isSet == false)
                            {
                                _userOutput.Clear();
                                _userOutput.Print("Какими инструментами ремесленника владеет герой?");
                                _userOutput.Print(typeof(EnumArtisansToolsProficienciesDND5E));
                                
                                _input = _userInput.InputString();
                                if(Enum.TryParse<EnumArtisansToolsProficienciesDND5E>(_input, out EnumArtisansToolsProficienciesDND5E result))
                                {
                                    heroSheet.SheetProficiencies.AddProficiency(result.ToString());
                                    _userOutput.Print("Владение добавлено, добавить ещё?");
                                    _userOutput.Print("1 - да.");
                                    _userOutput.Print("2 - нет.");

                                    _input = _userInput.InputString();
                                    if(_input == "2")
                                    {
                                        _isSet = true;
                                    }
                                }
                                else
                                {
                                    _userOutput.Print("Такого владения нет, попробуйте снова.");
                                }
                            }
                            break;

                        case "Armor":
                            _isSet = false;
                            while(_isSet == false)
                            {
                                _userOutput.Clear();
                                _userOutput.Print("Какую броню умеет носить герой?");
                                _userOutput.Print(typeof(EnumArmorProficienciesDND5E));
                                
                                _input = _userInput.InputString();
                                if(Enum.TryParse<EnumArmorProficienciesDND5E>(_input, out EnumArmorProficienciesDND5E result))
                                {
                                    heroSheet.SheetProficiencies.AddProficiency(result.ToString());
                                    _userOutput.Print("Владение добавлено, добавить ещё?");
                                    _userOutput.Print("1 - да.");
                                    _userOutput.Print("2 - нет.");

                                    _input = _userInput.InputString();
                                    if(_input == "2")
                                    {
                                        _isSet = true;
                                    }
                                }
                                else
                                {
                                    _userOutput.Print("Такого владения нет, попробуйте снова.");
                                }
                            }
                            break;
                    }
                }
            }
        }
    }
}
