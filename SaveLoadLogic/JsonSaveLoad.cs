using Newtonsoft.Json;

namespace dnd_character_sheet
{
    class JsonSaveLoad
    {
        public void JsonSave<T>(string fileName, ref T savingFile, string pathSave)
        {
            string savedFile = JsonConvert.SerializeObject(savingFile);
            File.WriteAllText(pathSave + fileName + ".json", savedFile);
        }

        public void JsonLoad<T>(string pathLoad, ref T sheet)
        {
            sheet = JsonConvert.DeserializeObject<T>(File.ReadAllText(pathLoad));
        }
    }
}
