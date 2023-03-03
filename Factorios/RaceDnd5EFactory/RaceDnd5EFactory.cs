namespace dnd_character_sheet
{
    public class RaceDnd5EFactory
    {
        public RaceDnd5EBase? CreateRaceDnd5E(string nameRace)
        {
            switch(nameRace)
            {
                case "human":
                    return new HumanRaceDnd5E();
            }

            return null;
        }
    }
}
