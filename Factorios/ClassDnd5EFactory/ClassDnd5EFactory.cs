namespace dnd_character_sheet
{
    public class ClassDnd5EFactory
    {
        public ClassDnd5EBase? CreateClassDnd5E(string className)
        {
            switch(className)
            {
                case "barbarian":
                    return new BarbarianClassDnd5E();
            }
            return null;
        }
    }
}
