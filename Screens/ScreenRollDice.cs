using System;

namespace dnd_character_sheet
{
    public class ScreenRollDice
    {
        private bool _pointChoose;

        private int _choosenPoint;
        private int _diceCount;
        private int _diceValue;
        private int _diceResult;
        private int _diceModificator;

        private CheckInput _checkInput;
        private Dicer _dicer;

        public ScreenRollDice() 
        {
            _pointChoose = false;
            _choosenPoint = 0;
            _checkInput = new CheckInput();
            _dicer = new Dicer();
        }

        public void RollDice()
        {
            _pointChoose = false;

            while (_pointChoose == false)
            {
                _diceCount = 0;
                _diceValue = 0;
                _diceResult = 0;
                _diceModificator = 0;

                Console.Clear();
                Console.WriteLine("Время бросать кубы!");
                Console.WriteLine("Сколько кубов нужно кинуть?");
                _diceCount = _checkInput.CheckIntInput();

                Console.WriteLine("Сколько граней?");
                _diceValue = _checkInput.CheckIntInput();

                Console.WriteLine("Какой модификатор?");
                _diceModificator = _checkInput.CheckIntInput();

                _diceResult = _dicer.DiceRoll(_diceCount, _diceValue, _diceModificator);

                Console.Write($"Результат броска: {_diceResult}\n");

                Console.WriteLine("Бросить ещё? (1 = Да, другое = Нет)");

                _choosenPoint = _checkInput.CheckIntInput();

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
