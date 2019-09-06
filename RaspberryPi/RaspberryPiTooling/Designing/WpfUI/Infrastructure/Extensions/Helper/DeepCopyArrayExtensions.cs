using System;

namespace ARGUSnet.RaspberryPiTooling.WpfUI.Infrastructure.Extensions.Helper
{
    internal static class DeepCopyArrayExtensions
    {
        #region Public/Internal Methods

        public static void ForEach(this Array array, Action<Array, int[]> action)
        {
            if (array.LongLength == 0)
            {
                return;
            }

            var walker = new DeepCopyArrayTraverse(array);

            do
            {
                action(array, walker.Position);
            } while (walker.Step());
        }

        #endregion
    }
}