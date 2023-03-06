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
        private ISkills _skills;
        private IProgression _progression;
        private string _name;

        public CharacterSheetDnd5E()
        {
            _abilities = new AbilitiesDnd5E();
            _saveTrows = new SaveThrowsDnd5E();
            _skills = new SkillsDnd5E();
            _progression = new ProgressionDnd5E();
            _raceFactory = new RaceDnd5EFactory();
            _classFactory = new ClassDnd5EFactory();
            _name = "new_sheet";
        }

        public override void SetRace(string race)
        {
            _sheetRace = _raceFactory.CreateRaceDnd5E(race);
        }
        
        public override RaceDnd5EBase? GetRace()
        {
            return _sheetRace;
        }

        public override void SetClass(string sheetClass)
        {
            _sheetClass = _classFactory.CreateClassDnd5E(sheetClass);
        }

        public override ClassDnd5EBase? GetClass()
        {
            return _sheetClass;
        }

        public override IAbilities GetAbilities()
        {
            return _abilities;
        }

        public override ISkills GetSkills()
        {
            return _skills;
        }

        public override ISaveThrows GetSaveThrows()
        {
            return _saveTrows;
        }

        public override IProgression GetProgression()
        {
            return _progression;
        }

        public override void SetName(string name)
        {
            _name = name;
        }

        public override string GetName()
        {
            return _name;
        }
    }
}