using System.Linq;
using System.Text;
using System.Windows.Media;
using ARGUSnet.RaspberryPiTooling.WpfUI.Models.Led;

namespace ARGUSnet.RaspberryPiTooling.WpfUI.Logics.Led
{
    public class VisualLedPanelCodeCalculator
    {
        #region Public/Internal Methods

        internal string CalculateCode(VisualLedList visualLedList)
        {
            var sb = new StringBuilder();
            var sortedList = visualLedList.OrderBy(f => f.Row).ThenBy(f => f.Column);

            sb.Append("var result = new VisualLedPanel();");
            sb.AppendLine();
            foreach (var visualLed in sortedList)
            {
                var colorDescription = GetCodeColorDescription(visualLed.Color);

                sb.AppendLine();
                sb.Append($"result[{visualLed.Column}, {visualLed.Row}].VisualColor = {colorDescription};");
            }

            sb.AppendLine();
            sb.AppendLine();
            sb.Append("return result;");

            return sb.ToString();
        }

        #endregion

        #region Private Methods

        private static string GetCodeColorDescription(Color color)
        {
            var result = string.Empty;
            string preDefinedColorName;

            if (TryGettingPreDfinedColor(color, out preDefinedColorName))
            {
                result = $"Colors.{preDefinedColorName}.ToVisualLedColor()";
            }
            else
            {
                result = $"\"{color}\"";
            }

            return result;
        }

        private static bool TryGettingPreDfinedColor(Color color, out string name)
        {
            var predefinedColorProperties = typeof(Colors).GetProperties();
            var foundColorProperty = predefinedColorProperties.FirstOrDefault(f => (Color)f.GetValue(null) == color);

            if (foundColorProperty != null)
            {
                name = foundColorProperty.Name;
                return true;
            }

            name = string.Empty;
            return false;
        }

        #endregion
    }
}