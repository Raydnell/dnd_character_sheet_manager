namespace dnd_character_sheet
{
    public class HalforcRaceDND5e : SheetRaceBase
    {
        public HalforcRaceDND5e()
        {
            Name = EnumRacesDnd5E.Halforc;
            Speed = 30;
            Size = EnumCreaturesSizesDND5e.Medium;
        }
    }
}