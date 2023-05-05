using Newtonsoft.Json;

namespace dnd_character_sheet
{
    public class JsonSaveLoad
    {
        public static void JsonSave<T>(string fileName, T savingFile, string pathSave)
        {
            string savedFile = JsonConvert.SerializeObject(savingFile, Formatting.Indented);
            File.WriteAllText(pathSave + fileName + ".json", savedFile);
        }

        public static void JsonLoad<T>(string pathLoad, ref T sheet)
        {
            var jsonSerializerSettings = new JsonSerializerSettings();
            
            jsonSerializerSettings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());
            jsonSerializerSettings.Converters.Add(new RaceConvertorJson());
            jsonSerializerSettings.Converters.Add(new ClassConvertorJson());
            jsonSerializerSettings.Converters.Add(new TraitConvertorJson());
            
            sheet = JsonConvert.DeserializeObject<T>(File.ReadAllText(pathLoad), jsonSerializerSettings);
        }
    }
}
