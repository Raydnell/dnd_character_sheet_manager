namespace dnd_character_sheet
{
    public class DragonbornRaceDnd5E : RaceDnd5EBase
    {
        private string _raceName;

        public DragonbornRaceDnd5E()
        {
            _raceName = "dragonborn";
        }

        public override string GetName()
        {
            return _raceName;
        }
    }
}
