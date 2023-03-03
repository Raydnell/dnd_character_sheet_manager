namespace dnd_character_sheet
{
    public class HalforcRaceDnd5E : RaceDnd5EBase
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
