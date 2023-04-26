namespace dnd_character_sheet
{
    public class PersonalityDND5E : SheetPersonality
    {
        public PersonalityDND5E()
        {
            PersonalityList = new Dictionary<EnumPersonalitiesDND5E, string>();
        }

        public override void AddPersonality(EnumPersonalitiesDND5E personality, string value)
        {
            PersonalityList[personality] = value;
        }
    }
}