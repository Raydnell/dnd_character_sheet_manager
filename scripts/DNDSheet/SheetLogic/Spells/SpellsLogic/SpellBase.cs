using Newtonsoft.Json;

namespace dnd_character_sheet
{
    public abstract class SpellBase
    {
        private Random _random = new Random();

        private string _name;

        [JsonProperty("Name")]
        public string Name { get { return _name; } protected set { _name = value; } }

        private int _level;

        [JsonProperty("Level")]
        public int Level { get { return _level; } protected set { _level = value; } }

        private int _id;

        [JsonProperty("Id")]
        public int Id { get { return _id; } protected set { _id = value; } }

        public void SetName(string name)
        {
            Name = name;
        }

        public void SetLevel(int level)
        {
            Level = level;
        }

        public void SetID()
        {
            Id = RollRandom.LetsRoll.Next(1000, 10000);
        }
    }
}