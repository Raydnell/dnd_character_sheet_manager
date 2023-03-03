namespace dnd_character_sheet
{
    public class HumanRaceDnd5E : IRaceDnd5E
    {
        private string _raceName;

        public HumanRaceDnd5E()
        {
            _raceName = "human";
        }

        public string GetName()
        {
            return _raceName;
        }
    }
}
