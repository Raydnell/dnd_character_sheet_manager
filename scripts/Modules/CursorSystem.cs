namespace dnd_character_sheet
{
    public class CursorSystem
    {
        private int _cursorPosition;

        private string _cursor;
        
        private bool _isNeedExit;

        public CursorSystem()
        {
            _cursor = ">";
        }

        public ConsoleKey CursorSelector(int left, int top, int height, ref int cursorPotion)
        {
            var pressedKey = new ConsoleKeyInfo();
            
            Console.CursorVisible = false;
            
            _cursorPosition = cursorPotion;
            DrawCursor(left, top + _cursorPosition, height - 1);
            
            _isNeedExit = false;
            while (_isNeedExit == false)
            {
                pressedKey = Console.ReadKey();
                switch (pressedKey.Key)
                {
                    case ConsoleKey.UpArrow:
                        MoveCursorUp();
                        DrawCursor(left, top + _cursorPosition, height - 1);
                        break;
                    
                    case ConsoleKey.DownArrow:
                        MoveCursorDown(height - 1);
                        DrawCursor(left, top + _cursorPosition, height - 1);
                        break;

                    default:
                        cursorPotion = _cursorPosition;
                        _isNeedExit = true;
                        break;
                }
            }

            Console.CursorVisible = true;
            return pressedKey.Key;
        }

        private void DrawCursor(int left, int top, int height)
        {
            for (int i = 0; i <= height; i++)
            {
                Console.SetCursorPosition(left, i + 1);
                Console.Write(" ");
            }
            Console.SetCursorPosition(left, top);
            Console.Write(_cursor);
        }

        private void MoveCursorUp()
        {
            if (_cursorPosition - 1 >= 0)
            {
                _cursorPosition--;
            }
        }

        private void MoveCursorDown(int height)
        {
            if (_cursorPosition + 1 <= height)
            {
                _cursorPosition++;
            }
        }
    }
}