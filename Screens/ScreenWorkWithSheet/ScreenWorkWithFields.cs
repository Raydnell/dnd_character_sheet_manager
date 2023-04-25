namespace dnd_character_sheet
{
    public class ScreenWorkWithFields : IScreen
    {
        private bool _isPointChoose;
        private IUserInput _userInput;
        private IUserOutput _userOutput;
        private int _intInput;
        private string _stringInput;

        public ScreenWorkWithFields()
        {
            _userInput = new ConsoleInput();
            _userOutput = new ConsoleOutput();
        }

        public void ShowScreen(ref CharacterSheetBase heroSheet, Enum language)
        {
            _isPointChoose = false;
            while (_isPointChoose == false)
            {
                _userOutput.Clear();
                _userOutput.Print("Что нужно изменить в листе?\n");
                _userOutput.Print("1. Имя героя");
                _userOutput.Print("2. Основные характеристики");
                _userOutput.Print("3. Навыки");
                _userOutput.Print("4. Опыт, уровень");
                _userOutput.Print("5. Раса");
                _userOutput.Print("6. Класс");
                _userOutput.Print("7. Личностные качества");
                _userOutput.Print("8. Боевые атрибуты (хп, броня, скорость)");
                _userOutput.Print("9. Владения");
                _userOutput.Print("10. Вернуться назад");

                _intInput = _userInput.InputInt();

                switch (_intInput)
                {
                    default:
                    case 0:
                        _userOutput.Clear();
                        _userOutput.Print("Выбрано неверное значение");
                        break;

                    case 1:
                        ChangeSheetName(heroSheet);
                        break;

                    case 2:
                        ChangeAbilityScore(heroSheet);
                        break;

                    case 3:
                        ChangeSkills(heroSheet);
                        break;

                    case 4:
                        ChangeExpirienseScore(heroSheet);
                        break;

                    case 5:
                        ChangeRace(heroSheet);
                        break;

                    case 6:
                        ChangeClass(heroSheet);
                        break;

                    case 7:
                        ChangePersonality(heroSheet);
                        break;

                    case 8:
                        ChangeBattleFields(heroSheet);
                        break;

                    case 9:
                        ChangeProficiencies(heroSheet);
                        break;

                    case 10:
                        _isPointChoose = true;
                        break;
                }

                _isPointChoose = BreakOrContinue();
            }
        }

        private bool BreakOrContinue()
        {
            _userOutput.Print("\n1. Вернуться в главное меню");
            _userOutput.Print("2. Остаться на экране изменения полей листа");

            _intInput = _userInput.InputInt();
            if (_intInput == 1)
            {
                return true;
            }

            return false;
        }

        private void ChangeSheetName(CharacterSheetBase heroSheet)
        {
            _userOutput.Clear();
            _userOutput.Print("Введите новое имя героя: ", false);
            heroSheet.Name = _userInput.InputString();
            _userOutput.Print("\nГотово, новое имя героя: " + heroSheet.Name);
            _userInput.InputKey();
        }

        private void ChangeAbilityScore(CharacterSheetBase heroSheet)
        {
            _userOutput.Clear();
            _userOutput.Print("Какую характеристику нужно поменять?\n");
            _userOutput.Print(typeof(EnumAbilitiesDnd5E));
            _userOutput.Print("");

            _stringInput = _userInput.InputString();
            if (Enum.TryParse<EnumAbilitiesDnd5E>(_stringInput, out EnumAbilitiesDnd5E result))
            {
                _userOutput.Print("\nКакое новое значение указать для " + result.ToString() + " ?\n");

                _intInput = _userInput.InputInt();
                //heroSheet.SheetAbilities.SetAbilityScore(result.ToString(), _intInput);

                _userOutput.Print("Характеристика изменена");
                _userInput.InputKey();
            }
            else
            {
                IncorrectInput();
            }
        }

        private void ChangeSkills(CharacterSheetBase heroSheet)
        {
            _userOutput.Print("Текущий список навыков:\n");
            _userOutput.Print(heroSheet.SheetSkills.Skills);
            
            _userOutput.Print("\nНужно добавить или убрать навык?");
            _userOutput.Print("1. Добавить");
            _userOutput.Print("2. Убрать\n");

            _intInput = _userInput.InputInt();
            if (_intInput == 1)
            {
                _userOutput.Clear();
                _userOutput.Print("Какой навык нужно добавить?\n");

                _userOutput.Print(typeof(EnumSkillsDnd5E));
                _userOutput.Print("");

                _stringInput = _userInput.InputString();
                if (Enum.TryParse<EnumSkillsDnd5E>(_stringInput, out EnumSkillsDnd5E result))
                {
                    if (heroSheet.SheetSkills.Skills.Contains(result.ToString()) != true)
                    {
                        heroSheet.SheetSkills.AddSkill(result.ToString());
                    }
                }
                else
                {
                    IncorrectInput();
                }
            }
            else if (_intInput == 2)
            {
                _userOutput.Clear();
                _userOutput.Print("Какой навык нужно убрать?\n");

                _userOutput.Print(heroSheet.SheetSkills.Skills);

                _userOutput.Print("");

                _stringInput = _userInput.InputString();
                if (heroSheet.SheetSkills.Skills.Contains(_stringInput))
                {
                    heroSheet.SheetSkills.Skills.Remove(_stringInput);
                }
                else
                {
                    IncorrectInput();
                }
            }
            else
            {
                IncorrectInput();
            }
        }

        private void ChangeExpirienseScore(CharacterSheetBase heroSheet)
        {
            _userOutput.Clear();
            _userOutput.Print("Текущее количество опыта: " + heroSheet.SheetProgression.Expirience);
            _userOutput.Print("\nПри повышении опыта уровень будет подниматься автоматически.");
            _userOutput.Print("Нужно увеличить или уменьшить количество опыта?\n");
            _userOutput.Print("1. Увеличить");
            _userOutput.Print("2. Уменьшить\n");

            _intInput = _userInput.InputInt();
            if (_intInput == 1)
            {
                _userOutput.Print("\nНа сколько нужно увеличить?\n");
                _intInput = _userInput.InputInt();
                heroSheet.SheetProgression.GainExpirience(_intInput);
            }
            else if (_intInput == 2)
            {
                _userOutput.Print("\nНа сколько нужно уменьшить?\n");
                _intInput = _userInput.InputInt();
                heroSheet.SheetProgression.LowerExpirience(_intInput);
            }
            else
            {
                IncorrectInput();
            }
        }

        private void ChangeRace(CharacterSheetBase heroSheet)
        {
            _userOutput.Clear();
            _userOutput.Print("Текущая раса: " + heroSheet.SheetRace.Name);
            _userOutput.Print("\nВыберите новую расу из списка:");
            _userOutput.Print(typeof(EnumRacesDnd5E));
            _userOutput.Print("");

            _stringInput = _userInput.InputString();
            if (Enum.TryParse<EnumRacesDnd5E>(_stringInput, out EnumRacesDnd5E result))
            {
                heroSheet.SheetRace.SetRace(result.ToString());
            }
            else 
            {
                IncorrectInput();
            }
        }

        private void ChangeClass(CharacterSheetBase heroSheet)
        {
            _userOutput.Clear();
            _userOutput.Print("Текущий класс: " + heroSheet.SheetClass.Name);
            _userOutput.Print("\nВыберите новый класс из списка:");
            _userOutput.Print(typeof(EnumClassesDnd5E));
            _userOutput.Print("");

            _stringInput = _userInput.InputString();
            if (Enum.TryParse<EnumClassesDnd5E>(_stringInput, out EnumClassesDnd5E result))
            {
                heroSheet.SheetClass.SetClass(result.ToString());
            }
            else 
            {
                IncorrectInput();
            }
        }

        private void ChangePersonality(CharacterSheetBase heroSheet)
        {
            string tempPersonalityValue = string.Empty;

            _userOutput.Clear();
            _userOutput.Print("Сейчас в листе указаны такие качества:\n");
            _userOutput.Print(heroSheet.SheetPersonality.PersonalityList);
            _userOutput.Print("\nНужно изменить одно из них или добавить новое?\n");
            _userOutput.Print("1. Изменить существующее");
            _userOutput.Print("2. Добавить новое");

            _intInput = _userInput.InputInt();
            if (_intInput == 1)
            {
                _userOutput.Print("Какое поле нужно изменить?\n");
                _userOutput.Print(heroSheet.SheetPersonality.PersonalityList.Keys);
                _userOutput.Print("");

                _stringInput = _userInput.InputString();
                if (heroSheet.SheetPersonality.PersonalityList.ContainsKey(_stringInput))
                {
                    _userOutput.Print("\nВведи новое значение для этого поля:\n\n");
                    heroSheet.SheetPersonality.AddPersonality(_stringInput, _userInput.InputString());
                    _userOutput.Print("Замена прошла.");
                    _userInput.InputKey();
                }
                else
                {
                    IncorrectInput();
                }
            }
            else if (_intInput == 2)
            {
                _userOutput.Print("Введи название нового качества, которое нужно добавить: ", false);
                _stringInput = _userInput.InputString();
                _userOutput.Print("\nВведи значение для нового качества: ", false);
                heroSheet.SheetPersonality.AddPersonality(_stringInput, _userInput.InputString());
                _userOutput.Print("Добавление прошло успешно.");
                _userInput.InputKey();
            }
            else
            {
                IncorrectInput();
            }
        }

        private void ChangeBattleFields(CharacterSheetBase heroSheet)
        {
            _userOutput.Clear();
            _userOutput.Print("Какое поле нужно изменить?\n");
            _userOutput.Print("1. ХП, временные хп");
            _userOutput.Print("2. Кость хитов");
            _userOutput.Print("3. Класс брони");
            _userOutput.Print("4. Скорость\n");

            _intInput = _userInput.InputInt();
            switch(_intInput)
            {
                case 1:
                    ChangeHP(heroSheet);
                    break;

                case 2:
                    ChangeCurrentHitDices(heroSheet);
                    break;
                
                case 3:
                    ChangeArmorClass(heroSheet);
                    break;

                case 4:
                    ChangeSpeed(heroSheet);
                    break;

                default:
                case 0:
                    IncorrectInput();
                    break;
            }
        }

        private void ChangeHP(CharacterSheetBase heroSheet)
        {
            _userOutput.Clear();
            _userOutput.Print("Текущее и максимальное ХП:");
            _userOutput.Print(heroSheet.SheetCombatAbilities.CurrentHP + "/" + heroSheet.SheetCombatAbilities.MaximumHP);
            _userOutput.Print("\nВременные хиты:");
            _userOutput.Print(heroSheet.SheetCombatAbilities.TemporaryHP);
            _userOutput.Print("\nЧто нужно изменить?\n");
            _userOutput.Print("1. Текущее ХП");
            _userOutput.Print("2. Максимальное ХП");
            _userOutput.Print("3. Временное ХП\n");

            _intInput = _userInput.InputInt();
            if (_intInput == 1 || _intInput == 2 || _intInput == 3)
            {
                _userOutput.Print("\nВведите новое значение: ", false);

                if (_intInput == 1)
                {
                    heroSheet.SheetCombatAbilities.SetCurrentHP(_userInput.InputInt());
                }
                else if (_intInput == 2)
                {
                    heroSheet.SheetCombatAbilities.SetMaximumHP(_userInput.InputInt());
                }
                else if (_intInput == 3)
                {
                    heroSheet.SheetCombatAbilities.SetTemporaryHP(_userInput.InputInt());
                }
            }
            else
            {
                IncorrectInput();
            }
        }

        private void ChangeCurrentHitDices(CharacterSheetBase heroSheet)
        {
            _userOutput.Clear();
            _userOutput.Print("Текущий максимум костей хитов: " + heroSheet.SheetCombatAbilities.TotalHitDices);
            _userOutput.Print("Сколько осталось костей хитов: " + heroSheet.SheetCombatAbilities.CurrentHitDices);
            _userOutput.Print("Какая кость хитов у листа: " + heroSheet.SheetCombatAbilities.HitDice);

            _userOutput.Print("\nКакое количество костей хитов указать? (Нельзя указать больше максимума)\n");

            _intInput = _userInput.InputInt();
            if(_intInput >= 0 && _intInput <= heroSheet.SheetCombatAbilities.TotalHitDices)
            {
                heroSheet.SheetCombatAbilities.SetCurrentHitDices(_intInput);
            }
            else
            {
                IncorrectInput();
            }
        }

        private void ChangeArmorClass(CharacterSheetBase heroSheet)
        {
            _userOutput.Clear();
            _userOutput.Print("Текущий класс брони: " + heroSheet.SheetCombatAbilities.ArmorClass);
            _userOutput.Print("\nУкажи новое значение для класса брони: ", false);

            _intInput = _userInput.InputInt();
            if(_intInput > 0)
            {
                heroSheet.SheetCombatAbilities.SetArmorClass(_intInput);
            }
            else
            {
                IncorrectInput();
            }
        }

        private void ChangeSpeed(CharacterSheetBase heroSheet)
        {
            _userOutput.Clear();
            _userOutput.Print("Текущая скорость: " + heroSheet.SheetCombatAbilities.Speed);
            _userOutput.Print("\nУкажи новое значение для скорости: ", false);

            _intInput = _userInput.InputInt();
            if(_intInput > 0)
            {
                heroSheet.SheetCombatAbilities.SetSpeed(_intInput);
            }
            else
            {
                IncorrectInput();
            }
        }

        private void ChangeProficiencies(CharacterSheetBase heroSheet)
        {
            string[] proficienciesTemp;
            
            _userOutput.Clear();
            _userOutput.Print("Текущие владения:\n");
            _userOutput.Print(heroSheet.SheetProficiencies.Proficiencies);

            _userOutput.Print("\nЧто нужно сделать?\n");

            _userOutput.Print("1. Добавить новое владение");
            _userOutput.Print("2. Убрать владение");

            _intInput = _userInput.InputInt();
            if (_intInput == 1)
            {
                _userOutput.Clear();
                _userOutput.Print("\nИз какой группы нужно добавить владение?\n");
                _userOutput.Print(typeof(EnumProficiencies));

                _stringInput = _userInput.InputString();
                if (Enum.TryParse<EnumProficiencies>(_stringInput, out EnumProficiencies result))
                {
                    if (ProficiencyGroups.GetEnumByString(result.ToString()) != null)
                    {
                        proficienciesTemp = Enum.GetNames(ProficiencyGroups.GetEnumByString(result.ToString()));
                        
                        _userOutput.Print("\nВыберите владение, которое нужно добавить:\n");
                        _userOutput.Print(ProficiencyGroups.GetEnumByString(result.ToString()));

                        _intInput = _userInput.InputInt();
                        if (proficienciesTemp[_intInput - 1] != null)
                        {
                            if (heroSheet.SheetProficiencies.Proficiencies.Contains(proficienciesTemp[_intInput - 1]) == false)
                            {
                                heroSheet.SheetProficiencies.AddProficiency(proficienciesTemp[_intInput - 1]);
                                _userOutput.Print("\nВладение добавлено\n");
                                _userInput.InputKey();
                            }
                            else
                            {
                                _userOutput.Print("\nТакое владение уже есть\n");
                                _userInput.InputKey();
                            }
                        }
                        else
                        {
                            IncorrectInput();
                        }
                    }
                    else
                    {
                        IncorrectInput();
                    }
                }
            }
            else if (_intInput == 2)
            {
                _userOutput.Clear();
                _userOutput.Print("\nКакое владение нужно убрать?\n");
                _userOutput.Print(heroSheet.SheetProficiencies.Proficiencies);
                _userOutput.Print("");

                _stringInput = _userInput.InputString();
                if(heroSheet.SheetProficiencies.Proficiencies.Contains(_stringInput))
                {
                    heroSheet.SheetProficiencies.Proficiencies.Remove(_stringInput);
                    _userOutput.Print("\nВладение убрано");
                    _userInput.InputKey();
                }
                else
                {
                    IncorrectInput();
                }
            }
            else
            {
                IncorrectInput();
            }
        }

        private void IncorrectInput()
        {
            _userOutput.Print("Некорректный ввод.");
            _userInput.InputKey();
        }
    }
}