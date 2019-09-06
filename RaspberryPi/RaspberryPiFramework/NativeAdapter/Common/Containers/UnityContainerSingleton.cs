using System;
using Microsoft.Practices.Unity;

namespace ARGUSnet.RaspberryPiFramework.NativeAdapter.Common.Containers
{
    internal static class UnityContainerSingleton
    {
        private static readonly Lazy<UnityContainer> LazyUnityContainer;

        static UnityContainerSingleton()
        {
            LazyUnityContainer = new Lazy<UnityContainer>(() => new UnityContainer());
        }

        internal static UnityContainer Instance => LazyUnityContainer.Value;
    }
}
