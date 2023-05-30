namespace dnd_character_sheet
{
    public class ElfRaceDND5e : SheetRaceBase
    {
        public ElfRaceDND5e()
        {
            Name = EnumRacesDnd5E.Elf;
            Speed = 30;
            Size = EnumCreaturesSizesDND5e.Medium;
        }
    }
}