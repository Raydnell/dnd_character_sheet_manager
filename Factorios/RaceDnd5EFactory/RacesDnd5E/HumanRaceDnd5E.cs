namespace dnd_character_sheet
{
    public class HumanRaceDnd5E : RaceDnd5EBase
    {
        private string _raceName;

        public HumanRaceDnd5E()
        {
            _raceName = "human";
        }

        public override string GetName()
        {
            return _raceName;
        }
    }
}
