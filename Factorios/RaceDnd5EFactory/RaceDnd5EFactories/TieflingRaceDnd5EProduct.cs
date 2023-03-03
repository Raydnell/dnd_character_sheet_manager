namespace dnd_character_sheet
{
    public class TieflingRaceDnd5EProduct : RaceDnd5EFactory
    {
        public override IRaceDnd5E CreateRaceDnd5E()
        {
            return new TieflingRaceDnd5E();
        }
    }
}
