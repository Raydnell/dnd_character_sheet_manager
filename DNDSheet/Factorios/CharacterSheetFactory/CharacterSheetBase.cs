namespace dnd_character_sheet
{
    public abstract class CharacterSheetBase
    {
        private string _name = string.Empty;
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

        private string _edition = string.Empty;        
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

        private SheetRace _sheetRace;
        public SheetRace SheetRace
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

        private SheetClass _sheetClass;
        public SheetClass SheetClass
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

        private SheetAbilities _sheetAbilities;
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

        private SheetSkills _sheetSkills;
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

        private SheetProgression _sheetProgression;
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

        private SheetSaveThrows _sheetSaveThrows;
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

        private SheetPersonality _sheetPersonality;
        public SheetPersonality SheetPersonality
        {
            get
            {
                return _sheetPersonality;
            }
            protected set
            {
                _sheetPersonality = value;
            }
        }

        private SheetCombatAbilities _sheetCombatAbilities;

        public SheetCombatAbilities SheetCombatAbilities
        {
            get
            {
                return _sheetCombatAbilities;
            }
            protected set
            {
                _sheetCombatAbilities = value;
            }
        }

        private SheetProficiencies _sheetProficiencies;

        public SheetProficiencies SheetProficiencies
        {
            get
            {
                return _sheetProficiencies;
            }
            protected set
            {
                _sheetProficiencies = value;
            }
        }

        private SheetInventory _sheetInventory;

        public SheetInventory SheetInventory
        {
            get
            {
                return _sheetInventory;
            }
            protected set
            {
                _sheetInventory = value;
            }
        }
    }
}