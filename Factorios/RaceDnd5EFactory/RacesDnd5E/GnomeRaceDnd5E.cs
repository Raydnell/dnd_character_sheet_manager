namespace dnd_character_sheet
{
    public class GnomeRaceDnd5E : IRaceDnd5E
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
