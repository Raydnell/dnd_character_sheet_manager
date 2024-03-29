﻿using Newtonsoft.Json;

namespace dnd_character_sheet
{
    public abstract class SheetProgression
    {
        private int _expirience;
        
        [JsonProperty("Expirience")]
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
        
        [JsonProperty("Level")]
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
        public abstract int GetProficiencyBonus();
        public abstract void LowerExpirience(int exp);
        public abstract void CalculateLevel();
    }
}
