namespace dnd_character_sheet
{
    public class HalfelfRaceDnd5E : IRaceDnd5E
    {
        private string _raceName;

        public HalfelfRaceDnd5E()
        {
            _raceName = "halfelf";
        }

        public string GetName()
        {
            return _raceName;
        }
    }
}
