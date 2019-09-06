using System;

namespace ARGUSnet.RaspberryPiFramework.Model.Common
{
    public class ActionCommand
    {
        public string WorkerMethod { get; set; }

        public object WorkerMethodParameterValue { get; set; }

        public string WorkerMethodParameterTypeName { get; set; }

        public string WorkerName { get; set; }
    }
}