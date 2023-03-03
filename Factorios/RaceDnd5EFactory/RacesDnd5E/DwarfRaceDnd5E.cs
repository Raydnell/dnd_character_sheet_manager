namespace dnd_character_sheet
{
    public class DwarfRaceDnd5E : IRaceDnd5E
    {
        private string _raceName;

        public DwarfRaceDnd5E()
        {
            _raceName = "dwarf";
        }

        public string GetName()
        {
            return _raceName;
        }
    }
}
