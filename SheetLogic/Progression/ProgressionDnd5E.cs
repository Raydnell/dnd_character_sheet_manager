namespace dnd_character_sheet
{
    public class ProgressionDnd5E : IProgression
    {
        public int expirience { get; private set; }
        public int level { get; private set; }

        public ProgressionDnd5E()
        {
            expirience = 0;
            level = 1;
        }
        
        public void GainExpirience(int exp)
        {
            expirience += exp;
            if(expirience <= 299)
                level = 1;
            else if(expirience <= 899)
                level = 2;
            else if(expirience <= 2699)
                level = 3;
        }

        public void LevelUp()
        {
            level++;
        }

        public int GetProficiencyBonus()
        {
            if (level <= 4)
                return 2;
            else if (level <= 8)
                return 3;
            else if (level <= 12)
                return 4;
            else if (level <= 16)
                return 5;
            else
                return 6;
        }
    }
}