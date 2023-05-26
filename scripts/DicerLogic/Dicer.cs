namespace dnd_character_sheet
{
    public class Dicer
    {
        private Random _random;
        private int _diceResultFull;
        private int _diceResultCurrent;

        public Dicer()
        {
            _random = new Random();
        }

        public int DiceRoll(int diceCount, int diceValue, int diceModificator)
        {
            _diceResultFull = 0;
            _diceResultCurrent = 0;

            Console.WriteLine($"Бросок {diceCount}d{diceValue}+{diceModificator}!\n");

            Console.WriteLine(@"Сколько выпало на кубике\ах:");
            for (int i = 0; i < diceCount; i++)
            {
                _diceResultCurrent = _random.Next(1, diceValue + 1);
                Console.WriteLine(_diceResultCurrent);
                _diceResultFull += _diceResultCurrent;
            }

            Console.WriteLine("Сумма всех кубов" + _diceResultFull);
            return _diceResultFull + diceModificator;
        }
    }
}
