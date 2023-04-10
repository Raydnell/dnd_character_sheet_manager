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
            if (Enum.TryParse<EnumRacesDnd5E>(race, out EnumRacesDnd5E result))
            {
                Name =  result.ToString();
            }
        }
    }
}
