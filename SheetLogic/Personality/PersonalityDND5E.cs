namespace dnd_character_sheet
{
    public class PersonalityDND5E : SheetPersonality
    {
        public PersonalityDND5E()
        {
            Background = string.Empty;
            Alignment = string.Empty;
            PersonalityTraits = string.Empty;
            Ideals = string.Empty;
            Bonds = string.Empty;
            Flaws = string.Empty;
            Age = 1;
            Height = 1;
            Weight = 1;
            Eyes = string.Empty;
            Skin = string.Empty;
            Hair = string.Empty;
        }

        public override void SetBackground(string text)
        {
            Background = text;
        }

        public override void SetAlignment(string text)
        {
            Alignment = text;
        }
        
        public override void SetPersonalityTraits(string text)
        {
            PersonalityTraits = text;
        }
        
        public override void SetIdeals(string text)
        {
            Ideals = text;
        }
        
        public override void SetBonds(string text)
        {
            Bonds = text;
        }
        
        public override void SetFlaws(string text)
        {
            Flaws = text;
        }
        
        public override void SetAge(int age)
        {
            Age = age;
        }
        
        public override void SetHeight(int height)
        {
            Height = height;
        }
        
        public override void SetWeight(int weight)
        {
            Weight = weight;
        }
        
        public override void SetEyes(string text)
        {
            Eyes = text;
        }
        
        public override void SetSkin(string text)
        {
            Skin = text;
        }
        
        public override void SetHair(string text)
        {
            Hair = text;
        }
    }
}