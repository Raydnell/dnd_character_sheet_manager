namespace dnd_character_sheet
{
    public class RaceDND5E : SheetRace
    {
        public RaceDND5E()
        {
            Name = string.Empty;
        }

        public override void SetRace(string race)
        {
            Name =  race;
        }
    }
}
