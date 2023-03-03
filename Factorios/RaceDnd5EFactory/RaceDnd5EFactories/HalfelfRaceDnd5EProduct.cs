namespace dnd_character_sheet
{
    public class HalfelfRaceDnd5EProduct : RaceDnd5EFactory
    {
        public override IRaceDnd5E CreateRaceDnd5E()
        {
            return new HalfelfRaceDnd5E();
        }
    }
}
