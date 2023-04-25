namespace dnd_character_sheet
{
    public static class LocalizationsStash
    {
        public static Dictionary<Enum, Dictionary<Enum, string>> StartScreenTitle = new Dictionary<Enum, Dictionary<Enum, string>>()
        {
            {
                EnumStartMenuTitles.ChooseLang, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, @"Выберите язык \ Choose language" }
                }
            }
        };

        public static Dictionary<Enum, Dictionary<Enum, string>> StartScreenPoints = new Dictionary<Enum, Dictionary<Enum, string>>()
        {
            {
                EnumLanguages.Russian, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, @"Русский \ Russian" }
                }
            }
        };
        
        public static Dictionary<Enum, Dictionary<Enum, string>> MainMenuTitles = new Dictionary<Enum, Dictionary<Enum, string>>()
        {
            {
                EnumMainMenuTitles.MainMenu, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Создание листа"}
                }
            },
            {
                EnumMainMenuTitles.SheetSaved, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Лист сохранён"}
                }
            }
        };

        public static Dictionary<Enum, Dictionary<Enum, string>> MainMenuPoints = new Dictionary<Enum, Dictionary<Enum, string>>()
        {
            {
                EnumMainMenuPoints.CreateSheet, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Создание листа"}
                }
            },
            {
                EnumMainMenuPoints.LoadSheet, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Загрузить лист" }
                }
            },
            {
                EnumMainMenuPoints.PrintSheet, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Вывести информацию о текущем листе персонажа" }
                }
            },
            {
                EnumMainMenuPoints.DiceRolls, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Свободные броски кубика" }
                }
            },
            {
                EnumMainMenuPoints.WorkWithSheet, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Работа с листом" }
                }
            },
            {
                EnumMainMenuPoints.SaveSheeet, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Сохранить текущий лист" }
                }
            },
            {
                EnumMainMenuPoints.Exit, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Выход" }
                }
            }
        };

        public static Dictionary<Enum, Dictionary<Enum, string>> ScreenSheetCreateTitles = new Dictionary<Enum, Dictionary<Enum, string>>()
        {
            {
                EnumSheetCreateTitles.EnterTheNameOfTheHero, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Введите имя героя: "}
                }
            },
            {
                EnumSheetCreateTitles.SelectARaceFromTheList, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Выберите расу из списка:"}
                }
            },
            {
                EnumSheetCreateTitles.SelectAClassFromTheList, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Выберите класс из списка:"}
                }
            },
            {
                EnumSheetCreateTitles.SelectASkillFromTheList, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Выберите навык из списка:"}
                }
            },
            {
                EnumSheetCreateTitles.EnterTheCharacteristicsOfTheHero, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Впишите характеристики героя:"}
                }
            },
            {
                EnumSheetCreateTitles.AddOwnershipOfTheArmorType, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Добавить владение типом брони?"}
                }
            },
            {
                EnumSheetCreateTitles.AddOwnershipOfAGroupOfWeapons, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Добавить владение группой оружия?"}
                }
            },
            {
                EnumSheetCreateTitles.AddOwnershipFfASpecificWeapon, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Добавить владение конкретным оружием?"}
                }
            },
            {
                EnumSheetCreateTitles.AddOwnershipFfTools, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Добавить владение инструментами?"}
                }
            },
            {
                EnumSheetCreateTitles.AddOwnershipOfMusicalInstruments, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Добавить владение музыкальными инструментами?"}
                }
            },
            {
                EnumSheetCreateTitles.AddOwnershipOfGameSets, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Добавить владение игровыми наборами?"}
                }
            },
            {
                EnumSheetCreateTitles.SpecifyTheCharactersOfTheHero, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Укажите персоналии героя:"}
                }
            },
            {
                EnumSheetCreateTitles.HeresYourNewHero, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Вот ваш новый герой!"}
                }
            },
            {
                EnumSheetCreateTitles.YouNeedToSpecifyAValueFrom1To20, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Нужно указать значение от 1 до 20"}
                }
            },
            {
                EnumSheetCreateTitles.AddMore, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Добавить ещё?"}
                }
            },
            {
                EnumSheetCreateTitles.WhatOwnershipToAdd, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Какое владение добавить?"}
                }
            }
        };

        public static Dictionary<Enum, Dictionary<Enum, string>> DND5eRaces = new Dictionary<Enum, Dictionary<Enum, string>>()
        {
            {
                EnumRacesDnd5E.Gnome, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Гном"}
                }
            },
            {
                EnumRacesDnd5E.Dwarf, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Дварф"}
                }
            },
            {
                EnumRacesDnd5E.Dragonborn, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Драконорожденный"}
                }
            },
            {
                EnumRacesDnd5E.Halforc, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Полуорк"}
                }
            },
            {
                EnumRacesDnd5E.Halfling, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Полурослик"}
                }
            },
            {
                EnumRacesDnd5E.Halfelf, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Полуэльф"}
                }
            },
            {
                EnumRacesDnd5E.Tiefling, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Тифлинг"}
                }
            },
            {
                EnumRacesDnd5E.Human, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Человек"}
                }
            },
            {
                EnumRacesDnd5E.Elf, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Эльф"}
                }
            }
        };

        public static Dictionary<Enum, Dictionary<Enum, string>> DND5eClasses = new Dictionary<Enum, Dictionary<Enum, string>>()
        {
            {
                EnumClassesDnd5E.Bard, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Бард"}
                }
            },
            {
                EnumClassesDnd5E.Barbarian, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Варвар"}
                }
            },
            {
                EnumClassesDnd5E.Fighter, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Воин"}
                }
            },
            {
                EnumClassesDnd5E.Wizard, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Волщебник"}
                }
            },
            {
                EnumClassesDnd5E.Druid, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Друид"}
                }
            },
            {
                EnumClassesDnd5E.Cleric, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Жрец"}
                }
            },
            {
                EnumClassesDnd5E.Warlock, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Чародей"}
                }
            },
            {
                EnumClassesDnd5E.Sorcerer, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Колдун"}
                }
            },
            {
                EnumClassesDnd5E.Monk, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Монах"}
                }
            },
            {
                EnumClassesDnd5E.Paladin, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Паладин"}
                }
            },
            {
                EnumClassesDnd5E.Rogue, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Плут"}
                }
            },
            {
                EnumClassesDnd5E.Ranger, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Следопыт"}
                }
            }
        };

        public static Dictionary<Enum, Dictionary<Enum, string>> DND5eSkills = new Dictionary<Enum, Dictionary<Enum, string>>()
        {
            {
                EnumSkillsDnd5E.Acrobatics, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Акробатика"}
                }
            },
            {
                EnumSkillsDnd5E.Investigation, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Анализ"}
                }
            },
            {
                EnumSkillsDnd5E.Athletics, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Атлетика"}
                }
            },
            {
                EnumSkillsDnd5E.Perception, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Внимательсность"}
                }
            },
            {
                EnumSkillsDnd5E.Surival, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Выживание"}
                }
            },
            {
                EnumSkillsDnd5E.Perfomance, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Выступление"}
                }
            },
            {
                EnumSkillsDnd5E.Intimidation, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Запугивание"}
                }
            },
            {
                EnumSkillsDnd5E.History, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "История"}
                }
            },
            {
                EnumSkillsDnd5E.Sleight, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Ловкость рук"}
                }
            },
            {
                EnumSkillsDnd5E.Arcana, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Магия"}
                }
            },
            {
                EnumSkillsDnd5E.Medicine, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Медицина"}
                }
            },
            {
                EnumSkillsDnd5E.Deception, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Обман"}
                }
            },
            {
                EnumSkillsDnd5E.Nature, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Природа"}
                }
            },
            {
                EnumSkillsDnd5E.Insight, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Проницательность"}
                }
            },
            {
                EnumSkillsDnd5E.Religion, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Религия"}
                }
            },
            {
                EnumSkillsDnd5E.Stealth, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Скрытность"}
                }
            },
            {
                EnumSkillsDnd5E.Persuasion, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Убеждение"}
                }
            },
            {
                EnumSkillsDnd5E.Animal, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Уход за животными"}
                }
            }
        };

        public static Dictionary<Enum, Dictionary<Enum, string>> YesNo = new Dictionary<Enum, Dictionary<Enum, string>>()
        {
            {
                EnumYesNo.Yes, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Да"}
                }
            },
            {
                EnumYesNo.No, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Нет"}
                }
            }
        };

        public static Dictionary<Enum, Dictionary<Enum, string>> DND5EGroupsOfWeapons = new Dictionary<Enum, Dictionary<Enum, string>>()
        {
            {
                EnumWeaponsGroupsDND5E.SimpleMelee, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Простое рукопашное оружие"}
                }
            },
            {
                EnumWeaponsGroupsDND5E.SimpleRanged, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Простое дальнобойное оружие"}
                }
            },
            {
                EnumWeaponsGroupsDND5E.MartialMelee, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Воинское рукопашное оружие"}
                }
            },
            {
                EnumWeaponsGroupsDND5E.MartialRanged, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Воинское дальнобойное оружие"}
                }
            }
        };

        public static Dictionary<Enum, Dictionary<Enum, string>> DND5eWeapons = new Dictionary<Enum, Dictionary<Enum, string>>()
        {
            {
                EnumWeaponsProficienciesDND5E.Quarterstaff, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Боевой посох"}
                }
            },
            {
                EnumWeaponsProficienciesDND5E.Dart, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Дротик"}
                }
            },
            {
                EnumWeaponsProficienciesDND5E.Shortbow, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Короткий лук"}
                }
            },
            {
                EnumWeaponsProficienciesDND5E.Sling, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Праща"}
                }
            },
            {
                EnumWeaponsProficienciesDND5E.Halberd, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Алебарда"}
                }
            },
            {
                EnumWeaponsProficienciesDND5E.WarPick, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Боевая кирка"}
                }
            },
            {
                EnumWeaponsProficienciesDND5E.Mace, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Булава"}
                }
            },
            {
                EnumWeaponsProficienciesDND5E.Club, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Дубинка"}
                }
            },
            {
                EnumWeaponsProficienciesDND5E.Dagger, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Кинжал"}
                }
            },
            {
                EnumWeaponsProficienciesDND5E.Spear, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Копьё"}
                }
            },
            {
                EnumWeaponsProficienciesDND5E.LightHammer, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Лёгкий молот"}
                }
            },
            {
                EnumWeaponsProficienciesDND5E.Javelin, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Метательное копьё"}
                }
            },
            {
                EnumWeaponsProficienciesDND5E.Greatclub, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Палица"}
                }
            },
            {
                EnumWeaponsProficienciesDND5E.Handaxe, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Ручной топор"}
                }
            },
            {
                EnumWeaponsProficienciesDND5E.Sickle, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Серп"}
                }
            },
            {
                EnumWeaponsProficienciesDND5E.Crossbow, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Арбалет, лёгкий"}
                }
            },
            {
                EnumWeaponsProficienciesDND5E.Warhammer, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Боевой молот"}
                }
            },
            {
                EnumWeaponsProficienciesDND5E.Battleaxe, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Боевой топор"}
                }
            },
            {
                EnumWeaponsProficienciesDND5E.Glaive, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Глефа"}
                }
            },
            {
                EnumWeaponsProficienciesDND5E.Greatsword, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Двуручный меч"}
                }
            },
            {
                EnumWeaponsProficienciesDND5E.Lance, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Длинное копьё"}
                }
            },
            {
                EnumWeaponsProficienciesDND5E.Longsword, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Длинный меч"}
                }
            },
            {
                EnumWeaponsProficienciesDND5E.Whip, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Кнут"}
                }
            },
            {
                EnumWeaponsProficienciesDND5E.Shortsword, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Короткий меч"}
                }
            },
            {
                EnumWeaponsProficienciesDND5E.Maul, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Молот"}
                }
            },
            {
                EnumWeaponsProficienciesDND5E.Morningstar, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Моргенштерн"}
                }
            },
            {
                EnumWeaponsProficienciesDND5E.Pike, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Пика"}
                }
            },
            {
                EnumWeaponsProficienciesDND5E.Rapier, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Рапира"}
                }
            },
            {
                EnumWeaponsProficienciesDND5E.Greataxe, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Секира"}
                }
            },
            {
                EnumWeaponsProficienciesDND5E.Scimitar, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Скимитар"}
                }
            },
            {
                EnumWeaponsProficienciesDND5E.Trident, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Трезубец"}
                }
            },
            {
                EnumWeaponsProficienciesDND5E.Flail, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Цеп"}
                }
            },
            {
                EnumWeaponsProficienciesDND5E.CrossbowHand, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Арбалет, ручной"}
                }
            },
            {
                EnumWeaponsProficienciesDND5E.CrossbowHeavy, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Арбалет, тяжёлый"}
                }
            },
            {
                EnumWeaponsProficienciesDND5E.Longbow, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Длинный лук"}
                }
            },
            {
                EnumWeaponsProficienciesDND5E.Blowgun, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Духовая трубка"}
                }
            },
            {
                EnumWeaponsProficienciesDND5E.Net, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Сеть"}
                }
            }
        };

        public static Dictionary<Enum, Dictionary<Enum, string>> DND5eArmor = new Dictionary<Enum, Dictionary<Enum, string>>()
        {
            {
                EnumArmorProficienciesDND5E.LightArmor, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Лёгкий доспех"}
                }
            },
            {
                EnumArmorProficienciesDND5E.MediumArmor, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Средний доспех"}
                }
            },
            {
                EnumArmorProficienciesDND5E.HeavyArmor, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Тяжёлый доспех"}
                }
            },
            {
                EnumArmorProficienciesDND5E.Shield, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Щит"}
                }
            }
        };

        public static Dictionary<Enum, Dictionary<Enum, string>> DND5eProfInstruments = new Dictionary<Enum, Dictionary<Enum, string>>()
        {
            {
                EnumInstrumentsProficienciesDND5E.ThievesTools, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Воровские инструменты"}
                }
            },
            {
                EnumInstrumentsProficienciesDND5E.NavigatorsTools, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Инструменты навигатора"}
                }
            },
            {
                EnumInstrumentsProficienciesDND5E.PoisonersKit, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Инструменты отравителя"}
                }
            },
            {
                EnumInstrumentsProficienciesDND5E.AlchemistsSupplies, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Инструменты алхимика"}
                }
            },
            {
                EnumInstrumentsProficienciesDND5E.PottersTools, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Инструменты гончара"}
                }
            },
            {
                EnumInstrumentsProficienciesDND5E.TinkersTools, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Инструменты жестянщика"}
                }
            },
            {
                EnumInstrumentsProficienciesDND5E.CalligraphersSupplies, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Инструменты каллиграфа"}
                }
            },
            {
                EnumInstrumentsProficienciesDND5E.MasonsTools, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Инструменты каменщика"}
                }
            },
            {
                EnumInstrumentsProficienciesDND5E.CartographersTools, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Инструменты картографа"}
                }
            },
            {
                EnumInstrumentsProficienciesDND5E.LeatherworkersTools, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Инструменты кожевника"}
                }
            },
            {
                EnumInstrumentsProficienciesDND5E.SmithsTools, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Инструменты кузнеца"}
                }
            },
            {
                EnumInstrumentsProficienciesDND5E.BrewersSupplies, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Инструменты пивовара"}
                }
            },
            {
                EnumInstrumentsProficienciesDND5E.CarpentersTools, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Инструменты плотника"}
                }
            },
            {
                EnumInstrumentsProficienciesDND5E.CooksUtensils, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Инструменты повара"}
                }
            },
            {
                EnumInstrumentsProficienciesDND5E.WoodcarversTools, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Инструменты резчика по дереву"}
                }
            },
            {
                EnumInstrumentsProficienciesDND5E.CobblersTools, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Инструменты сапожника"}
                }
            },
            {
                EnumInstrumentsProficienciesDND5E.GlassblowersTools, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Инструменты стеклодува"}
                }
            },
            {
                EnumInstrumentsProficienciesDND5E.WeaversTools, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Инструменты ткача"}
                }
            },
            {
                EnumInstrumentsProficienciesDND5E.PaintersSupplies, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Инструменты художника"}
                }
            },
            {
                EnumInstrumentsProficienciesDND5E.JewelersTools, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Инструменты ювелира"}
                }
            },
            {
                EnumInstrumentsProficienciesDND5E.DisguiseKit, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Набор для грима"}
                }
            },
            {
                EnumInstrumentsProficienciesDND5E.ForgeryKit, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Набор для фальсификации"}
                }
            },
            {
                EnumInstrumentsProficienciesDND5E.Herbalism, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Набор травника"}
                }
            }
        };

        public static Dictionary<Enum, Dictionary<Enum, string>> DND5eMusicalInstruments = new Dictionary<Enum, Dictionary<Enum, string>>()
        {
            {
                EnumMusicalInstrumentProficienciesDND5E.Drum, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Барабан"}
                }
            },
            {
                EnumMusicalInstrumentProficienciesDND5E.Viol, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Виола"}
                }
            },
            {
                EnumMusicalInstrumentProficienciesDND5E.Bagpipes, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Волынка"}
                }
            },
            {
                EnumMusicalInstrumentProficienciesDND5E.Lyre, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Лира"}
                }
            },
            {
                EnumMusicalInstrumentProficienciesDND5E.Lute, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Лютня"}
                }
            },
            {
                EnumMusicalInstrumentProficienciesDND5E.Horn, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Рожок"}
                }
            },
            {
                EnumMusicalInstrumentProficienciesDND5E.PanFlute, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Свирель"}
                }
            },
            {
                EnumMusicalInstrumentProficienciesDND5E.Flute, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Флейта"}
                }
            },
            {
                EnumMusicalInstrumentProficienciesDND5E.Dulcimer, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Цимбалы"}
                }
            },
            {
                EnumMusicalInstrumentProficienciesDND5E.Shawm, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Шалмей"}
                }
            }
        };

        public static Dictionary<Enum, Dictionary<Enum, string>> DND5eProfGamingSets = new Dictionary<Enum, Dictionary<Enum, string>>()
        {
            {
                EnumGamingSetProficienciesDND5E.DiceSet, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Кости"}
                }
            },
            {
                EnumGamingSetProficienciesDND5E.DragonchessSet, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Драконьи шахматы"}
                }
            },
            {
                EnumGamingSetProficienciesDND5E.PlayingCardSet, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Карты"}
                }
            },
            {
                EnumGamingSetProficienciesDND5E.ThreeDragonAnteSet, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Ставка трех драконов"}
                }
            }
        };

        public static Dictionary<Enum, Dictionary<Enum, string>> DND5eAbilities = new Dictionary<Enum, Dictionary<Enum, string>>()
        {
            {
                EnumAbilitiesDnd5E.Strength, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Сила" }
                }
            },
            {
                EnumAbilitiesDnd5E.Dexterity, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Ловкость" }
                }
            },
            {
                EnumAbilitiesDnd5E.Constitution, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Телосложение" }
                }
            },
            {
                EnumAbilitiesDnd5E.Intelligence, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Интеллект" }
                }
            },
            {
                EnumAbilitiesDnd5E.Wisdom, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Мудрость" }
                }
            },
            {
                EnumAbilitiesDnd5E.Charisma, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Харизма" }
                }
            }
        };

        public static Dictionary<Enum, Dictionary<Enum, string>> DND5ePersonalities = new Dictionary<Enum, Dictionary<Enum, string>>()
        {
            {
                EnumPersonalitiesDND5E.Background, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Предыстория" }
                }
            },
            {
                EnumPersonalitiesDND5E.Alignment, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Мировоззрение" }
                }
            },
            {
                EnumPersonalitiesDND5E.PersonalityTraits, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Черты характера" }
                }
            },
            {
                EnumPersonalitiesDND5E.Ideals, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Идеалы" }
                }
            },
            {
                EnumPersonalitiesDND5E.Bonds, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Привязанности" }
                }
            },
            {
                EnumPersonalitiesDND5E.Flaws, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Слабости" }
                }
            },
            {
                EnumPersonalitiesDND5E.Age, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Возраст" }
                }
            },
            {
                EnumPersonalitiesDND5E.Height, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Рост" }
                }
            },
            {
                EnumPersonalitiesDND5E.Weight, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Вес" }
                }
            },
            {
                EnumPersonalitiesDND5E.Skin, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Кожа" }
                }
            },
            {
                EnumPersonalitiesDND5E.Eyes, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Глаза" }
                }
            },
            {
                EnumPersonalitiesDND5E.Hair, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Причёска" }
                }
            }
        }; 

        public static Dictionary<Enum, Dictionary<Enum, string>> IncorrectInputTitle = new Dictionary<Enum, Dictionary<Enum, string>>()
        {
            {
                EnumIncorrectInput.IncorrectInput, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Некорректный ввод" }
                }
            }
        };        
    }
}