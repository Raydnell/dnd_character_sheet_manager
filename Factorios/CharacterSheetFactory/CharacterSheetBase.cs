namespace dnd_character_sheet
{
    public abstract class CharacterSheetBase
    {
        private string _name = string.Empty;        
        private RaceDndBase _sheetRace;
        private ClassDndBase _sheetClass;
        private IAbilities _sheetAbilities;
        private ISkills _sheetSkills;
        private IProgression _sheetProgression;
        private ISaveThrows _sheetSaveThrows;
        private IRaceDndFactory _raceFactory;
        private IClassDndFactory _classFactory;

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        public RaceDndBase SheetRace
        {
            get
            {
                return _sheetRace;
            }
            protected set
            {
                _sheetRace = value;
            }
        }

        public ClassDndBase SheetClass
        {
            get
            {
                return _sheetClass;
            }
            protected set
            {
                _sheetClass = value;
            }
        }

        public IAbilities SheetAbilities
        {
            get
            {
                return _sheetAbilities;
            }
            protected set
            {
                _sheetAbilities = value;
            }
        }

        public ISkills SheetSkills
        {
            get
            {
                return _sheetSkills;
            }
            protected set
            {
                _sheetSkills = value;
            }
        }
        
        public IProgression SheetProgression
        {
            get
            {
                return _sheetProgression;
            }
            protected set
            {
                _sheetProgression = value;
            }
        }

        public ISaveThrows SheetSaveThrows
        {
            get
            {
                return _sheetSaveThrows;
            }
            protected set
            {
                _sheetSaveThrows = value;
            }
        }

        public IRaceDndFactory RaceFactory
        {
            get
            {
                return _raceFactory;
            }
            protected set
            {
                _raceFactory = value;
            }
        }

        public IClassDndFactory ClassFactory
        {
            get
            {
                return _classFactory;
            }
            protected set
            {
                _classFactory = value;
            }
        }
        
        public abstract void SetRace(string race);
        public abstract void SetClass(string sheetClass);
    }
}