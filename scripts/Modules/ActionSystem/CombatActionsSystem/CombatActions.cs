namespace dnd_character_sheet
{
    public class CombatActions : ICombatActions
    {
        private ConsoleKeyInfo _pressedKey;

        public CombatActions()
        {

        }
        
        public string ChooseAction()
        {
            _pressedKey = Console.ReadKey();
            switch (_pressedKey.Key)
            {
                case ConsoleKey.R:
                    return ChangeRound();

                case ConsoleKey.H:
                    return ChangeHP();

                case ConsoleKey.D:
                    return MakeDeathThrow();

                case ConsoleKey.T:
                    return ChangeTHP();

                default:
                    return LocalizationsStash.SelectedLocalization[EnumActionsWithSheet.WrongInput];
            }
        }

        public string ChangeRound()
        {
            _pressedKey = Console.ReadKey();
            switch (_pressedKey.Key)
            {
                case ConsoleKey.OemPlus:
                    CurrentHeroSheet.HeroSheet.SheetCombatAbilities.CombatStats[EnumCombatStatsDND5e.Round]++;
                    return LocalizationsStash.SelectedLocalization[EnumCombatActionsTexts.RoundPlus];

                case ConsoleKey.OemMinus:
                    if (CurrentHeroSheet.HeroSheet.SheetCombatAbilities.CombatStats[EnumCombatStatsDND5e.Round] - 1 != 0)
                    {
                        CurrentHeroSheet.HeroSheet.SheetCombatAbilities.CombatStats[EnumCombatStatsDND5e.Round]--;
                    }
                    return LocalizationsStash.SelectedLocalization[EnumCombatActionsTexts.RoundMinus];

                case ConsoleKey.R:
                    CurrentHeroSheet.HeroSheet.SheetCombatAbilities.CombatStats[EnumCombatStatsDND5e.Round] = 1;
                    return LocalizationsStash.SelectedLocalization[EnumCombatActionsTexts.RoundRestore];

                default:
                    return LocalizationsStash.SelectedLocalization[EnumActionsWithSheet.WrongInput];
            }
        }
        
        public string ChangeHP()
        {
            _pressedKey = Console.ReadKey();
            switch (_pressedKey.Key)
            {
                case ConsoleKey.OemPlus:
                    if (CurrentHeroSheet.HeroSheet.SheetCombatAbilities.CombatStats[EnumCombatStatsDND5e.CurrentHP] < CurrentHeroSheet.HeroSheet.SheetCombatAbilities.CombatStats[EnumCombatStatsDND5e.MaximumHP])
                    {
                        CurrentHeroSheet.HeroSheet.SheetCombatAbilities.CombatStats[EnumCombatStatsDND5e.CurrentHP]++;
                    }
                    return LocalizationsStash.SelectedLocalization[EnumCombatActionsTexts.HPPlus];

                case ConsoleKey.OemMinus:
                    if (CurrentHeroSheet.HeroSheet.SheetCombatAbilities.CombatStats[EnumCombatStatsDND5e.CurrentHP] > 0)
                    {
                        CurrentHeroSheet.HeroSheet.SheetCombatAbilities.CombatStats[EnumCombatStatsDND5e.CurrentHP]--;
                    }
                    return LocalizationsStash.SelectedLocalization[EnumCombatActionsTexts.HPMinus];

                case ConsoleKey.R:
                    CurrentHeroSheet.HeroSheet.SheetCombatAbilities.CombatStats[EnumCombatStatsDND5e.CurrentHP] = CurrentHeroSheet.HeroSheet.SheetCombatAbilities.CombatStats[EnumCombatStatsDND5e.MaximumHP];
                    return LocalizationsStash.SelectedLocalization[EnumCombatActionsTexts.HPRestore];

                default:
                    return LocalizationsStash.SelectedLocalization[EnumActionsWithSheet.WrongInput];
            }
        }

        public string MakeDeathThrow()
        {
            _pressedKey = Console.ReadKey();
            switch (_pressedKey.Key)
            {
                case ConsoleKey.D:
                    if (RollRandom.LetsRoll.Next(1, (int)EnumDices.d20) >= 10)
                    {
                        CurrentHeroSheet.HeroSheet.SheetCombatAbilities.CombatStats[EnumCombatStatsDND5e.DeathSucces]++;
                        if (CurrentHeroSheet.HeroSheet.SheetCombatAbilities.CombatStats[EnumCombatStatsDND5e.DeathSucces] == 3)
                        {
                            return LocalizationsStash.SelectedLocalization[EnumCombatActionsTexts.DeathThrowAlive];
                        }
                        return LocalizationsStash.SelectedLocalization[EnumCombatActionsTexts.DeathThrowSucces];
                    }
                    else
                    {
                        CurrentHeroSheet.HeroSheet.SheetCombatAbilities.CombatStats[EnumCombatStatsDND5e.DeathFailure]++;
                        if (CurrentHeroSheet.HeroSheet.SheetCombatAbilities.CombatStats[EnumCombatStatsDND5e.DeathFailure] == 3)
                        {
                            return LocalizationsStash.SelectedLocalization[EnumCombatActionsTexts.DeathThrowDeath];
                        }
                        return LocalizationsStash.SelectedLocalization[EnumCombatActionsTexts.DeathThrowFailure];
                    }

                case ConsoleKey.R:
                    CurrentHeroSheet.HeroSheet.SheetCombatAbilities.ResetDeathSaves();
                    return LocalizationsStash.SelectedLocalization[EnumCombatActionsTexts.DeathThrowReset];

                default:
                    return LocalizationsStash.SelectedLocalization[EnumActionsWithSheet.WrongInput];
            }
        }

        public string ChangeTHP()
        {
            _pressedKey = Console.ReadKey();
            switch (_pressedKey.Key)
            {
                case ConsoleKey.OemPlus:
                    CurrentHeroSheet.HeroSheet.SheetCombatAbilities.CombatStats[EnumCombatStatsDND5e.TemporaryHP]++;
                    return LocalizationsStash.SelectedLocalization[EnumCombatActionsTexts.HPTempPlus];

                case ConsoleKey.OemMinus:
                    if (CurrentHeroSheet.HeroSheet.SheetCombatAbilities.CombatStats[EnumCombatStatsDND5e.TemporaryHP] > 0)
                    {
                        CurrentHeroSheet.HeroSheet.SheetCombatAbilities.CombatStats[EnumCombatStatsDND5e.TemporaryHP]--;
                    }
                    return LocalizationsStash.SelectedLocalization[EnumCombatActionsTexts.HPTempMinus];

                case ConsoleKey.R:
                    CurrentHeroSheet.HeroSheet.SheetCombatAbilities.CombatStats[EnumCombatStatsDND5e.TemporaryHP] = 0;
                    return LocalizationsStash.SelectedLocalization[EnumCombatActionsTexts.HPTempRestore];

                default:
                    return LocalizationsStash.SelectedLocalization[EnumActionsWithSheet.WrongInput];
            }
        }
    }
}