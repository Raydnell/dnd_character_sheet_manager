namespace dnd_character_sheet
{
    public class ElfRaceDnd5EProduct : RaceDnd5EFactory
    {
        public override IRaceDnd5E CreateRaceDnd5E()
        {
            return new ElfRaceDnd5E();
        }
    }
}
