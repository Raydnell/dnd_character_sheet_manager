namespace dnd_character_sheet
{
    public class CharacterSheetDnd5E
    {
        private string _name;
        private string _input;

        private int _level;
        private int _expirience;

        private bool _isSet;

        private Dictionary<string, int> _abilities;
        private Dictionary<string, bool> _saveThrows;
        private Dictionary<string, bool> _skills;

        private IClassDnd5E _classDnd5E;
        private IRaceDnd5E _raceDnd5E;

        private ClassDnd5EFactory _classDnd5EFactory;
        private RaceDnd5EFactory _raceDnd5EFactory;

        public CharacterSheetDnd5E()
        {
            _name = "empty_name";

            _level = 1;
            _expirience = 0;

            _abilities = new Dictionary<string, int>()
            {
                ["strength"] = 1,
                ["dexterity"] = 1,
                ["constitution"] = 1,
                ["intelligence"] = 1,
                ["wisdom"] = 1,
                ["charisma"] = 1
            };
            _saveThrows = new Dictionary<string, bool>()
            {
                ["strength"] = false,
                ["dexterity"] = false,
                ["constitution"] = false,
                ["intelligence"] = false,
                ["wisdom"] = false,
                ["charisma"] = false
            };
            _skills = new Dictionary<string, bool>()
            {
                ["athletics"] = false,
                ["acrobatics"] = false,
                ["sleight"] = false,
                ["stealth"] = false,
                ["arcana"] = false,
                ["history"] = false,
                ["investigation"] = false,
                ["nature"] = false,
                ["religion"] = false,
                ["animal"] = false,
                ["insight"] = false,
                ["medicine"] = false,
                ["perception"] = false,
                ["surival"] = false,
                ["deception"] = false,
                ["intimidation"] = false,
                ["perfomance"] = false,
                ["persuasion"] = false
            };
        }

        public void PrintSheetInfoAll()
        {
            Console.WriteLine($"Имя: {_name}\n");
            Console.WriteLine($"Уровень: {_level}\n");
            Console.WriteLine($"Опыт: {_expirience}\n");
            Console.WriteLine("Раса: " + _raceDnd5E.GetName());
            Console.WriteLine("Класс: " + _classDnd5E.GetName());
            Console.WriteLine("Навыки: ");

            foreach (var item in _skills)
            {
                if (item.Value == true)
                {
                    Console.WriteLine(item);
                }
            }

            Console.WriteLine("\nСпасброски: ");

            foreach (var item in _saveThrows)
            {
                if (item.Value == true)
                {
                    Console.WriteLine(item);
                }
            }

            Console.WriteLine("\nХарактеристики: ");
            foreach (var item in _abilities)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }

        public string GetName()
        {
            return _name;
        }

        public void SetName(string name)
        {
            _name = name;
        }

        #region LEVEL

        public void GainExpirience(int exp)
        {
            _expirience += exp;
        }

        public void GetExpirience()
        {
            Console.WriteLine(_expirience);
        }

        public int GetProficiencyBonus()
        {
            if (_level <= 4)
                return 2;
            else if (_level <= 8)
                return 3;
            else if (_level <= 12)
                return 4;
            else if (_level <= 16)
                return 5;
            else
                return 6;
        }
        #endregion

        #region SKILLS

        public bool CheckSkill(string skill)
        {
            return _skills[skill];
        }

        public int GetSkillModificator(string skill)
        {
            if (CheckSkill(skill))
                return BaseSkillModificator(skill) + GetProficiencyBonus();
            else
                return BaseSkillModificator(skill);
        }

        public int BaseSkillModificator(string skill)
        {
            switch (skill)
            {
                case "athletics":
                    return GetAbilityModificator("strength");

                case "acrobatics":
                case "sleight":
                case "stealth":
                    return GetAbilityModificator("dexterity");

                case "arcana":
                case "history":
                case "investigation":
                case "nature":
                case "religion":
                    return GetAbilityModificator("intelligence");

                case "animal":
                case "insight":
                case "medicine":
                case "perception":
                case "surival":
                    return GetAbilityModificator("wisdom");

                case "deception":
                case "intimidation":
                case "perfomance":
                case "persuasion":
                    return GetAbilityModificator("charisma");
            }

            return 0;
        }

        public void SetSkills()
        {
            _isSet = false;

            while (_isSet == false)
            {
                Console.WriteLine("Введите навык героя из списка: \n");
                foreach (var item in Enum.GetValues(typeof(SkillsDnd5E)))
                {
                    Console.Write((int)item + " - ");
                    Console.Write(item + "\n");
                }

                _input = Console.ReadLine();
                if (Enum.TryParse<SkillsDnd5E>(_input, out SkillsDnd5E result))
                {
                    switch (result)
                    {
                        case SkillsDnd5E.athletics:
                            _skills[Convert.ToString(SkillsDnd5E.athletics)] = true;
                            break;

                        case SkillsDnd5E.acrobatics:
                            _skills[Convert.ToString(SkillsDnd5E.acrobatics)] = true;
                            break;

                        case SkillsDnd5E.sleight:
                            _skills[Convert.ToString(SkillsDnd5E.sleight)] = true;
                            break;

                        case SkillsDnd5E.stealth:
                            _skills[Convert.ToString(SkillsDnd5E.stealth)] = true;
                            break;

                        case SkillsDnd5E.arcana:
                            _skills[Convert.ToString(SkillsDnd5E.arcana)] = true;
                            break;

                        case SkillsDnd5E.history:
                            _skills[Convert.ToString(SkillsDnd5E.history)] = true;
                            break;

                        case SkillsDnd5E.investigation:
                            _skills[Convert.ToString(SkillsDnd5E.investigation)] = true;
                            break;

                        case SkillsDnd5E.nature:
                            _skills[Convert.ToString(SkillsDnd5E.nature)] = true;
                            break;

                        case SkillsDnd5E.religion:
                            _skills[Convert.ToString(SkillsDnd5E.religion)] = true;
                            break;

                        case SkillsDnd5E.animal:
                            _skills[Convert.ToString(SkillsDnd5E.animal)] = true;
                            break;

                        case SkillsDnd5E.insight:
                            _skills[Convert.ToString(SkillsDnd5E.insight)] = true;
                            break;

                        case SkillsDnd5E.medicine:
                            _skills[Convert.ToString(SkillsDnd5E.medicine)] = true;
                            break;

                        case SkillsDnd5E.perception:
                            _skills[Convert.ToString(SkillsDnd5E.perception)] = true;
                            break;

                        case SkillsDnd5E.surival:
                            _skills[Convert.ToString(SkillsDnd5E.surival)] = true;
                            break;

                        case SkillsDnd5E.deception:
                            _skills[Convert.ToString(SkillsDnd5E.deception)] = true;
                            break;

                        case SkillsDnd5E.intimidation:
                            _skills[Convert.ToString(SkillsDnd5E.intimidation)] = true;
                            break;

                        case SkillsDnd5E.perfomance:
                            _skills[Convert.ToString(SkillsDnd5E.perfomance)] = true;
                            break;

                        case SkillsDnd5E.persuasion:
                            _skills[Convert.ToString(SkillsDnd5E.persuasion)] = true;
                            break;
                    }
                }

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
        }

        public void GetSkills()
        {
            foreach (var skill in _skills) 
            {
                Console.WriteLine(skill);
            }
        }

        #endregion

        #region SAVETHROWS

        public bool CheckSaveThrow(string saveTrow)
        {
            return _saveThrows[saveTrow];
        }

        public int GetSaveThrowModificator(string saveThrow)
        {
            if (CheckSaveThrow(saveThrow))
                return GetAbilityModificator(saveThrow) + GetProficiencyBonus();
            else
                return GetAbilityModificator(saveThrow);
        }

        public void SetSaveTrows()
        {
            switch (Convert.ToString(_classDnd5E.GetName()))
            {
                case "bard":
                    _saveThrows["dex"] = true;
                    _saveThrows["cha"] = true;
                    break;

                case "barbarian":
                    _saveThrows["str"] = true;
                    _saveThrows["con"] = true;
                    break;

                case "fighter":
                    _saveThrows["str"] = true;
                    _saveThrows["con"] = true;
                    break;

                case "wizard":
                    _saveThrows["int"] = true;
                    _saveThrows["wis"] = true;
                    break;

                case "druid":
                    _saveThrows["int"] = true;
                    _saveThrows["wis"] = true;
                    break;

                case "cleric":
                    _saveThrows["wis"] = true;
                    _saveThrows["cha"] = true;
                    break;

                case "warlock":
                    _saveThrows["wis"] = true;
                    _saveThrows["cha"] = true;
                    break;

                case "monk":
                    _saveThrows["str"] = true;
                    _saveThrows["dex"] = true;
                    break;

                case "paladin":
                    _saveThrows["wis"] = true;
                    _saveThrows["cha"] = true;
                    break;

                case "rogue":
                    _saveThrows["dex"] = true;
                    _saveThrows["int"] = true;
                    break;

                case "ranger":
                    _saveThrows["str"] = true;
                    _saveThrows["dex"] = true;
                    break;

                case "sorcerer":
                    _saveThrows["con"] = true;
                    _saveThrows["cha"] = true;
                    break;
            }
        }

        public void GetSaveThrows()
        {
            foreach (var item in _saveThrows)
            {
                Console.WriteLine(item);
            }
        }

        #endregion

        #region CLASS

        public void SetClass()
        {
            _isSet = false;

            while (_isSet == false)
            {
                Console.Clear();
                Console.WriteLine("Выберите класс из списка:\n");

                foreach (var item in Enum.GetValues(typeof(ClassesDnd5E)))
                {
                    Console.Write((int)item + " - ");
                    Console.Write(item + "\n");
                }

                _input = Console.ReadLine();
                if (Enum.TryParse<ClassesDnd5E>(_input, out ClassesDnd5E result))
                {
                    switch (result)
                    {
                        case ClassesDnd5E.bard:
                            _classDnd5EFactory = new BardClassDnd5EProduct();
                            _classDnd5E = _classDnd5EFactory.CreateClassDnd5E();
                            break;

                        case ClassesDnd5E.barbarian:
                            _classDnd5EFactory = new BarbarianClassDnd5EProduct();
                            _classDnd5E = _classDnd5EFactory.CreateClassDnd5E();
                            break;

                        case ClassesDnd5E.fighter:
                            _classDnd5EFactory = new FighterClassDnd5EProduct();
                            _classDnd5E = _classDnd5EFactory.CreateClassDnd5E();
                            break;

                        case ClassesDnd5E.wizard:
                            _classDnd5EFactory = new WizardClassDnd5EProduct();
                            _classDnd5E = _classDnd5EFactory.CreateClassDnd5E();
                            break;

                        case ClassesDnd5E.druid:
                            _classDnd5EFactory = new DruidClassDnd5EProduct();
                            _classDnd5E = _classDnd5EFactory.CreateClassDnd5E();
                            break;

                        case ClassesDnd5E.cleric:
                            _classDnd5EFactory = new ClericClassDnd5EProduct();
                            _classDnd5E = _classDnd5EFactory.CreateClassDnd5E();
                            break;

                        case ClassesDnd5E.warlock:
                            _classDnd5EFactory = new WarlockClassDnd5EProduct();
                            _classDnd5E = _classDnd5EFactory.CreateClassDnd5E();
                            break;

                        case ClassesDnd5E.paladin:
                            _classDnd5EFactory = new PaladinClassDnd5EProduct();
                            _classDnd5E = _classDnd5EFactory.CreateClassDnd5E();
                            break;

                        case ClassesDnd5E.rogue:
                            _classDnd5EFactory = new RogueClassDnd5EProduct();
                            _classDnd5E = _classDnd5EFactory.CreateClassDnd5E();
                            break;

                        case ClassesDnd5E.ranger:
                            _classDnd5EFactory = new RangerClassDnd5EProduct();
                            _classDnd5E = _classDnd5EFactory.CreateClassDnd5E();
                            break;

                        case ClassesDnd5E.sorcerer:
                            _classDnd5EFactory = new SorcererClassDnd5EProduct();
                            _classDnd5E = _classDnd5EFactory.CreateClassDnd5E();
                            break;

                        case ClassesDnd5E.monk:
                            _classDnd5EFactory = new MonkClassDnd5EProduct();
                            _classDnd5E = _classDnd5EFactory.CreateClassDnd5E();
                            break;


                    }
                    Console.WriteLine("Класс выбран, и это " + _classDnd5E.GetName());
                    Console.ReadKey();
                    _isSet = true;
                }
                else
                {
                    Console.WriteLine("Неверный ввод, повторите ещё раз (нужно вводить номер)");
                    Console.ReadKey();
                }
            }
        }

        #endregion

        #region RACE

        public void SetRace()
        {
            _isSet = false;

            while (_isSet == false)
            {
                Console.Clear();
                Console.WriteLine("Выберите расу из списка:\n");

                foreach (var item in Enum.GetValues(typeof(RacesDnd5E)))
                {
                    Console.Write((int)item + " - ");
                    Console.Write(item + "\n");
                }

                _input = Console.ReadLine();
                if (Enum.TryParse<RacesDnd5E>(_input, out RacesDnd5E result))
                {
                    switch (result)
                    {
                        case RacesDnd5E.dwarf:
                            _raceDnd5EFactory = new DwarfRaceDnd5EProduct();
                            _raceDnd5E = _raceDnd5EFactory.CreateRaceDnd5E();
                            break;

                        case RacesDnd5E.gnome:
                            _raceDnd5EFactory = new GnomeRaceDnd5EProduct();
                            _raceDnd5E = _raceDnd5EFactory.CreateRaceDnd5E();
                            break;

                        case RacesDnd5E.dragonborn:
                            _raceDnd5EFactory = new DragonbornRaceDnd5EProduct();
                            _raceDnd5E = _raceDnd5EFactory.CreateRaceDnd5E();
                            break;

                        case RacesDnd5E.halforc:
                            _raceDnd5EFactory = new HalforcRaceDnd5EProduct();
                            _raceDnd5E = _raceDnd5EFactory.CreateRaceDnd5E();
                            break;

                        case RacesDnd5E.halfling:
                            _raceDnd5EFactory = new HalflingRaceDnd5EProduct();
                            _raceDnd5E = _raceDnd5EFactory.CreateRaceDnd5E();
                            break;

                        case RacesDnd5E.tiefling:
                            _raceDnd5EFactory = new TieflingRaceDnd5EProduct();
                            _raceDnd5E = _raceDnd5EFactory.CreateRaceDnd5E();
                            break;

                        case RacesDnd5E.human:
                            _raceDnd5EFactory = new HumanRaceDnd5EProduct();
                            _raceDnd5E = _raceDnd5EFactory.CreateRaceDnd5E();
                            break;

                        case RacesDnd5E.elf:
                            _raceDnd5EFactory = new ElfRaceDnd5EProduct();
                            _raceDnd5E = _raceDnd5EFactory.CreateRaceDnd5E();
                            break;

                        case RacesDnd5E.halfelf:
                            _raceDnd5EFactory = new HalfelfRaceDnd5EProduct();
                            _raceDnd5E = _raceDnd5EFactory.CreateRaceDnd5E();
                            break;
                    }

                    Console.WriteLine($"Раса выбрана, и это {_raceDnd5E.GetName()}");
                    Console.ReadKey();
                    _isSet = true;
                }
                else
                {
                    Console.WriteLine("Неверный ввод, повторите ещё раз (нужно вводить номер)");
                    Console.ReadKey();
                }
            }
        }

        #endregion
    }
}
