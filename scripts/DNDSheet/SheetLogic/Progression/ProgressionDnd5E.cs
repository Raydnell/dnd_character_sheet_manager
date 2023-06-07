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
            if (Expirience - exp < 0)
            {
                Expirience = 0;
            }
            else
            {
                Expirience -= exp;
            }
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
            else if(Expirience <= 6499)
                Level = 4;
            else if(Expirience <= 13999)
                Level = 5;
            else if(Expirience <= 22999)
                Level = 6;
            else if(Expirience <= 33999)
                Level = 7;
            else if(Expirience <= 47999)
                Level = 8;
            else if(Expirience <= 63999)
                Level = 9;
            else if(Expirience <= 84999)
                Level = 10;
            else if(Expirience <= 99999)
                Level = 11;
            else if(Expirience <= 119999)
                Level = 12;
            else if(Expirience <= 139999)
                Level = 13;
            else if(Expirience <= 164999)
                Level = 14;
            else if(Expirience <= 194999)
                Level = 15;
            else if(Expirience <= 224999)
                Level = 16;
            else if(Expirience <= 264999)
                Level = 17;
            else if(Expirience <= 304999)
                Level = 18;
            else if(Expirience <= 354999)
                Level = 19;
            else if(Expirience >= 355000)
                Level = 20;
        }
    }
}