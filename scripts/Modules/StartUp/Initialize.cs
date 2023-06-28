namespace dnd_character_sheet
{
    public class Initialize
    {
        private string _programmFolder;
        
        private bool _isDataExist;
        private bool _isCharacterSheetsExist;
        private bool _isDataBasesExist;

        private DirectoryInfo _folderInfo;
        private LocalizationsStash _localizationsStash;
        private Config _config;
        
        public Initialize()
        {
            _programmFolder = Directory.GetCurrentDirectory();
            _folderInfo = new DirectoryInfo(_programmFolder);
            _localizationsStash = new LocalizationsStash();
            _config = new Config();
        }
        
        public void Start()
        {
            CheckAndCreateFolders();
            LoadDataBases();
            SetConsoleSettings();
            LoadConfig();
            LoadLocalization(_config.language);
            LoadEditionDND(_config.editionDND);
        }

        private void CheckAndCreateFolders()
        {
            foreach(var itemX in _folderInfo.GetDirectories())
            {
                if (itemX.Name == "Data")
                {
                    _isDataExist = true;
                    _folderInfo = new DirectoryInfo(_programmFolder + @"\Data");

                    foreach(var itemY in _folderInfo.GetDirectories())
                    {
                        if (itemY.Name == "DND5E")
                        {
                            _folderInfo = new DirectoryInfo(_programmFolder + @"\Data\DND5E");
                            
                            foreach (var itemZ in _folderInfo.GetDirectories())
                            {
                                if (itemY.Name == "CharacterSheets")
                                {
                                    _isCharacterSheetsExist = true;
                                }
                                else if (itemY.Name == "DataBases")
                                {
                                    _isDataBasesExist = true;
                                }
                            }
                        }
                    }
                }
            }

            if (_isDataExist == false)
            {
                Directory.SetCurrentDirectory(_programmFolder);
                Directory.CreateDirectory("Data");
                Directory.SetCurrentDirectory(_programmFolder + @"\Data");
                Directory.CreateDirectory("DND5E");
                Directory.SetCurrentDirectory(_programmFolder + @"\Data\DND5E");
                Directory.CreateDirectory("CharacterSheets");
                Directory.CreateDirectory("DataBases");
            }
            else if (_isCharacterSheetsExist == false)
            {
                Directory.SetCurrentDirectory(_programmFolder + @"\Data\DND5E");
                Directory.CreateDirectory("CharacterSheets");
            }
            else if (_isDataBasesExist == false)
            {
                Directory.SetCurrentDirectory(_programmFolder + @"\Data\DND5E");
                Directory.CreateDirectory("DataBases");
            }

            Directory.SetCurrentDirectory(_programmFolder);
        }

        private void LoadDataBases()
        {
            ItemsDataBaseDND5e.LoadItemsBase();
            SpellsDataBaseDND5e.LoadDB();
            TraitsDataBaseDND5e.LoadDB();
        }

        private void SetConsoleSettings()
        {
            //Если ломается кодировка
            //Console.InputEncoding = System.Text.Encoding.UTF8;
            //Console.OutputEncoding = System.Text.Encoding.UTF8;
            
            Console.SetWindowSize(140, 50);
        }

        private void LoadLocalization(EnumLanguages language)
        {
            _localizationsStash.SetUpLanguage(language);
        }

        private void LoadConfig()
        {
            _folderInfo = new DirectoryInfo(_programmFolder + @"\Data");
            
            foreach (var item in _folderInfo.GetFiles())
            {
                if (item.Name == "config.json")
                {
                    JsonSaveLoad.JsonLoad<Config>(@"Data\config.json", ref _config);
                }
            }
        }

        private void LoadEditionDND(EnumEditions edition)
        {
            CurrentHeroSheet.SetSheetEdition(edition);
        }
    }
}