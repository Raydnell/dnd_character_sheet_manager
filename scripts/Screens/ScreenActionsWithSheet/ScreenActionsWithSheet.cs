using Spectre.Console;
using System.Text;

namespace dnd_character_sheet
{
    public class ScreenActionsWithSheet : IScreen
    {
        private Table _table;
        private ConsoleKeyInfo _pressedKey;
        private EquipmentSystem _equipmentSystem;
        private TextBuilder _textBuilder;
        private RollThrower _rollThrower;
        private CombatActions _combatActions;
        private ProgressionActions _progressionActions;
        private PanelCreate _panelCreate;
        private ThrowChecksSystem _throwChecksSystem;
        private AttackHandSystem _attackHandSystem;
        private FieldEditSystem _fieldEditSystem;
        private SpellsEditSystem _spellsEditSystem;
        private TraitsEditSystem _traitsEditSystem;
        private ShowControls _showControls;
        private IScreen _screenWorkWithInventory;

        public ScreenActionsWithSheet()
        {
            _table = new Table();
            _equipmentSystem = new EquipmentSystem();
            _textBuilder = new TextBuilder();
            _rollThrower = new RollThrower();
            _combatActions = new CombatActions();
            _progressionActions = new ProgressionActions();
            _panelCreate = new PanelCreate();
            _throwChecksSystem = new ThrowChecksSystem();
            _attackHandSystem = new AttackHandSystem();
            _fieldEditSystem = new FieldEditSystem();
            _spellsEditSystem = new SpellsEditSystem();
            _traitsEditSystem = new TraitsEditSystem();
            _showControls = new ShowControls();
            _screenWorkWithInventory = new ScreenWorkWithInventory();
        }

        public void ShowScreen()
        {
            var isExit = false;
            
            if (_table.Rows.Count == 0)
            {
                BuildTable();
            }

            Console.Clear();
            AnsiConsole.Write(_table);
            DrawInputBox();

            while (isExit == false)
            {
                _pressedKey = Console.ReadKey();
                switch (_pressedKey.Key)
                {
                    case ConsoleKey.T:
                        _textBuilder.NewMessageToLog(_throwChecksSystem.ChooseAction());
                        break;

                    case ConsoleKey.I:
                        _screenWorkWithInventory.ShowScreen();
                        break;

                    case ConsoleKey.E:
                        _textBuilder.NewMessageToLog(_equipmentSystem.ChooseAction());
                        SheetFormulas.CalculateArmorClass();
                        break;

                    case ConsoleKey.C:
                        _textBuilder.NewMessageToLog(_attackHandSystem.ChooseAction());
                        break;

                    case ConsoleKey.R:
                        _textBuilder.NewMessageToLog(_rollThrower.ChooseAction());
                        break;

                    case ConsoleKey.W:
                        _textBuilder.NewMessageToLog(_combatActions.ChooseAction());
                        break;

                    case ConsoleKey.P:
                        _textBuilder.NewMessageToLog(_progressionActions.ChooseAction());
                        break;

                    case ConsoleKey.S:
                        _spellsEditSystem.StartWorkWithSpells();
                        break;

                    case ConsoleKey.L:
                        _textBuilder.NewMessageToLog(_fieldEditSystem.ChooseAction());
                        break;

                    case ConsoleKey.H:
                        _traitsEditSystem.StartWorkWithTraits();
                        break;

                    case ConsoleKey.O:
                        _showControls.Show();
                        break;

                    case ConsoleKey.Escape:
                        isExit = true;
                        break;

                    default:
                        _textBuilder.NewMessageToLog(LocalizationsStash.SelectedLocalization[EnumActionsWithSheet.WrongInput]);
                        break;
                }

                CurrentHeroSheet.SaveSheet();
                Console.Clear();
                UpdateTable();
                AnsiConsole.Write(_table);
                DrawInputBox();
            }
        }

        private void BuildTable()
        {
            _table.AddColumns(new string[]{ "1", "2", "3", "4" });
            _table.HideHeaders();
            _table.Border = TableBorder.DoubleEdge;
            
            _textBuilder.NewMessageToLog(LocalizationsStash.SelectedLocalization[EnumActionsWithSheet.MessagesWillBeHere]);
            _table.AddRow(
                _panelCreate.MakePanelFromString(_textBuilder.BuildHero(), $"[underline yellow]{LocalizationsStash.SelectedLocalization[EnumPrintSheetInfoTitles.Hero]}[/]"), 
                _panelCreate.MakePanelFromString(_textBuilder.BuildAbilitiesWithSaveThrows(), $"[underline yellow]{LocalizationsStash.SelectedLocalization[EnumPrintSheetInfoTitles.Abilities]}[/]"),
                _panelCreate.MakePanelFromString(_textBuilder.BuildCombatStats(), $"[underline yellow]{LocalizationsStash.SelectedLocalization[EnumPrintSheetInfoTitles.CombatStats]}[/]"), 
                _panelCreate.MakePanelFromString(_textBuilder.BuildMessageBox(), $"[underline yellow]{LocalizationsStash.SelectedLocalization[EnumActionsWithSheet.MessageBox]}[/]")
                );

            _table.AddRow(
                _panelCreate.MakePanelFromString(_textBuilder.BuildSkills(), $"[underline yellow]{LocalizationsStash.SelectedLocalization[EnumPrintSheetInfoTitles.Skills]}[/]"),
                _panelCreate.MakePanelFromString(_textBuilder.BuildProficiencies(), $"[underline yellow]{LocalizationsStash.SelectedLocalization[EnumPrintSheetInfoTitles.Proficiencies]}[/]"),
                _panelCreate.MakePanelFromString(_textBuilder.BuildPersonality(), $"[underline yellow]{LocalizationsStash.SelectedLocalization[EnumPrintSheetInfoTitles.PersonalityList]}[/]"),
                _panelCreate.MakePanelFromString(_textBuilder.BuildEquipmentStats(), $"[underline yellow]{LocalizationsStash.SelectedLocalization[EnumActionsWithSheet.EquipmentSlots]}[/]")
                );

            _table.AddRow(
                _panelCreate.MakePanelFromString(_textBuilder.BuildScreensPoints(), $"[underline yellow]{LocalizationsStash.SelectedLocalization[EnumActionsWithSheet.OpenScreens]}[/]")
                );
        }

        private void UpdateTable()
        {
            _table.UpdateCell(0, 3, _panelCreate.MakePanelFromString(_textBuilder.BuildMessageBox(), $"[underline yellow]{LocalizationsStash.SelectedLocalization[EnumActionsWithSheet.MessageBox]}[/]"));
            _table.UpdateCell(1, 3, _panelCreate.MakePanelFromString(_textBuilder.BuildEquipmentStats(), $"[underline yellow]{LocalizationsStash.SelectedLocalization[EnumActionsWithSheet.EquipmentSlots]}[/]"));
            _table.UpdateCell(0, 2, _panelCreate.MakePanelFromString(_textBuilder.BuildCombatStats(), $"[underline yellow]{LocalizationsStash.SelectedLocalization[EnumPrintSheetInfoTitles.CombatStats]}[/]"));
            _table.UpdateCell(0, 0, _panelCreate.MakePanelFromString(_textBuilder.BuildHero(), $"[underline yellow]{LocalizationsStash.SelectedLocalization[EnumPrintSheetInfoTitles.Hero]}[/]"));
            _table.UpdateCell(0, 1, _panelCreate.MakePanelFromString(_textBuilder.BuildAbilitiesWithSaveThrows(), $"[underline yellow]{LocalizationsStash.SelectedLocalization[EnumPrintSheetInfoTitles.Abilities]}[/]"));
            _table.UpdateCell(1, 0,  _panelCreate.MakePanelFromString(_textBuilder.BuildSkills(), $"[underline yellow]{LocalizationsStash.SelectedLocalization[EnumPrintSheetInfoTitles.Skills]}[/]"));
            _table.UpdateCell(1, 1, _panelCreate.MakePanelFromString(_textBuilder.BuildProficiencies(), $"[underline yellow]{LocalizationsStash.SelectedLocalization[EnumPrintSheetInfoTitles.Proficiencies]}[/]"));
            _table.UpdateCell(1, 2, _panelCreate.MakePanelFromString(_textBuilder.BuildPersonality(), $"[underline yellow]{LocalizationsStash.SelectedLocalization[EnumPrintSheetInfoTitles.PersonalityList]}[/]"));
        }

        private void DrawInputBox()
        {
            AnsiConsole.Write(_panelCreate.MakePanelFromString("                            ", $"[underline yellow]{LocalizationsStash.SelectedLocalization[EnumActionsWithSheet.InputPanel]}[/]"));
            Console.SetCursorPosition(Console.GetCursorPosition().Left + 2, Console.GetCursorPosition().Top - 2);
        } 
    }
}
