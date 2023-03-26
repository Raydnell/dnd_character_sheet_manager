namespace dnd_character_sheet
{
    public abstract class CharacterSheetBase
    {
        private string _name = string.Empty;
        private string _edition = string.Empty;        
        private RaceDndBase _sheetRace;
        private ClassDndBase _sheetClass;
        private SheetAbilities _sheetAbilities;
        private SheetSkills _sheetSkills;
        private SheetProgression _sheetProgression;
        private SheetSaveThrows _sheetSaveThrows;
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

        public string Edition
        {
            get
            {
                return _edition;
            }
            protected set
            {
                _edition = value;
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

        public SheetAbilities SheetAbilities
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

        public SheetSkills SheetSkills
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
        
        public SheetProgression SheetProgression
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

        public SheetSaveThrows SheetSaveThrows
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