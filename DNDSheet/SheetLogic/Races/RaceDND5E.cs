namespace dnd_character_sheet
{
    public class RaceDND5E : SheetRace
    {
        public RaceDND5E()
        {
            Name = EnumRacesDnd5E.Human;
        }

        public override void SetRace(Enum race)
        {
            if (Enum.TryParse<EnumRacesDnd5E>(race.ToString(), out EnumRacesDnd5E result))
            {
                Name =  result;
            } 
        }
    }
}
