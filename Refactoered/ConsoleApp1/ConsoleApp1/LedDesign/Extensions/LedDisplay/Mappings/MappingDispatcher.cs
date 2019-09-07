using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ARGUSnet.RasperryPi2.NativeAdapter.SenseHat.LedDisplay.Model;

namespace ARGUSnet.RasperryPi2.Extensions.LedDisplay.Mappings
{
    public class MappingDispatcher
    {
        #region Internal Methods

        internal bool TryMappingPointsFromName(string name, out List<VisualLedPosition> list)
        {
            var mappingType = GetMappingType(name);
            list = null;

            if (mappingType == null)
            {
                return false;
            }

            var mappingInstance = (VisualLedPositionMapping)Activator.CreateInstance(mappingType);
            list = mappingInstance.Map();

            return true;
        }

        internal List<VisualLedPosition> MapFromName(string name)
        {
            var mappingType = GetMappingType(name);
            var mappingInstance = (VisualLedPositionMapping)Activator.CreateInstance(mappingType);
            return mappingInstance.Map();
        }

        #endregion Internal Methods

        #region Private Methods

        private Type GetMappingType(string str)
        {
            const string IMPLEMENTATION_SUFFIX = "Mapping";
            var searchedTypes = typeof(MappingDispatcher).GetTypeInfo().Assembly.GetTypes().Where(f => typeof(VisualLedPositionMapping).IsAssignableFrom(f));

            return searchedTypes.FirstOrDefault(type => type.Name == str + IMPLEMENTATION_SUFFIX);
        }

        #endregion Private Methods
    }
}