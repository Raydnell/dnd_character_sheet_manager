namespace dnd_character_sheet
{
    public class ClassDnd5EFactory : IClassDndFactory
    {
        public ClassDndBase CreateClassDnd(string sheetClass)
        {
            switch(sheetClass)
            {
                case "bard":
                    return new BardClassDnd5E();

                case "barbarian":
                    return new BarbarianClassDnd5E();

                case "fighter":
                    return new FighterClassDnd5E();

                case "wizard":
                    return new WizardClassDnd5E();

                case "druid":
                    return new DruidClassDnd5E();

                case "cleric":
                    return new ClericClassDnd5E();

                case "warlock":
                    return new WarlockClassDnd5E();

                case "monk":
                    return new MonkClassDnd5E();

                case "paladin":
                    return new PaladinClassDnd5E();

                case "rogue":
                    return new RogueClassDnd5E();

                case "ranger":
                    return new RangerClassDnd5E();

                case "sorcerer":
                    return new SorcererClassDnd5E();

                default:
                    return null;
            }
        }
    }
}
