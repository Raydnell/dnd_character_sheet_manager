namespace dnd_character_sheet
{
    public class DwarfRaceDND5e : SheetRaceBase
    {
        public DwarfRaceDND5e()
        {
            Name = EnumRacesDnd5E.Dwarf;
            Speed = 25;
            Size = EnumCreaturesSizesDND5e.Small;
        }
    }
}