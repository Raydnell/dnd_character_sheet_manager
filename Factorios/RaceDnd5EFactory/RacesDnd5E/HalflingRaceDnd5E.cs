namespace dnd_character_sheet
{
    public class HalflingRaceDnd5E : IRaceDnd5E
    {
        private string _raceName;

        public HalflingRaceDnd5E()
        {
            _raceName = "halfling";
        }

        public string GetName()
        {
            return _raceName;
        }
    }
}
