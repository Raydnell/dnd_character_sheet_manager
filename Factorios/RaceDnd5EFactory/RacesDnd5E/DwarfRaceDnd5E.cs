namespace dnd_character_sheet
{
    public class DwarfRaceDnd5E : RaceDnd5EBase
    {
        private string _raceName;

        public DwarfRaceDnd5E()
        {
            _raceName = "dwarf";
        }

        public override string GetName()
        {
            return _raceName;
        }
    }
}
