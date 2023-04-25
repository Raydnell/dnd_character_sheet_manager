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

        private IUserInput _userInput;
        private IUserOutput _userOutput;
        private Dicer _dicer;

        public ScreenRollDice() 
        {
            _dicer = new Dicer();
            _userInput = new ConsoleInput();
            _userOutput = new ConsoleOutput();
        }

        public void ShowScreen(ref CharacterSheetBase heroSheet, Enum language)
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
                _diceCount = _userInput.InputInt();

                Console.WriteLine("Сколько граней?");
                _diceValue = _userInput.InputInt();

                Console.WriteLine("Какой модификатор?");
                _diceModificator = _userInput.InputInt();

                _diceResult = _dicer.DiceRoll(_diceCount, _diceValue, _diceModificator);

                _userOutput.Print($"Результат броска: {_diceResult}\n");

                _userOutput.Print("Бросить ещё? (1 = Да, другое = Нет)");

                _choosenPoint = _userInput.InputInt();;

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
