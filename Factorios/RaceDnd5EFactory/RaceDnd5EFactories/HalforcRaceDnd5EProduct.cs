namespace dnd_character_sheet
{
    public class HalforcRaceDnd5EProduct : RaceDnd5EFactory
    {
        public override IRaceDnd5E CreateRaceDnd5E()
        {
            return new HalforcRaceDnd5E();
        }
    }
}
