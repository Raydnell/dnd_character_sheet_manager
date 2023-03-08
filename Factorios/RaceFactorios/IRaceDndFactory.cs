namespace dnd_character_sheet
{
    public interface IRaceDndFactory
    {
        public RaceDndBase CreateRace(string race);
    }
}