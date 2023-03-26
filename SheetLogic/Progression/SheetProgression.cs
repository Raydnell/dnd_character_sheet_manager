namespace dnd_character_sheet
{
    public abstract class SheetProgression
    {
        private int _expirience;
        public int Expirience
        {
            get
            {
                return _expirience;
            }
            protected set
            {
                _expirience = value;
            }
        }
        private int _level;
        public int Level
        {
            get
            {
                return _level;
            }
            protected set
            {
                _level = value;
            }
        }
        
        public abstract void GainExpirience(int exp);
        public abstract void LevelUp();
        public abstract int GetProficiencyBonus();
    }
}
