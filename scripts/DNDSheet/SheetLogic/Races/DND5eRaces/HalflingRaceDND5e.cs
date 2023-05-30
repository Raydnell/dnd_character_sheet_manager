namespace dnd_character_sheet
{
    public class HalflingRaceDND5e : SheetRaceBase
    {
        public HalflingRaceDND5e()
        {
            Name = EnumRacesDnd5E.Halfling;
            Speed = 25;
            Size = EnumCreaturesSizesDND5e.Small;
        }
    }
}