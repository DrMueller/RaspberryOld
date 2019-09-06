using ARGUSnet.RaspberryPiTooling.WpfUI.Models.Led;

namespace ARGUSnet.RaspberryPiTooling.WpfUI.Logics.Led
{
    public class VisualLedPanelMemento
    {
        public VisualLedPanelMemento(VisualLedList visualLedList)
        {
            VisualLedList = visualLedList;
        }

        #region Properties

        internal VisualLedList VisualLedList { get; private set; }

        #endregion
    }
}