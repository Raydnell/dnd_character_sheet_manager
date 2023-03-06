namespace dnd_character_sheet
{
    public class TieflingRaceDnd5E : RaceDnd5EBase
    {
        private string _raceName;

        public TieflingRaceDnd5E()
        {
            _raceName = "tiefling";
        }

        public override string GetName()
        {
            return _raceName;
        }
    }
}
