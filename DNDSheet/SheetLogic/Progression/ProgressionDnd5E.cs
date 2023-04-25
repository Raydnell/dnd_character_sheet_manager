namespace dnd_character_sheet
{
    public class ProgressionDnd5E : SheetProgression
    {
        public ProgressionDnd5E()
        {
            Expirience = 0;
            Level = 1;
        }
        
        public override void GainExpirience(int exp)
        {
            Expirience += exp;
            CalculateLevel();
        }

        public override void LevelUp()
        {
            Level++;
        }

        public override int GetProficiencyBonus()
        {
            if (Level <= 4)
                return 2;
            else if (Level <= 8)
                return 3;
            else if (Level <= 12)
                return 4;
            else if (Level <= 16)
                return 5;
            else
                return 6;
        }

        public override void LowerExpirience(int exp)
        {
            Expirience -= exp;
            CalculateLevel();
        }

        public override void CalculateLevel()
        {
            if(Expirience <= 299)
                Level = 1;
            else if(Expirience <= 899)
                Level = 2;
            else if(Expirience <= 2699)
                Level = 3;
        }
    }
}