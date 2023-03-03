namespace dnd_character_sheet
{
    public class TieflingRaceDnd5E : IRaceDnd5E
    {
        private string _raceName;

        public TieflingRaceDnd5E()
        {
            _raceName = "tiefling";
        }

        public string GetName()
        {
            return _raceName;
        }
    }
}
