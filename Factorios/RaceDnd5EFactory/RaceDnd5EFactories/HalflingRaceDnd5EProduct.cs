namespace dnd_character_sheet
{
    public class HalflingRaceDnd5EProduct : RaceDnd5EFactory
    {
        public override IRaceDnd5E CreateRaceDnd5E()
        {
            return new HalflingRaceDnd5E();
        }
    }
}
