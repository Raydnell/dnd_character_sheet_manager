namespace dnd_character_sheet
{
    public class CharacterSheetDnd5E : CharacterSheetBase
    {
        private ClassDnd5EBase? _sheetClass;
        private RaceDnd5EBase? _sheetRace;
        private RaceDnd5EFactory _raceFactory;
        private ClassDnd5EFactory _classFactory;
        private IAbilities _abilities;
        private ISaveThrows _saveTrows;

        public CharacterSheetDnd5E()
        {
            _raceFactory = new RaceDnd5EFactory();
            _classFactory = new ClassDnd5EFactory();
            _abilities = new AbilitiesDnd5E();
            _saveTrows = new SaveThrowsDnd5E();
        }

        public override void SetRace(string raceName)
        {
            _sheetRace = _raceFactory.CreateRaceDnd5E(raceName);
        }

        public override void SetClass(string className)
        {
            _sheetClass = _classFactory.CreateClassDnd5E(className);
            _saveTrows.SetSaveTrows(className);
        }
    }
}