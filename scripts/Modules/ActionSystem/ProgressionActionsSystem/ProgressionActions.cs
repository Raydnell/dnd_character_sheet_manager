namespace dnd_character_sheet
{
    public class ProgressionActions : IProgressionSystem
    {
        private ConsoleKeyInfo _pressedKey;
        
        public string ChooseAction()
        {
            _pressedKey = Console.ReadKey();
            switch (_pressedKey.Key)
            {
                case ConsoleKey.E:
                    return ChangeExpiriense();

                case ConsoleKey.V:
                    return ChangeInspiration();
            }

            return LocalizationsStash.SelectedLocalization[EnumActionsWithSheet.WrongInput];
        }

        public string ChangeExpiriense()
        {
            _pressedKey = Console.ReadKey();

            if (int.TryParse(Console.ReadLine(), out int result))
            {
                switch (_pressedKey.Key)
                {
                    case ConsoleKey.OemPlus:
                        CurrentHeroSheet.HeroSheet.SheetProgression.GainExpirience(result);
                        return $"{LocalizationsStash.SelectedLocalization[EnumProgressionActions.ExpGained]} {result}";

                    case ConsoleKey.OemMinus:
                        CurrentHeroSheet.HeroSheet.SheetProgression.LowerExpirience(result);
                        return $"{LocalizationsStash.SelectedLocalization[EnumProgressionActions.ExpLowered]} {result}";
                }
            }

            return LocalizationsStash.SelectedLocalization[EnumActionsWithSheet.WrongInput];
        }

        public string ChangeInspiration()
        {
            CurrentHeroSheet.HeroSheet.ChangeInspiration();
            if (CurrentHeroSheet.HeroSheet.Inspiration)
            {
                return LocalizationsStash.SelectedLocalization[EnumProgressionActions.InspirationTrue];
            }
            else
            {
                return LocalizationsStash.SelectedLocalization[EnumProgressionActions.InspirationFalse];
            }
        }
    }
}