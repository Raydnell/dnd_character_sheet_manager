namespace dnd_character_sheet
{
    public class HalfelfRaceDnd5E : RaceDnd5EBase
    {
        private string _raceName;

        public HalfelfRaceDnd5E()
        {
            _raceName = "halfelf";
        }

        public override string GetName()
        {
            return _raceName;
        }
    }
}
