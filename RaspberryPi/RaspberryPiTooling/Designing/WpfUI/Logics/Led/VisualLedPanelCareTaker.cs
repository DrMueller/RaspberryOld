using System.Collections.Generic;
using System.Linq;

namespace ARGUSnet.RaspberryPiTooling.WpfUI.Logics.Led
{
    public class VisualLedPanelCareTaker
    {
        private readonly Stack<VisualLedPanelMemento> _mementos = new Stack<VisualLedPanelMemento>();

        #region Properties

        internal bool HasHentries => _mementos.Any();

        #endregion

        #region Public/Internal Methods

        internal VisualLedPanelMemento Pop()
        {
            return _mementos.Pop();
        }

        internal void Push(VisualLedPanelMemento memento)
        {
            _mementos.Push(memento);
        }

        #endregion
    }
}