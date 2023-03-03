namespace dnd_character_sheet
{
    public class DragonbornRaceDnd5E : IRaceDnd5E
    {
        private string _raceName;

        public DragonbornRaceDnd5E()
        {
            _raceName = "dragonborn";
        }

        public string GetName()
        {
            return _raceName;
        }
    }
}
