using Spectre.Console;

namespace dnd_character_sheet
{
    public class ScreenActionsWithSheet : IScreen
    {
        private int _count;

        public ScreenActionsWithSheet()
        {
            _count = 1;
        }

        public void ShowScreen()
        {
            // Create a table
            var table = new Table();

            // Add some columns
            table.AddColumn("Foo");
            table.AddColumn(new TableColumn("Bar").Centered());

            // Add some rows
            table.AddRow("Baz", "[green]Qux[/]");
            table.AddRow(new Markup("[blue]Corgi[/]"), new Panel("Waldo"));

            // Render the table to the console
            AnsiConsole.Write(table);
            Console.ReadKey();
        }
    }
}