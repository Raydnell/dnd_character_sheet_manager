namespace dnd_character_sheet
{
    public class GnomeRaceDnd5E : RaceDnd5EBase
    {
        private string _raceName;

        public GnomeRaceDnd5E()
        {
            _raceName = "gnome";
        }

        public string GetName()
        {
            return _raceName;
        }
    }
}
