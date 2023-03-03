namespace dnd_character_sheet
{
    public class DragonbornRaceDnd5EProduct : RaceDnd5EFactory
    {
        public override IRaceDnd5E CreateRaceDnd5E()
        {
            return new DragonbornRaceDnd5E();
        }
    }
}
