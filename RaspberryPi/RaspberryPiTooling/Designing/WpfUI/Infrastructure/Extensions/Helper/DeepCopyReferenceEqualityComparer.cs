using System.Collections.Generic;

namespace ARGUSnet.RaspberryPiTooling.WpfUI.Infrastructure.Extensions.Helper
{
    internal class DeepCopyReferenceEqualityComparer : EqualityComparer<object>
    {
        #region Public/Internal Methods

        public override bool Equals(object x, object y)
        {
            return ReferenceEquals(x, y);
        }

        public override int GetHashCode(object obj)
        {
            return obj?.GetHashCode() ?? 0;
        }

        #endregion
    }
}