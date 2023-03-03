namespace dnd_character_sheet
{
    public class HalforcRaceDnd5E : IRaceDnd5E
    {
        private string _raceName;

        public HalforcRaceDnd5E()
        {
            _raceName = "halforc";
        }

        public string GetName()
        {
            return _raceName;
        }
    }
}
