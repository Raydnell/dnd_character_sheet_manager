namespace dnd_character_sheet
{
    public class PersonalityDND5E : SheetPersonality
    {
        public PersonalityDND5E()
        {
            PersonalityList = new Dictionary<string, string>();
        }

        public override void AddPersonality(string personality, string value)
        {
            PersonalityList[personality] = value;
        }
    }
}