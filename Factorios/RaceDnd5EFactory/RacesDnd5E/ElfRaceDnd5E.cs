namespace dnd_character_sheet
{
    public class ElfRaceDnd5E : IRaceDnd5E
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
