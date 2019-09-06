using ARGUSnet.RaspberryPiTooling.WpfUI.Infrastructure.Extensions;
using ARGUSnet.RaspberryPiTooling.WpfUI.Logics.Led;
using PropertyChanged;

namespace ARGUSnet.RaspberryPiTooling.WpfUI.Models.Led
{
    [ImplementPropertyChanged]
    public class VisualLedPanel
    {
        public VisualLedPanel()
        {
            VisualLeds = new VisualLedList();
            for (var row = 0; row <= 7; row++)
            {
                for (var level = 0; level <= 7; level++)
                {
                    VisualLeds.Add(new VisualLed(row, level));
                }
            }
        }

        #region Properties

        public VisualLedList VisualLeds { get; private set; }

        #endregion

        #region Public/Internal Methods

        internal VisualLedPanelMemento CreateMemento()
        {
            return new VisualLedPanelMemento(VisualLeds.DeepCopy());
        }

        internal void RestoreMemento(VisualLedPanelMemento memento)
        {
            VisualLeds = memento.VisualLedList;
        }

        #endregion
    }
}