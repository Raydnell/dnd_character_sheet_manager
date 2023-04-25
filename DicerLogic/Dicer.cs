namespace dnd_character_sheet
{
    public class Dicer
    {
        private Random _random;
        private int _diceResultFull;
        private int _diceResultCurrent;
        private IUserOutput _userOutput;

        public Dicer()
        {
            _random = new Random();
            _userOutput = new ConsoleOutput();
        }

        public int DiceRoll(int diceCount, int diceValue, int diceModificator)
        {
            _diceResultFull = 0;
            _diceResultCurrent = 0;

            _userOutput.Print($"Бросок {diceCount}d{diceValue}+{diceModificator}!\n");

            _userOutput.Print(@"Сколько выпало на кубике\ах:");
            for (int i = 0; i < diceCount; i++)
            {
                _diceResultCurrent = _random.Next(1, diceValue + 1);
                _userOutput.Print(_diceResultCurrent);
                _diceResultFull += _diceResultCurrent;
            }

            _userOutput.Print("Сумма всех кубов" + _diceResultFull);
            return _diceResultFull + diceModificator;
        }
    }
}
