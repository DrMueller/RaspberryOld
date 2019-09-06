using System;

namespace ARGUSnet.RaspberryPiFramework.Model.SenseHat.LedDisplay
{
    public class VisualLed
    {
        public int X { get; private set; }

        public int Y { get; private set; }

        public VisualColor VisualColor { get; set; }

        public VisualLed(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
