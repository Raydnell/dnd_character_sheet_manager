using Newtonsoft.Json;

namespace dnd_character_sheet
{
    public abstract class SheetPersonality
    {
        private string _background;
        
        [JsonProperty("Background")]
        public string Background
        {
            get
            {
                return _background;
            }
            protected set
            {
                _background = value;
            }
        }

        private string _alignment;

        [JsonProperty("Alignment")]
        public string Alignment
        {
            get
            {
                return _alignment;
            }
            protected set
            {
                _alignment = value;
            }
        }

        private string _personalityTraits;

        [JsonProperty("PersonalityTraits")]
        public string PersonalityTraits
        {
            get
            {
                return _personalityTraits;
            }
            protected set
            {
                _personalityTraits = value;
            }
        }

        private string _ideals;

        [JsonProperty("Ideals")]
        public string Ideals
        {
            get
            {
                return _ideals;
            }
            protected set
            {
                _ideals = value;
            }
        }

        private string _bonds;

        [JsonProperty("Bonds")]
        public string Bonds
        {
            get
            {
                return _bonds;
            }
            protected set
            {
                _bonds = value;
            }
        }

        private string _flaws;

        [JsonProperty("Flaws")]
        public string Flaws
        {
            get
            {
                return _flaws;
            }
            protected set
            {
                _flaws = value;
            }
        }

        private int _age;

        [JsonProperty("Age")]
        public int Age
        {
            get
            {
                return _age;
            }
            protected set
            {
                _age = value;
            }
        }

        private int _height;

        [JsonProperty("Height")]
        public int Height
        {
            get
            {
                return _height;
            }
            protected set
            {
                _height = value;
            }
        }

        private int _weight;

        [JsonProperty("Weight")]
        public int Weight
        {
            get
            {
                return _weight;
            }
            protected set
            {
                _weight = value;
            }
        }

        private string _eyes;

        [JsonProperty("Eyes")]
        public string Eyes
        {
            get
            {
                return _eyes;
            }
            protected set
            {
                _eyes = value;
            }
        }

        private string _skin;

        [JsonProperty("Skin")]
        public string Skin
        {
            get
            {
                return _skin;
            }
            protected set
            {
                _skin = value;
            }
        }

        private string _hair;

        [JsonProperty("Hair")]
        public string Hair
        {
            get
            {
                return _hair;
            }
            protected set
            {
                _hair = value;
            }
        }

        public abstract void SetBackground(string text);

        public abstract void SetAlignment(string text);
        
        public abstract void SetPersonalityTraits(string text);
        
        public abstract void SetIdeals(string text);
        
        public abstract void SetBonds(string text);
        
        public abstract void SetFlaws(string text);
        
        public abstract void SetAge(int age);
        
        public abstract void SetHeight(int height);
        
        public abstract void SetWeight(int weight);
        
        public abstract void SetEyes(string text);
        
        public abstract void SetSkin(string text);
        
        public abstract void SetHair(string text);
    }
}
