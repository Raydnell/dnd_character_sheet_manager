using System;

namespace dnd_character_sheet
{
    public class ScreenWorkWithSheet
    {
        private int _choosenPoint;
        private int _rollResult;
        private int _expInput;

        private string _input;

        private bool _backToMenu;
        private bool _correctInput;

        private Dicer _dicer;
        private CheckInput _checkInput;

        public ScreenWorkWithSheet()
        {
            _dicer = new Dicer();
            _checkInput = new CheckInput();
        }

        public void ChooseSheetRolls(CharacterSheetDnd5E heroSheet)
        {
            while (_backToMenu == false)
            {
                Console.Clear();
                Console.WriteLine("Экран бросков по листу персонажа.");
                Console.WriteLine("Выбери действие:\n");
                Console.WriteLine("1. Проверка характеристики");
                Console.WriteLine("2. Проверка навыка");
                Console.WriteLine("3. Проверка спасброска");
                Console.WriteLine("4. Вывести лист на экран");
                Console.WriteLine("5. Увеличить опыт");
                Console.WriteLine("10. Вернуться в главное меню");

                _choosenPoint = _checkInput.CheckIntInput();

                switch (_choosenPoint)
                {
                    case 0:
                    default:
                        Console.WriteLine("Введено неверное число, нужно ввести число из списка.");
                        Console.ReadKey();
                        break;

                    case 1:
                        CheckAbility(heroSheet);
                        break;

                    case 2:
                        CheckSkill(heroSheet);
                        break;

                    case 3:
                        CheckSaveThrow(heroSheet);
                        break;

                    case 4:
                        heroSheet.PrintSheetInfoAll();
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

        private void CheckAbility(CharacterSheetDnd5E heroSheet)
        {

            _correctInput = false;
            while (_correctInput == false)
            {
                Console.Clear();
                Console.WriteLine("Какую характеристику нужно проверить:\n");
                heroSheet.GetAbilities();
                Console.WriteLine("\n");

                _input = Console.ReadLine();
                if (Enum.TryParse<AbilitiesDnd5E>(_input, out AbilitiesDnd5E result))
                {
                    _rollResult = _dicer.DiceRoll(1, 20, heroSheet.GetAbilityModificator(Convert.ToString(result)));
                    Console.WriteLine($"\nРезультат проверки: {_rollResult}");
                    _correctInput = true;
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Некорректный ввод, попробуй ещё раз.");
                }
            }
        }

        private void CheckSkill(CharacterSheetDnd5E heroSheet)
        {
            _correctInput = false;
            while (_correctInput == false)
            {
                Console.Clear();
                Console.Write("Какой навык нужно проверить: \n");
                heroSheet.GetSkills();
                Console.WriteLine("\n");

                _input = Console.ReadLine();
                if (Enum.TryParse<SkillsDnd5E>(_input, out SkillsDnd5E result))
                {
                    _rollResult = _dicer.DiceRoll(1, 20, heroSheet.GetSkillModificator(Convert.ToString(result)));
                    Console.WriteLine($"\nРезультат проверки: {_rollResult}");
                    _correctInput = true;
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Некорректный ввод, попробуй ещё раз.");
                }
            }
        }

        private void CheckSaveThrow(CharacterSheetDnd5E heroSheet)
        {
            _correctInput = false;
            while (_correctInput == false)
            {
                Console.Clear();
                Console.WriteLine("Какой спасбросок нужно сделать:");
                heroSheet.GetSaveThrows();
                Console.WriteLine("\n");

                _input = Console.ReadLine();
                if (Enum.TryParse<AbilitiesDnd5E>(_input, out AbilitiesDnd5E result))
                {
                    _rollResult = _dicer.DiceRoll(1, 20, heroSheet.GetSaveThrowModificator(Convert.ToString(result)));
                    Console.WriteLine($"\nРезультат проверки: {_rollResult}");
                    _correctInput = true;
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Некорректный ввод, попробуй ещё раз.");
                }
            }
        }

        private void RaiseExpirience(CharacterSheetDnd5E heroSheet)
        {
            Console.Write("Сколько опыта нужно добавить: ");
            _expInput = _checkInput.CheckIntInput();
            heroSheet.GainExpirience(_expInput);
            Console.Write("\nТекущее количество опыта: ");
            heroSheet.GetExpirience();
            Console.ReadKey();
        }
    }
}
