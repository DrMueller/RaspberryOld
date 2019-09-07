using ARGUSnet.RasperryPi2.Extensions.LedDisplay.Model.Enums;
using Windows.UI;

namespace ARGUSnet.RasperryPi2.Extensions.LedDisplay.Model
{
    internal class HueChunk
    {
        private const byte MAX_VALUE = 255;
        private const byte MIN_VALUE = 0;

        public HueChunk(int hueValue)
        {
            SetMinValue(hueValue);
            SetMaxValue(hueValue);
        }

        public HueChunkType MaxValueType { get; private set; }
        public HueChunkType MinValueType { get; private set; }

        private void SetMaxValue(int hueValue)
        {
            if (hueValue <= 40)
            {
                MaxValueType = HueChunkType.Red;
                return;
            }

            if (hueValue <= 120)
            {
                MaxValueType = HueChunkType.Green;
                return;
            }

            if (hueValue <= 200)
            {
                MaxValueType = HueChunkType.Blue;
                return;
            }

            MaxValueType = HueChunkType.Red;
        }

        private void SetMinValue(int hueValue)
        {
            if (hueValue <= 80)
            {
                MinValueType = HueChunkType.Blue;
                return;
            }

            if (hueValue <= 160)
            {
                MinValueType = HueChunkType.Red;
                return;
            }

            MinValueType = HueChunkType.Green;
        }

        public Color ToColor(byte dynamicColorValue)
        {
            // Dynamic Vlaue between 0 - 213
            var r = GetValueFromType(HueChunkType.Red, dynamicColorValue);
            var g = GetValueFromType(HueChunkType.Green, dynamicColorValue);
            var b = GetValueFromType(HueChunkType.Blue, dynamicColorValue);

            return Color.FromArgb(255, r, g, b);
        }

        private byte GetValueFromType(HueChunkType hueChunkType, byte dynamicColorValue)
        {
            if (hueChunkType == MaxValueType)
            {
                return MAX_VALUE;
            }

            if (hueChunkType == MinValueType)
            {
                return MIN_VALUE;
            }

            return dynamicColorValue;
        }
    }
}
