namespace dnd_character_sheet
{
    public class GnomeRaceDnd5EProduct : RaceDnd5EFactory
    {
        public override IRaceDnd5E CreateRaceDnd5E()
        {
            return new GnomeRaceDnd5E();
        }
    }
}
