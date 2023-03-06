namespace dnd_character_sheet
{
    public class HalflingRaceDnd5E : RaceDnd5EBase
    {
        private string _raceName;

        public HalflingRaceDnd5E()
        {
            _raceName = "halfling";
        }

        public override string GetName()
        {
            return _raceName;
        }
    }
}
