using System.Windows.Media;
using PropertyChanged;

namespace ARGUSnet.RaspberryPiTooling.WpfUI.Models.Led
{
    [ImplementPropertyChanged]
    public class VisualLed
    {
        public VisualLed(int row, int column)
        {
            Row = row;
            Column = column;
            Color = Colors.AntiqueWhite;
        }

        #region Properties

        public Color Color { get; set; }

        public int Column { get; set; }

        public int Row { get; set; }

        #endregion
    }
}