using System.Windows.Input;
using System.Windows.Media;
using ARGUSnet.RaspberryPiTooling.WpfUI.Commands;
using ARGUSnet.RaspberryPiTooling.WpfUI.Infrastructure.ExceptionHandling;
using ARGUSnet.RaspberryPiTooling.WpfUI.Logics.Led;
using ARGUSnet.RaspberryPiTooling.WpfUI.Models.Led;
using ARGUSnet.RaspberryPiTooling.WpfUI.ViewModels.Shell;
using PropertyChanged;

namespace ARGUSnet.RaspberryPiTooling.WpfUI.ViewModels
{
    [ImplementPropertyChanged]
    public class LedDesignViewModel : ViewModelBase
    {
        private readonly VisualLedPanelCareTaker _careTaker;
        private readonly VisualLedPanelCodeCalculator _ledPanelCodeCalculator;
        public string ColorGroupBoxName = "Color-Selection";

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors", Justification = "Fody")]
        public LedDesignViewModel(ExceptionHandler exceptionHandler, VisualLedPanel visualLedLedPanel, VisualLedPanelCodeCalculator ledPanelCodeCalculator, VisualLedPanelCareTaker careTaker) : base(exceptionHandler)
        {
            VisualLedPanel = visualLedLedPanel;
            _ledPanelCodeCalculator = ledPanelCodeCalculator;
            _careTaker = careTaker;
        }

        #region Properties

        public ViewModelCommand ConvertLedsToCode
        {
            get
            {
                return new ViewModelCommand("To C#",
                    new ActionCommand(() =>
                    {
                        LedPanelCode = _ledPanelCodeCalculator.CalculateCode(VisualLedPanel.VisualLeds);
                    }));
            }
        }

        public override string DisplayName { get; } = "Fun with LED-Design";

        public ViewModelCommand DyeAllLeds
        {
            get
            {
                return new ViewModelCommand("Dye all",
                    new ActionCommand(() =>
                    {
                        CreateLedPanelMementoEntry();
                        VisualLedPanel.VisualLeds.ForEach(f => f.Color = SelectedColor.Value);
                    }, () => SelectedColor.HasValue));
            }
        }

        public string LedPanelCode { get; private set; }

        public Color? SelectedColor { get; set; }

        public ICommand SetSingleColor
        {
            get
            {
                return new RelayCommand(f =>
                {
                    if (SelectedColor.HasValue)
                    {
                        CreateLedPanelMementoEntry();
                        var visualLed = f as VisualLed;
                        visualLed.Color = SelectedColor.Value;
                    }
                });
            }
        }

        public ViewModelCommand UndoLedAction
        {
            get
            {
                return new ViewModelCommand("Undo",
                    new ActionCommand(() =>
                    {
                        var memento = _careTaker.Pop();
                        VisualLedPanel.RestoreMemento(memento);
                    }, () => _careTaker.HasHentries));
            }
        }

        public VisualLedPanel VisualLedPanel { get; private set; }

        #endregion

        #region Private Methods

        private void CreateLedPanelMementoEntry()
        {
            var memento = VisualLedPanel.CreateMemento();
            _careTaker.Push(memento);
        }

        #endregion
    }
}