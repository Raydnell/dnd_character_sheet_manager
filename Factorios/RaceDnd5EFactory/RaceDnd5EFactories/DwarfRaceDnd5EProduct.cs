namespace dnd_character_sheet
{
    public class DwarfRaceDnd5EProduct : RaceDnd5EFactory
    {
        public override IRaceDnd5E CreateRaceDnd5E()
        {
            return new DwarfRaceDnd5E();
        }
    }
}
