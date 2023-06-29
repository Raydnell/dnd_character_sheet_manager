using Spectre.Console;

namespace dnd_character_sheet
{
    public class ShowControls
    {
        private PanelCreate _panel;
        private Table _table;

        public ShowControls()
        {
            _panel = new PanelCreate();
            _table = new Table();
        }

        public void Show()
        {
            if (_table.Rows.Count == 0)
            {
                BuildTable();
            }

            Console.Clear();
            AnsiConsole.Write(_table);
            Console.ReadKey();
        }

        private void BuildTable()
        {
            _table.AddColumns(new string[]{ "1", "2" });
            _table.HideHeaders();
            _table.Border = TableBorder.DoubleEdge;
            _table.AddRow(
                _panel.MakePanelFromString(LocalizationsStash.SelectedLocalization[EnumActionsWithSheet.ControlsDescriptionOne], $"[underline red]{LocalizationsStash.SelectedLocalization[EnumActionsWithSheet.ControlsKeys]}[/]"),
                _panel.MakePanelFromString(LocalizationsStash.SelectedLocalization[EnumActionsWithSheet.ControlsDescriptionTwo], $"[underline red]{LocalizationsStash.SelectedLocalization[EnumActionsWithSheet.ControlsKeys]}[/]")
            );
        }
    }
}