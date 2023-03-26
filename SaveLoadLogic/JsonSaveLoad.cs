using System.Text.Json;

namespace dnd_character_sheet
{
    class JsonSaveLoad
    {
        public void JsonSave(string fileName, CharacterSheetBase savingFile, string pathSave)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string savedFile = JsonSerializer.Serialize(savingFile, options);
            File.WriteAllText(pathSave + fileName + ".json", savedFile);
        }

        public void JsonLoad(string pathLoad, CharacterSheetBase sheet)
        {
            string readedFile = File.ReadAllText(pathLoad);
            Console.WriteLine(readedFile);
            Console.ReadKey();
            CharacterSheetBase tempSheet2 = JsonSerializer.Deserialize<CharacterSheetDnd5E>(readedFile);
            
            sheet = JsonSerializer.Deserialize<CharacterSheetDnd5E>(readedFile);
        }
    }
}
