namespace dnd_character_sheet
{
    public class ScreenWorkWithSheet : IScreen
    {
        private int _choosenPoint;
        private int _rollResult;
        private int _expInput;

        private string _input;

        private bool _backToMenu;
        private bool _correctInput;

        private Dicer _dicer;
        private IUserInput _userInput;
        private IUserOutput _userOutput;
        private PrintSheetInfo _printSheetInfo;

        public ScreenWorkWithSheet()
        {
            _dicer = new Dicer();
            _input = string.Empty;
            _userInput = new ConsoleInput();
            _userOutput = new ConsoleOutput();
            _printSheetInfo = new PrintSheetInfo();
        }

        public void ShowScreen(ref CharacterSheetBase heroSheet)
        {
            /*
            
            while (_backToMenu == false)
            {
                _userOutput.Clear();
                _userOutput.Print("Экран бросков по листу персонажа.");
                _userOutput.Print("Выбери действие:\n");
                _userOutput.Print("1. Проверка характеристики");
                _userOutput.Print("2. Проверка навыка");
                _userOutput.Print("3. Проверка спасброска");
                _userOutput.Print("4. Вывести лист на экран");
                _userOutput.Print("5. Увеличить опыт");
                _userOutput.Print("10. Вернуться в главное меню");

                _choosenPoint = _userInput.InputInt();

                switch (_choosenPoint)
                {
                    case 0:
                    default:
                        _userOutput.Print("Введено неверное число, нужно ввести число из списка.");
                        _userInput.InputKey();
                        break;

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
                        _printSheetInfo.ShowSheetFields(heroSheet, language);
                        _userInput.InputKey();
                        break;

                    case 5:
                        RaiseExpirience(heroSheet);
                        break;

                    case 10:
                        _backToMenu = true;
                        break;
                }
            }
        }

        private void CheckAbility(CharacterSheetBase heroSheet, Enum language)
        {
            _correctInput = false;
            while (_correctInput == false)
            {
                _userOutput.Clear();
                _userOutput.Print("Какую характеристику нужно проверить:\n");
                //_userOutput.Print(heroSheet.SheetAbilities.Abilities, language);
                _userOutput.Print("\n");

                _input = _userInput.InputString();
                if (Enum.TryParse<EnumAbilitiesDnd5E>(_input, out EnumAbilitiesDnd5E result))
                {
                    //_rollResult = _dicer.DiceRoll(1, 20, heroSheet.SheetAbilities.GetAbilityModificator(result.ToString()));
                    _userOutput.Print($"\nРезультат проверки: {_rollResult}");
                    _correctInput = true;
                    _userInput.InputKey();
                }
                else
                {
                    _userOutput.Print("Некорректный ввод, попробуй ещё раз.");
                    _userInput.InputKey();
                }
            }
        }

        private void CheckSkill(CharacterSheetBase heroSheet)
        {
            _correctInput = false;
            while (_correctInput == false)
            {
                _userOutput.Clear();
                _userOutput.Print("Какой навык нужно проверить: \n");
                _userOutput.Print(heroSheet.SheetSkills.Skills);
                _userOutput.Print("\n");

                _input = _userInput.InputString();
                if (Enum.TryParse<EnumSkillsDnd5E>(_input, out EnumSkillsDnd5E result))
                {
                    if(heroSheet.SheetSkills.CheckSkill(result.ToString()))
                    {
                        //_rollResult = _dicer.DiceRoll(1, 20, (heroSheet.SheetAbilities.GetAbilityModificator(heroSheet.SheetSkills.SkillAbilityName(result.ToString())) + heroSheet.SheetProgression.GetProficiencyBonus()));
                    }
                    else
                    {
                        //_rollResult = _dicer.DiceRoll(1, 20, (heroSheet.SheetAbilities.GetAbilityModificator(heroSheet.SheetSkills.SkillAbilityName(result.ToString()))));
                    }
                    _userOutput.Print($"\nРезультат проверки: {_rollResult}");
                    _correctInput = true;
                    _userInput.InputKey();
                }
                else
                {
                    _userOutput.Print("Некорректный ввод, попробуй ещё раз.");
                    _userInput.InputKey();
                }
            }
        }

        private void CheckSaveThrow(CharacterSheetBase heroSheet)
        {
            _correctInput = false;
            while (_correctInput == false)
            {
                _userOutput.Clear();
                _userOutput.Print("Какой спасбросок нужно сделать:");
                _userOutput.Print(heroSheet.SheetSaveThrows.SaveThrows);
                _userOutput.Print("\n");

                _input = _userInput.InputString();
                if (Enum.TryParse<EnumAbilitiesDnd5E>(_input, out EnumAbilitiesDnd5E result))
                {
                    if(heroSheet.SheetSaveThrows.CheckSaveThrow(result.ToString()))
                    {
                        //_rollResult = _dicer.DiceRoll(1, 20, heroSheet.SheetAbilities.GetAbilityModificator(result.ToString()) + heroSheet.SheetProgression.GetProficiencyBonus());
                    }
                    else
                    {
                        //_rollResult = _dicer.DiceRoll(1, 20, heroSheet.SheetAbilities.GetAbilityModificator(result.ToString()));
                    }
                    _userOutput.Print($"\nРезультат проверки: {_rollResult}");
                    _correctInput = true;
                    _userInput.InputKey();
                }
                else
                {
                    _userOutput.Print("Некорректный ввод, попробуй ещё раз.");
                    _userInput.InputKey();
                }
            }

            */
        }

        private void RaiseExpirience(CharacterSheetBase heroSheet)
        {
            _userOutput.Print("Сколько опыта нужно добавить: ");
            _expInput = _userInput.InputInt();
            heroSheet.SheetProgression.GainExpirience(_expInput);
            Console.Write("\nТекущее количество опыта: ");
            Console.Write(heroSheet.SheetProgression.Expirience);
            Console.ReadKey();
        }
    }
}
