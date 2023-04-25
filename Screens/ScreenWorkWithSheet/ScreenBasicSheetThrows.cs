namespace dnd_character_sheet
{
    public class ScreenBasicSheetThrows : IScreen
    {
        private string _stringInput;

        private bool _correctInput;
        private bool _stayOnScreen;

        private int _rollResult;
        private int _intInput;
        private int _rollModificator;
        private int _abilityModificator;
        private int _proficiencyBonus;
        
        private IUserInput _userInput;
        private IUserOutput _userOutput;
        private Dicer _dicer;
        private IScreen _screen;
        private Random _random;

        public ScreenBasicSheetThrows()
        {
            _userInput = new ConsoleInput();
            _userOutput = new ConsoleOutput();
            _dicer = new Dicer();
            _stringInput = string.Empty;
            _random = new Random();
        }
        
        public void ShowScreen(ref CharacterSheetBase heroSheet, Enum language)
        {
            _proficiencyBonus = heroSheet.SheetProgression.GetProficiencyBonus();
            
            _stayOnScreen = true;
            while (_stayOnScreen == true)
            {
                _userOutput.Clear();
                _userOutput.Print("Экран бросков по листу персонажа.");
                _userOutput.Print("Какой бросок нужно совершить:\n");
                _userOutput.Print("1. Проверка характеристики");
                _userOutput.Print("2. Проверка навыка");
                _userOutput.Print("3. Проверка спасброска");
                _userOutput.Print("4. Проверка владения");
                _userOutput.Print("5. Свободный бросок");
                _userOutput.Print("10. Вернуться в главное меню");

                _intInput = _userInput.InputInt();
                switch(_intInput)
                {
                    case 1:
                        CheckAbility(heroSheet, language);
                        break;

                    case 2:
                        CheckSkill(heroSheet);
                        break;

                    case 3:
                        CheckSaveThrow(heroSheet);
                        break;

                    case 4:
                        CheckProficiency(heroSheet);
                        break;

                    case 5:
                        _screen = new ScreenRollDice();
                        _screen.ShowScreen(ref heroSheet, language);
                        break;

                    case 10:
                        _stayOnScreen = false;
                        break;

                    default:
                    case 0:
                        IncorrectInput();
                        break;
                }

                if(_stayOnScreen == true)
                {
                    _stayOnScreen = BreakOrContinue();
                }
            }
        }

        private bool BreakOrContinue()
        {
            _userOutput.Print("\n1. Вернуться в меню");
            _userOutput.Print("2. Остаться на экране бросков кубов по листу");

            _intInput = _userInput.InputInt();
            if (_intInput == 1)
            {
                return false;
            }

            return true;
        }

        private void CheckAbility(CharacterSheetBase heroSheet, Enum language)
        {
            _userOutput.Clear();
            _userOutput.Print("Какую характеристику нужно проверить:\n");
            _userOutput.Print(heroSheet.SheetAbilities.Abilities, language);
            _userOutput.Print("");

            _stringInput = _userInput.InputString();
            if (Enum.TryParse<EnumAbilitiesDnd5E>(_stringInput, out EnumAbilitiesDnd5E result))
            {
                //_abilityModificator = heroSheet.SheetAbilities.GetAbilityModificator(result.ToString());
                _rollResult = _random.Next(1, 20) + _abilityModificator;
                _userOutput.Print("Результат броска: " + _rollResult);
                _userInput.InputKey();
            }
            else
            {
                IncorrectInput();
            }
        }

        private void CheckSkill(CharacterSheetBase heroSheet)
        {
            _userOutput.Clear();
            _userOutput.Print("Какие навыки есть в листе:\n");
            _userOutput.Print(heroSheet.SheetSkills.Skills);
            _userOutput.Print("\nСписок всех навыков:");
            _userOutput.Print(typeof(EnumSkillsDnd5E));
            _userOutput.Print("\nУкажи навык, который нужно проверить:\n");

            _stringInput = _userInput.InputString();
            if (Enum.TryParse<EnumSkillsDnd5E>(_stringInput, out EnumSkillsDnd5E result))
            {
                //_abilityModificator = heroSheet.SheetAbilities.GetAbilityModificator(heroSheet.SheetSkills.SkillAbilityName(result.ToString()));
                
                if(heroSheet.SheetSkills.CheckSkill(result.ToString()))
                {
                    _rollResult = _random.Next(1, 21) + _abilityModificator + _proficiencyBonus;
                }
                else
                {
                    _rollResult = _random.Next(1, 21) + _abilityModificator;
                }
                _userOutput.Print($"\nРезультат проверки: {_rollResult}");
                _userInput.InputKey();
            }
            else
            {
                IncorrectInput();
            }
        }

        private void CheckSaveThrow(CharacterSheetBase heroSheet)
        {
            _userOutput.Clear();
            _userOutput.Print("Текущий лист владеет такими спасбросками:");
            _userOutput.Print(heroSheet.SheetSaveThrows.SaveThrows);
            _userOutput.Print("\nКакой спасбросок нужно сделать:");
            _userOutput.Print(typeof(EnumAbilitiesDnd5E));
            _userOutput.Print("");

            _stringInput = _userInput.InputString();
            if (Enum.TryParse<EnumAbilitiesDnd5E>(_stringInput, out EnumAbilitiesDnd5E result))
            {
                //_abilityModificator = heroSheet.SheetAbilities.GetAbilityModificator(result.ToString());
                
                if(heroSheet.SheetSaveThrows.CheckSaveThrow(result.ToString()))
                {
                    _rollResult = _random.Next(1, 21) + _abilityModificator + _proficiencyBonus;
                }
                else
                {
                    _rollResult = _random.Next(1, 21) + _abilityModificator;
                }
                _userOutput.Print($"\nРезультат проверки: {_rollResult}");
                _userInput.InputKey();
            }
            else
            {
                IncorrectInput();
            }
        }

        private void CheckProficiency(CharacterSheetBase heroSheet)
        {
            _userOutput.Clear();
            _userOutput.Print("Вот список текущих владений:\n");
            _userOutput.Print(heroSheet.SheetProficiencies.Proficiencies);
            _userOutput.Print("\nБросок будет по одному из этих владений?");
            _userOutput.Print("\n1. Да");
            _userOutput.Print("2. Нет");

            _stringInput = _userInput.InputString();
            if(_stringInput == "1")
            {
                _rollResult = _random.Next(1, 21) + _proficiencyBonus;
            }
            else if (_stringInput == "2")
            {
                _rollResult = _random.Next(1, 21);
            }

            _userOutput.Print("Результат броска: " + _rollResult);
            _userInput.InputKey();
        }

        private void IncorrectInput()
        {
            _userOutput.Print("Некорректный ввод");
            _userInput.InputKey();
        }
    }
}