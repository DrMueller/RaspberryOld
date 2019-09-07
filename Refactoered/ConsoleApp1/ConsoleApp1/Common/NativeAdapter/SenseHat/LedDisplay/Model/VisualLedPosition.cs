using System;

namespace ARGUSnet.RasperryPi2.NativeAdapter.SenseHat.LedDisplay.Model
{
    public class VisualLedPosition : IEquatable<VisualLedPosition>
    {
        #region Constructors

        public VisualLedPosition(int x, int y)
        {
            X = x;
            Y = y;
        }

        #endregion Constructors

        #region Private Methods

        private static bool CheckEquality(VisualLedPosition left, VisualLedPosition right)
        {
            return left.X == right.X && left.Y == right.Y;
        }

        #endregion Private Methods

        #region Properties

        public int X { get; }

        public int Y { get; }

        #endregion Properties

        #region Public Methods

        public static bool operator !=(VisualLedPosition left, VisualLedPosition right)
        {
            return !CheckEquality(left, right);
        }

        public static bool operator ==(VisualLedPosition left, VisualLedPosition right)
        {
            return CheckEquality(left, right);
        }

        public bool Equals(VisualLedPosition other)
        {
            return CheckEquality(this, other);
        }

        public override bool Equals(object obj)
        {
            if (obj is VisualLedPosition)
            {
                return CheckEquality(this, (VisualLedPosition)obj);
            }

            return false;
        }

        public override int GetHashCode()
        {
            return string.Format("{0}{1}", X, Y).GetHashCode();
        }

        #endregion Public Methods
    }
}