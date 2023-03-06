namespace dnd_character_sheet
{
    public class ProgressionDnd5E : IProgression
    {
        private int _expirience;
        private int _level;

        public ProgressionDnd5E()
        {
            _expirience = 0;
            _level = 1;
        }
        
        public void GainExpirience(int exp)
        {
            _expirience += exp;
            if(_expirience <= 299)
                _level = 1;
            else if(_expirience <= 899)
                _level = 2;
            else if(_expirience <= 2699)
                _level = 3;
        }

        public void LevelUp()
        {
            _level++;
        }

        public int GetProficiencyBonus()
        {
            if (_level <= 4)
                return 2;
            else if (_level <= 8)
                return 3;
            else if (_level <= 12)
                return 4;
            else if (_level <= 16)
                return 5;
            else
                return 6;
        }

        public int GetExpirience()
        {
            return _expirience;
        }
    }
}