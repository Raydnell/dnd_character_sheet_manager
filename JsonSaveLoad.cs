using System.IO;
using System.Text.Json;

namespace dnd_character_sheet
{
    class JsonSaveLoad
    {
        private string _pathForFiles;
        private string _readedJson;
        private CharacterSheetDnd5E _loadedSheet;

        public JsonSaveLoad() 
        {
            _pathForFiles = @"dnd5e_char_sheets\";
            _readedJson = "";
            _loadedSheet = new CharacterSheetDnd5E();
        }

        public void JsonSave(string fileName, CharacterSheetDnd5E savingFile)
        {
            string savedFile = JsonSerializer.Serialize(savingFile);
            File.WriteAllText(_pathForFiles + fileName + ".json", savedFile);
        }

        public CharacterSheetDnd5E? JsonLoad(string fileName)
        {
            _readedJson = File.ReadAllText(_pathForFiles + fileName + ".json");
            _loadedSheet = JsonSerializer.Deserialize<CharacterSheetDnd5E>(_readedJson);

            return _loadedSheet;
        }
    }
}
