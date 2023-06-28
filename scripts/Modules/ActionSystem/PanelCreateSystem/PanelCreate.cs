using Spectre.Console;

namespace dnd_character_sheet
{
    public class PanelCreate
    {
        private Panel _panel;
        
        public Panel MakePanelFromString(string text, string header = "")
        {
            _panel = new Panel(text);
            _panel.Border = BoxBorder.Square;
            if (header != "")
            {
                _panel.Header = new PanelHeader(header, Justify.Left);
            }
            _panel.HeaderAlignment(Justify.Center);

            return _panel;
        }
    }
}