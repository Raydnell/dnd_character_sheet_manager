﻿using System;
using System.Collections.Generic;

namespace dnd_character_sheet
{
    public class ScreenSheetCreate
    {
        private int _choosenPoint;
        private bool _pointChoose;
        private JsonSaveLoad _jsonSaveLoad;
        private CheckInput _checkInput;

        private string? _input;

        private Dictionary<string, int> _abilities;

        private bool _isSet;

        private CharacterSheetFactory _sheetFactory;

        public ScreenSheetCreate() 
        {
            _choosenPoint = 0;
            _pointChoose = false;
            _jsonSaveLoad = new JsonSaveLoad();
            _checkInput = new CheckInput();
            _abilities = new Dictionary<string, int>();
            _sheetFactory = new CharacterSheetFactory();
        }

        public CharacterSheetDnd5E SheetCreate(CharacterSheetBase _currentHeroSheet)
        {
            Console.Clear();
            Console.WriteLine("Пришло время создать героя!\n");

            _currentHeroSheet = SetEdition();

            Console.Write("Введите имя героя: ");
            _currentHeroSheet.SetName(Console.ReadLine());

            Console.Clear();
            _currentHeroSheet.SetRace(ChooseRace());

            Console.Clear();
            _currentHeroSheet.SetClass(ChooseClass());

            Console.Clear();
            _currentHeroSheet.SetSkills();

            Console.Clear();
            _currentHeroSheet.SetAbilities();

            Console.Clear();
            Console.WriteLine("Вот ваш новый герой!\n");

            _currentHeroSheet.PrintSheetInfoAll();

            Console.WriteLine("Хотите сохранить этого героя?\n1. Да\n2. Нет");
            _choosenPoint = _checkInput.CheckIntInput();

            _pointChoose = false;

            while (_pointChoose == false)
            {
                switch (_choosenPoint)
                {
                    case 0:
                    default:
                        Console.WriteLine("Введено неверное число, нужно ввести число из списка.");
                        Console.ReadKey();
                        break;

                    case 1:
                        _jsonSaveLoad.JsonSave(_currentHeroSheet.GetName(), _currentHeroSheet);
                        _pointChoose = true;
                        break;

                    case 2:
                        _pointChoose = true;
                        break;
                }
            }

            return _currentHeroSheet;
        }

        private string ChooseFromList(List<string> availableList)
        {
            while (true)
            {
                foreach (string item in availableList)
                {
                    Console.WriteLine(item);
                }

                Console.WriteLine("\n");
                _input = Console.ReadLine();

                if (availableList.Contains(_input))
                {
                    Console.WriteLine($"Вы выбрали {_input}");
                    return _input;
                }
                else
                {
                    Console.WriteLine("Вы ввели значение не из списка, повторите попытку.");
                }
            }
        }

        private Dictionary<string, bool> SaveThrowSet(string dndClass, Dictionary<string, bool> saveThrows)
        {
            switch (dndClass)
            {
                case "bard":
                    saveThrows["dex"] = true;
                    saveThrows["cha"] = true;
                    break;

                case "barbarian":
                    saveThrows["str"] = true;
                    saveThrows["con"] = true;
                    break;

                case "fighter":
                    saveThrows["str"] = true;
                    saveThrows["con"] = true;
                    break;

                case "wizard":
                    saveThrows["int"] = true;
                    saveThrows["wis"] = true;
                    break;

                case "druid":
                    saveThrows["int"] = true;
                    saveThrows["wis"] = true;
                    break;

                case "cleric":
                    saveThrows["wis"] = true;
                    saveThrows["cha"] = true;
                    break;

                case "warlock":
                    saveThrows["wis"] = true;
                    saveThrows["cha"] = true;
                    break;

                case "monk":
                    saveThrows["str"] = true;
                    saveThrows["dex"] = true;
                    break;

                case "paladin":
                    saveThrows["wis"] = true;
                    saveThrows["cha"] = true;
                    break;

                case "rogue":
                    saveThrows["dex"] = true;
                    saveThrows["int"] = true;
                    break;

                case "ranger":
                    saveThrows["str"] = true;
                    saveThrows["dex"] = true;
                    break;

                case "sorcerer":
                    saveThrows["con"] = true;
                    saveThrows["cha"] = true;
                    break;

                default:
                    Console.WriteLine("Нет подходящего класса для распределения спасбросков.");
                    break;
            }

            return saveThrows;
        }

        private void AbilitySet(CharacterSheetDnd5E heroSheet)
        {
            _isSet = false;

            while (_isSet == false)
            {
                for (int i = 0; i < 6; i++)
                {
                    switch (i)
                    {
                        case 0:
                        default:
                            Console.Write("Сила: ");
                            _abilities["str"] = Convert.ToInt32(Console.ReadLine());
                            break;
                        case 1:
                            Console.Write("Ловкость: ");
                            _abilities["dex"] = Convert.ToInt32(Console.ReadLine());
                            break;
                        case 2:
                            Console.Write("Телосложение: ");
                            _abilities["con"] = Convert.ToInt32(Console.ReadLine());
                            break;
                        case 3:
                            Console.Write("Интеллект: ");
                            _abilities["int"] = Convert.ToInt32(Console.ReadLine());
                            break;
                        case 4:
                            Console.Write("Мудрость: ");
                            _abilities["wis"] = Convert.ToInt32(Console.ReadLine());
                            break;
                        case 5:
                            Console.Write("Харизма: ");
                            _abilities["cha"] = Convert.ToInt32(Console.ReadLine());
                            break;
                    }
                }
                //heroSheet.Abilities = _abilities;
                _isSet = true;
            }
        }

        private CharacterSheetBase SetEdition()
        {
            _isSet = false;
            while(_isSet == false)
            {
                Console.WriteLine("Укажите редакцию, по которой нужно создать лист персонажа:");
                
                foreach (var item in Enum.GetValues(typeof(EnumEditions)))
                {
                    Console.Write((int)item + " - ");
                    Console.Write(item + "\n");
                }

                _input = Console.ReadLine();
                if (Enum.TryParse<EnumEditions>(_input, out EnumEditions result))
                {
                    switch(result)
                    {
                        case EnumEditions.Dnd5E:
                            return _sheetFactory.CreateCharacterSheet(Convert.ToString(result));
                        
                        default:
                            break;
                    }

                    _isSet = true;
                }
                
                return null;
            }

            return null;
        }

        private string? ChooseRace()
        {
            _isSet = false;
            while(_isSet == false)
            {
                Console.WriteLine("Выберите расу из списка:");
                foreach (var item in Enum.GetValues(typeof(EnumRacesDnd5E)))
                {
                    Console.Write((int)item + " - ");
                    Console.Write(item + "\n");
                }

                _input = Console.ReadLine();
                if (Enum.TryParse<EnumRacesDnd5E>(_input, out EnumRacesDnd5E result))
                {
                    return Convert.ToString(result);
                }

                return null;
            }

            return null;
        }

        private string? ChooseClass()
        {
            _isSet = false;
            while(_isSet == false)
            {
                Console.WriteLine("Выберите класс из списка:");
                foreach (var item in Enum.GetValues(typeof(EnumClassesDnd5E)))
                {
                    Console.Write((int)item + " - ");
                    Console.Write(item + "\n");
                }

                _input = Console.ReadLine();
                if (Enum.TryParse<EnumClassesDnd5E>(_input, out EnumClassesDnd5E result))
                {
                    return Convert.ToString(result);
                }

                return null;
            }

            return null;
        }
    }
}
