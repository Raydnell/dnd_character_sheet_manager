using Spectre.Console;
using System.Text;

namespace dnd_character_sheet
{
    public class RollThrower : IRollSystem
    {
        private Random _random;
        private int _diceRollResult;
        private int _oneDiceRollResult;
        private StringBuilder _stringBuilder;

        public RollThrower()
        {
            _random = new Random();
            _stringBuilder = new StringBuilder();
            _diceRollResult = 0;
        }

        public string ChooseAction()
        {
            _stringBuilder.Remove(0, _stringBuilder.Length);
            _diceRollResult = 0;
            _oneDiceRollResult = 0;
            
            Console.Clear();
            Console.WriteLine(LocalizationsStash.SelectedLocalization[EnumRollThrower.WhatCountOfDices] + ": \n");
            
            if (int.TryParse(Console.ReadLine(), out int diceAmount))
            {
                Console.Clear();
                string tempDice = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title(LocalizationsStash.SelectedLocalization[EnumRollThrower.ChooseDice])
                        .PageSize(10)
                        .AddChoices(Enum.GetNames(typeof(EnumDices))));

                Enum.TryParse<EnumDices>(tempDice, out EnumDices dice);

                for (int i = 1; i <= diceAmount; i++)
                {
                    _oneDiceRollResult = _random.Next(1, (int)dice + 1);

                    if (i == diceAmount)
                    {
                        _stringBuilder.Append(_oneDiceRollResult);
                    }
                    else
                    {
                        _stringBuilder.Append(_oneDiceRollResult + " + ");
                    }
                    _diceRollResult += _oneDiceRollResult;
                }

                Console.Clear();
                Console.WriteLine(LocalizationsStash.SelectedLocalization[EnumRollThrower.WhatIsdiceModificator] + ": \n");

                if (int.TryParse(Console.ReadLine(), out int diceModificator))
                {
                    return ($"{diceAmount}{dice.ToString()} + {diceModificator} : {_stringBuilder.ToString()} + {diceModificator} = " + (_diceRollResult + diceModificator));
                }
            }

            return LocalizationsStash.SelectedLocalization[EnumActionsWithSheet.WrongInput];
        }
    }
}