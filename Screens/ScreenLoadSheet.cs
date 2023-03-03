using System;
using System.IO;

namespace dnd_character_sheet
{
    internal class ScreenLoadSheet
    {
        private JsonSaveLoad _jsonSaveLoad;
        private string _name;

        public ScreenLoadSheet()
        {
            _jsonSaveLoad = new JsonSaveLoad();
            _name = string.Empty;
        }

        public CharacterSheetDnd5E LoadSheetFromFile()
        {
            Console.Clear();
            Console.WriteLine("Экран загрузки листа персонажа.\n");

            Console.Write("Введите имя персонажа, которого нужно загрузить: ");

            _name = Console.ReadLine();

            if (File.Exists(@"dnd5e_char_sheets\" + _name + ".json"))
            {
                CharacterSheetDnd5E loadedCharSheet = _jsonSaveLoad.JsonLoad(_name);
                Console.WriteLine("Герой загружен.");
                Console.ReadKey();

                return loadedCharSheet;
            }
            else
            {
                Console.WriteLine("Такого героя не существует, попробуй снова");
                Console.ReadKey();

                return null;
            }
        }
    }
}
