namespace dnd_character_sheet
{
    public class ScreenRollDice : IScreen
    {
        private bool _pointChoose;

        private int _choosenPoint;
        private int _diceCount;
        private int _diceValue;
        private int _diceResult;
        private int _diceModificator;

        private Dicer _dicer;

        public ScreenRollDice() 
        {
            _dicer = new Dicer();
        }

        public void ShowScreen()
        {
            _pointChoose = false;
            while (_pointChoose == false)
            {
                _diceCount = 0;
                _diceValue = 0;
                _diceResult = 0;
                _diceModificator = 0;

                Console.Clear();
                Console.WriteLine("Время бросать кубы!\n");
                Console.WriteLine("Сколько кубов нужно кинуть?");
                _diceCount = ConsoleInput.InputInt();

                Console.WriteLine("Сколько граней?");
                _diceValue = ConsoleInput.InputInt();

                Console.WriteLine("Какой модификатор?");
                _diceModificator = ConsoleInput.InputInt();

                _diceResult = _dicer.DiceRoll(_diceCount, _diceValue, _diceModificator);

                Console.WriteLine($"Результат броска: {_diceResult}\n");

                Console.WriteLine("Бросить ещё? (1 = Да, другое = Нет)");

                _choosenPoint = ConsoleInput.InputInt();

                if (_choosenPoint == 1)
                {
                    _pointChoose = false;
                }
                else
                {
                    _pointChoose = true;
                }
            }
        }
    }
}
