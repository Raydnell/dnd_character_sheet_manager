namespace dnd_character_sheet
{
    public class DragonbornRaceDND5e : SheetRaceBase
    {
        public DragonbornRaceDND5e()
        {
            Name = EnumRacesDnd5E.Dragonborn;
            Speed = 30;
            Size = EnumCreaturesSizesDND5e.Medium;
        }
    }
}