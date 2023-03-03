namespace dnd_character_sheet
{
    public class ElfRaceDnd5E : RaceDnd5EBase
    {
        private string _raceName;

        public ElfRaceDnd5E()
        {
            _raceName = "elf";
        }

        public string GetName()
        {
            return _raceName;
        }
    }
}
