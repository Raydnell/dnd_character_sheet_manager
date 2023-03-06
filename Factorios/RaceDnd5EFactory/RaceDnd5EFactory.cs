namespace dnd_character_sheet
{
    public class RaceDnd5EFactory
    {
        public RaceDnd5EBase? CreateRaceDnd5E(string nameRace)
        {
            switch(nameRace)
            {
                case "gnome":
                    return new GnomeRaceDnd5E();

                case "dwarf":
                    return new DwarfRaceDnd5E();

                case "dragonborn":
                    return new DragonbornRaceDnd5E();

                case "halforc":
                    return new HalforcRaceDnd5E();

                case "halfling":
                    return new HalflingRaceDnd5E();

                case "halfelf":
                    return new HalfelfRaceDnd5E();

                case "tiefling":
                    return new TieflingRaceDnd5E();

                case "human":
                    return new HumanRaceDnd5E();

                case "elf":
                    return new ElfRaceDnd5E();

                default:
                    return null;
            }
        }
    }
}
