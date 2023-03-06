using System;

namespace dnd_character_sheet
{
    public class Dicer
    {
        private Random _random;
        private int _diceResultFull;

        public Dicer()
        {
            _random = new Random();
        }

        public int DiceRoll(int diceCount, int diceValue, int diceModificator)
        {
            _diceResultFull = 0;
            int diceResultCurrent = 0;

            Console.WriteLine($"Бросок {diceCount}d{diceValue}+{diceModificator}!\n");

            for (int i = 0; i < diceCount; i++)
            {
                diceResultCurrent = _random.Next(1, diceValue + 1);
                Console.WriteLine($"Бросок! {diceResultCurrent}!");
                _diceResultFull += diceResultCurrent;
            }

            return _diceResultFull + diceModificator;
        }
    }
}
