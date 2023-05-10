namespace dnd_character_sheet
{
    public class LocalizationsStash
    {
        private Dictionary<Enum, Dictionary<Enum, string>> Localizations = new Dictionary<Enum, Dictionary<Enum, string>>()
        {
            {
                EnumStartMenuTitles.ChooseLang, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, @"Выберите язык \ Choose language" }
                }
            },
            {
                EnumLanguages.Russian, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, @"Русский \ Russian" }
                }
            },
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
            },
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
            },
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
            },
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
            },
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
            },
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
            },
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
            },
            {
                EnumWeaponsGroupsDND5E.SimpleMelee, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Простое рукопашное оружие" }
                }
            },
            {
                EnumWeaponsGroupsDND5E.SimpleRanged, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Простое дальнобойное оружие" }
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
            },
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
            },
            {
                EnumArmorProficienciesDND5E.LightArmor, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Лёгкий доспех"}
                }
            },
            {
                EnumAllDND5eProficiencies.LightArmor, new Dictionary<Enum, string>()
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
            },
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
            },
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
            },
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
            },
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
            },
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
            },
            {
                EnumIncorrectInput.IncorrectInput, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Некорректный ввод" }
                }
            },
            {
                EnumMenuNavigate.Page, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Страница" }
                }
            },
            {
                EnumMainMenuTitles.FirstLoadOrCreateSheet, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Сначала нужно создать или загрузить лист персонажа." }
                }
            },
            {
                EnumAllDND5eProficiencies.MediumArmor, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Средний доспех" }
                }
            },
            {
                EnumAllDND5eProficiencies.HeavyArmor, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Тяжёлый доспех" }
                }
            },
            {
                EnumAllDND5eProficiencies.Shield, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Щит" }
                }
            },
            {
                EnumAllDND5eProficiencies.DiceSet, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Кости" }
                }
            },
            {
                EnumAllDND5eProficiencies.DragonchessSet, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Драконьи шахматы" }
                }
            },
            {
                EnumAllDND5eProficiencies.PlayingCardSet, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Карты" }
                }
            },
            {
                EnumAllDND5eProficiencies.ThreeDragonAnteSet, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Ставка трех драконов" }
                }
            },
            {
                EnumAllDND5eProficiencies.AlchemistsSupplies, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Инструменты алхимика" }
                }
            },
            {
                EnumAllDND5eProficiencies.BrewersSupplies, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Инструменты пивовара" }
                }
            },
            {
                EnumAllDND5eProficiencies.CalligraphersSupplies, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Инструменты каллиграфа" }
                }
            },
            {
                EnumAllDND5eProficiencies.CarpentersTools, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Инструменты плотника" }
                }
            },
            {
                EnumAllDND5eProficiencies.CartographersTools, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Инструменты картографа" }
                }
            },
            {
                EnumAllDND5eProficiencies.CobblersTools, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Инструменты сапожника" }
                }
            },
            {
                EnumAllDND5eProficiencies.CooksUtensils, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Инструменты повара" }
                }
            },
            {
                EnumAllDND5eProficiencies.GlassblowersTools, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Инструменты стеклодува" }
                }
            },
            {
                EnumAllDND5eProficiencies.JewelersTools, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Инструменты ювелира" }
                }
            },
            {
                EnumAllDND5eProficiencies.LeatherworkersTools, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Инструменты кожевника" }
                }
            },
            {
                EnumAllDND5eProficiencies.MasonsTools, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Инструменты каменщика" }
                }
            },
            {
                EnumAllDND5eProficiencies.PaintersSupplies, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Инструменты художника" }
                }
            },
            {
                EnumAllDND5eProficiencies.PottersTools, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Инструменты гончара" }
                }
            },
            {
                EnumAllDND5eProficiencies.SmithsTools, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Инструменты кузнеца" }
                }
            },
            {
                EnumAllDND5eProficiencies.TinkersTools, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Инструменты жестянщика" }
                }
            },
            {
                EnumAllDND5eProficiencies.WeaversTools, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Инструменты ткача" }
                }
            },
            {
                EnumAllDND5eProficiencies.WoodcarversTools, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Инструменты резчика по дереву" }
                }
            },
            {
                EnumAllDND5eProficiencies.NavigatorsTools, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Инструменты навигатора" }
                }
            },
            {
                EnumAllDND5eProficiencies.PoisonersKit, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Инструменты отравителя" }
                }
            },
            {
                EnumAllDND5eProficiencies.ThievesTools, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Воровские инструменты" }
                }
            },
            {
                EnumAllDND5eProficiencies.DisguiseKit, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Набор для грима" }
                }
            },
            {
                EnumAllDND5eProficiencies.ForgeryKit, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Набор для фальсификации" }
                }
            },
            {
                EnumAllDND5eProficiencies.Herbalism, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Набор травника" }
                }
            },
            {
                EnumAllDND5eProficiencies.Bagpipes, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Волынка" }
                }
            },
            {
                EnumAllDND5eProficiencies.Drum, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Барабан" }
                }
            },
            {
                EnumAllDND5eProficiencies.Dulcimer, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Цимбалы" }
                }
            },
            {
                EnumAllDND5eProficiencies.Flute, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Флейта" }
                }
            },
            {
                EnumAllDND5eProficiencies.Lute, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Лютня" }
                }
            },
            {
                EnumAllDND5eProficiencies.Lyre, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Лира" }
                }
            },
            {
                EnumAllDND5eProficiencies.Horn, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Рожок" }
                }
            },
            {
                EnumAllDND5eProficiencies.PanFlute, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Свирель" }
                }
            },
            {
                EnumAllDND5eProficiencies.Shawm, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Шалмей" }
                }
            },
            {
                EnumAllDND5eProficiencies.Viol, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Виола" }
                }
            },
            {
                EnumAllDND5eProficiencies.SimpleMelee, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Простое рукопашное оружие" }
                }
            },
            {
                EnumAllDND5eProficiencies.SimpleRanged, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Простое дальнобойное оружие" }
                }
            },
            {
                EnumAllDND5eProficiencies.MartialMelee, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Воинское рукопашное оружие" }
                }
            },
            {
                EnumAllDND5eProficiencies.MartialRanged, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Воинское дальнобойное оружие" }
                }
            },
            {
                EnumAllDND5eProficiencies.Club, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Дубинка" }
                }
            },
            {
                EnumAllDND5eProficiencies.Dagger, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Кинжал" }
                }
            },
            {
                EnumAllDND5eProficiencies.Greatclub, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Палица" }
                }
            },
            {
                EnumAllDND5eProficiencies.Handaxe, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Ручной топор" }
                }
            },
            {
                EnumAllDND5eProficiencies.Javelin, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Метательное копьё" }
                }
            },
            {
                EnumAllDND5eProficiencies.LightHammer, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Лёгкий молот" }
                }
            },
            {
                EnumAllDND5eProficiencies.Mace, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Булава" }
                }
            },
            {
                EnumAllDND5eProficiencies.Quarterstaff, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Боевой посох" }
                }
            },
            {
                EnumAllDND5eProficiencies.Sickle, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Серп" }
                }
            },
            {
                EnumAllDND5eProficiencies.Spear, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Копьё" }
                }
            },
            {
                EnumAllDND5eProficiencies.Crossbow, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Арбалет, лёгкий" }
                }
            },
            {
                EnumAllDND5eProficiencies.Dart, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Дротик" }
                }
            },
            {
                EnumAllDND5eProficiencies.Shortbow, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Короткий лук" }
                }
            },
            {
                EnumAllDND5eProficiencies.Sling, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Праща" }
                }
            },
            {
                EnumAllDND5eProficiencies.Battleaxe, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Боевой топор" }
                }
            },
            {
                EnumAllDND5eProficiencies.Flail, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Цеп" }
                }
            },
            {
                EnumAllDND5eProficiencies.Glaive, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Глефа" }
                }
            },
            {
                EnumAllDND5eProficiencies.Greataxe, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Секира" }
                }
            },
            {
                EnumAllDND5eProficiencies.Greatsword, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Двуручный меч" }
                }
            },
            {
                EnumAllDND5eProficiencies.Halberd, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Алебарда" }
                }
            },
            {
                EnumAllDND5eProficiencies.Lance, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Длинное копьё" }
                }
            },
            {
                EnumAllDND5eProficiencies.Longsword, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Длинный меч" }
                }
            },
            {
                EnumAllDND5eProficiencies.Maul, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Молот" }
                }
            },
            {
                EnumAllDND5eProficiencies.Morningstar, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Моргенштерн" }
                }
            },
            {
                EnumAllDND5eProficiencies.Pike, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Пика" }
                }
            },
            {
                EnumAllDND5eProficiencies.Rapier, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Рапира" }
                }
            },
            {
                EnumAllDND5eProficiencies.Scimitar, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Скимитар" }
                }
            },
            {
                EnumAllDND5eProficiencies.Shortsword, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Короткий меч" }
                }
            },
            {
                EnumAllDND5eProficiencies.Trident, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Трезубец" }
                }
            },
            {
                EnumAllDND5eProficiencies.WarPick, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Боевая кирка" }
                }
            },
            {
                EnumAllDND5eProficiencies.Warhammer, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Боевой молот" }
                }
            },
            {
                EnumAllDND5eProficiencies.Whip, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Кнут" }
                }
            },
            {
                EnumAllDND5eProficiencies.Blowgun, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Духовая трубка" }
                }
            },
            {
                EnumAllDND5eProficiencies.CrossbowHand, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Арбалет, ручной" }
                }
            },
            {
                EnumAllDND5eProficiencies.CrossbowHeavy, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Арбалет, тяжёлый" }
                }
            },
            {
                EnumAllDND5eProficiencies.Longbow, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Длинный лук" }
                }
            },
            {
                EnumAllDND5eProficiencies.Net, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Сеть" }
                }
            },
            {
                EnumLoadSheetTitles.ChooseSheet, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Выберите лист, который нужно загрузить:" }
                }
            },
            {
                EnumLoadSheetTitles.HeroLoaded, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Герой загружен" }
                }
            },
            {
                EnumSheetCreateTitles.IsNeedToAddTraits, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Нужно ли добавить умения?" }
                }
            },
            {
                EnumSheetCreateTitles.WriteTraitName, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Укажите имя умения" }
                }
            },
            {
                EnumSheetCreateTitles.WriteTraitSource, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Укажите источник умения" }
                }
            },
            {
                EnumSheetCreateTitles.WriteTraitDescription, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Укажите описание умения" }
                }
            },
            {
                EnumManageItemBaseTitles.WhatNeedToDoWithBase, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Что нужно сделать с базой предметов?" }
                }
            },
            {
                EnumManageItemBasePoints.AddNewItem, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Добавить новый предмет" }
                }
            },
            {
                EnumManageItemBasePoints.ChangeItemInBase, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Изменить существующий предмет" }
                }
            },
            {
                EnumManageItemBasePoints.Escape, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Назад" }
                }
            },
            {
                EnumManageItemBasePoints.RemoveItemFromBase, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Удалить предмет из базы" }
                }
            },
            {
                EnumManageItemBasePoints.ShowItemsBase, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Показать все предметы из базы" }
                }
            },
            {
                EnumMainMenuPoints.WorkWithItemsBase, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Работа с базой предметов" }
                }
            },
            {
                EnumManageItemBaseTitles.CurrentlyItemsInBase, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Текущие предметы в базе:" }
                }
            },
            {
                EnumAddItemInDBTitles.WhatTypeOfItemShouldAdd, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Какой тип предмета:" }
                }
            },
            {
                EnumAddItemInDBTitles.NameOfTheItem, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Название предмета:" }
                }
            },
            {
                EnumAddItemInDBTitles.TheCostOfItemInGold, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Стоимость предмета в золотых:" }
                }
            },
            {
                EnumAddItemInDBTitles.ItemWeightPounds, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Вес предмета (фунты):" }
                }
            },
            {
                EnumAddItemInDBTitles.Rare, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Редкость:" }
                }
            },
            {
                EnumAddItemInDBTitles.Description, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Описание:" }
                }
            },
            {
                EnumAddItemInDBTitles.Magical, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Магическое:" }
                }
            },
            {
                EnumAddItemInDBTitles.WhichGroupThisWeapon, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "К какой группе относится это оружие:" }
                }
            },
            {
                EnumAddItemInDBTitles.WhichBasicWeaponCanAttributedTo, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "К какому базовому оружию его можно отнести:" }
                }
            },
            {
                EnumAddItemInDBTitles.HowManyDamageDices, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Сколько костей урона:" }
                }
            },
            {
                EnumAddItemInDBTitles.WhatDamageDice, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Какая кость урона:" }
                }
            },
            {
                EnumAddItemInDBTitles.WhatDamageType, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Какой тип урона:" }
                }
            },
            {
                EnumAddItemInDBTitles.WhatModificator, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Какой модификатор:" }
                }
            },
            {
                EnumAddItemInDBTitles.WhatWeaponProperties, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Какие у оружия есть свойства:" }
                }
            },
            {
                EnumAddItemInDBTitles.WhatCoinType, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Какой тип монеты:" }
                }
            },
            {
                EnumItemTypesDND5e.Armor, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Броня" }
                }
            },
            {
                EnumItemTypesDND5e.Coin, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Монета" }
                }
            },
            {
                EnumItemTypesDND5e.Weapon, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Оружие" }
                }
            },
            {
                EnumItemTypesDND5e.Item, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Другое" }
                }
            },
            {
                EnumItemRarityTypes.Usual, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Обычный" }
                }
            },
            {
                EnumItemRarityTypes.Unusual, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Необычный" }
                }
            },
            {
                EnumItemRarityTypes.Rare, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Редкий" }
                }
            },
            {
                EnumItemRarityTypes.VeryRare, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Очень редкий" }
                }
            },
            {
                EnumItemRarityTypes.Legendary, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Легендарный" }
                }
            },
            {
                EnumItemRarityTypes.Artifact, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Артефакт" }
                }
            },
            {
                EnumItemDamageTypesDND5e.Bludgeoning, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Дробящий" }
                }
            },
            {
                EnumItemDamageTypesDND5e.Piercing, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Колющий" }
                }
            },
            {
                EnumItemDamageTypesDND5e.Slashing, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Рубящий" }
                }
            },
            {
                EnumWeaponPropertiesDND5e.Ammunition, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Боеприпас" }
                }
            },
            {
                EnumWeaponPropertiesDND5e.NoPropery, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Без свойства" }
                }
            },
            {
                EnumWeaponPropertiesDND5e.Finesse, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Фехтовальное" }
                }
            },
            {
                EnumWeaponPropertiesDND5e.Heavy, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Тяжёлое" }
                }
            },
            {
                EnumWeaponPropertiesDND5e.Light, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Лёгкое" }
                }
            },
            {
                EnumWeaponPropertiesDND5e.Loading, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Перезарядка" }
                }
            },
            {
                EnumWeaponPropertiesDND5e.Range, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Дистанция" }
                }
            },
            {
                EnumWeaponPropertiesDND5e.Reach, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Досягаемое" }
                }
            },
            {
                EnumWeaponPropertiesDND5e.Special, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Специальное" }
                }
            },
            {
                EnumWeaponPropertiesDND5e.Thrown, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Метательное" }
                }
            },
            {
                EnumWeaponPropertiesDND5e.TwoHanded, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Двуручное" }
                }
            },
            {
                EnumWeaponPropertiesDND5e.Versatile, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Универсальное" }
                }
            },
            {
                EnumItemStatsDND5e.Name, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Название" }
                }
            },
            {
                EnumItemStatsDND5e.BaseCost, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Стоимость" }
                }
            },
            {
                EnumItemStatsDND5e.Weight, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Вес" }
                }
            },
            {
                EnumItemStatsDND5e.Rarity, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Редкость" }
                }
            },
            {
                EnumItemStatsDND5e.Description, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Описание" }
                }
            },
            {
                EnumItemStatsDND5e.IsMagic, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Магическое" }
                }
            },
            {
                EnumItemStatsDND5e.ItemId, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "ID предмета" }
                }
            },
            {
                EnumItemStatsDND5e.ItemType, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Тип предмета" }
                }
            },
            {
                EnumItemStatsDND5e.DamageDiceCount, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Количество костей урона" }
                }
            },
            {
                EnumItemStatsDND5e.DamageDiceValue, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Кость урона" }
                }
            },
            {
                EnumItemStatsDND5e.DamageModificator, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Модификатор" }
                }
            },
            {
                EnumItemStatsDND5e.DamageType, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Тип урона" }
                }
            },
            {
                EnumItemStatsDND5e.StrengthRequirement, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Требование силы" }
                }
            },
            {
                EnumItemStatsDND5e.ArmorClass, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Класс доспеха" }
                }
            },
            {
                EnumItemStatsDND5e.MaxAgilityBonus, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Максимальный бонус ловкости" }
                }
            },
            {
                EnumItemStatsDND5e.WeaponProperty, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Свойства оружия" }
                }
            },
            {
                EnumItemStatsDND5e.ArmorType, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Тип брони" }
                }
            },
            {
                EnumItemStatsDND5e.WeaponProficiencyConcrete, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Навык оружия" }
                }
            },
            {
                EnumItemStatsDND5e.WeaponProficiencyGroup, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Группа оружия" }
                }
            },
            {
                EnumAddItemInDBTitles.WhatArmorType, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Какой тип брони:" }
                }
            },
            {
                EnumAddItemInDBTitles.WhatStrenghtRequirement, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Какое требование по силе:" }
                }
            },
            {
                EnumAddItemInDBTitles.WhatArmorClass, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Какой у брони КД:" }
                }
            },
            {
                EnumAddItemInDBTitles.WhatArmorMaxDexteritiBonus, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Какой максимальный бонус ловкости:" }
                }
            },
            {
                EnumAddItemInDBTitles.IsNeedWeaponProperty, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Нужно ли добавить свойство оружия?" }
                }
            },
            {
                EnumShowItemsInDBTitles.ListOfItems, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Список предметов из базы:" }
                }
            },
            {
                EnumWorkWithSheetTitles.Menu, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Меню:" }
                }
            },
            {
                EnumWorkWithSheetPoints.Back, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Назад" }
                }
            },
            {
                EnumWorkWithSheetPoints.EditSheetFields, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Редактирование полей листа" }
                }
            },
            {
                EnumWorkWithSheetPoints.InventorySheetManage, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Взаимодействие с инвентарём" }
                }
            },
            {
                EnumWorkWithSheetPoints.SheetDiceRolls, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Броски кубов по листу" }
                }
            },
            {
                EnumWorkWithSheetPoints.SpellsSheetManage, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Подготовка заклинаний" }
                }
            },
            {
                EnumWorkWithInventoryTitles.Inventory, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Инвентарь" }
                }
            },
            {
                EnumWorkWithInventoryTitles.ItemInfo, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Информация о предмете" }
                }
            },
            {
                EnumWorkWithInventoryTitles.Weight, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Вес" }
                }
            },
            {
                EnumCoinsTypeDND5e.Copper, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Медная" }
                }
            },
            {
                EnumCoinsTypeDND5e.Electrum, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Электрумовая" }
                }
            },
            {
                EnumCoinsTypeDND5e.Gold, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Золотая" }
                }
            },
            {
                EnumCoinsTypeDND5e.Platinum, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Платиновая" }
                }
            },
            {
                EnumCoinsTypeDND5e.Silver, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Серебряная" }
                }
            },
            {
                EnumWorkWithInventoryTitles.NButtonCreateNewItem , new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "N - создать новый предмет" }
                }
            },
            {
                EnumWorkWithInventoryTitles.AButtonAddItemFromDB, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "A - добавить предмет из базы" }
                }
            },
            {
                EnumWorkWithInventoryTitles.DButtonRemoveItem, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "D - удалить выделенный предмет из инвентаря" }
                }
            },
            {
                EnumWorkWithInventoryTitles.PlusButtonIncreaseItemAmount, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "+ - увеличить количество выделенного предмета" }
                }
            },
            {
                EnumWorkWithInventoryTitles.MinusButtonDecreaseItemAmount, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "- - уменьшить количество выделенного предмета" }
                }
            },
            {
                EnumWorkWithInventoryTitles.ControlButtons, new Dictionary<Enum, string>()
                {
                    { EnumLanguages.Russian, "Горячие клавиши" }
                }
            }
        };    
    
        public static Dictionary<Enum, string> SelectedLocalization = new Dictionary<Enum, string>()
        {
            {
                EnumStartMenuTitles.ChooseLang, @"Выберите язык \ Choose language"
            },
            {
                EnumLanguages.Russian, @"Русский \ Russian" 
            },
            {
                EnumMenuNavigate.Page, @"Страница \ Page"
            }
        };
        
        public void SetUpLanguage(Enum language)
        {
            SelectedLocalization = new Dictionary<Enum, string>();
            
            foreach (var item in Localizations)
            {
                SelectedLocalization[item.Key] = item.Value[language];
            }
        }
    }
}