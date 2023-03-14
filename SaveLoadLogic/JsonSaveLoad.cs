using System.Text.Json;

namespace dnd_character_sheet
{
    class JsonSaveLoad
    {
        JsonSerializerOptions options = new JsonSerializerOptions
        {
            WriteIndented = true
        };
        
        public void JsonSave(string fileName, CharacterSheetBase savingFile, string pathSave)
        {
            string savedFile = JsonSerializer.Serialize<CharacterSheetBase>(savingFile, options);
            File.WriteAllText(pathSave + fileName + ".json", savedFile);
        }

        public CharacterSheetBase JsonLoad(string fileName, string pathLoad)
        {
            return JsonSerializer.Deserialize<CharacterSheetBase>(File.ReadAllText(pathLoad + fileName + ".json"));
        }
    }
}
