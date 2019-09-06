using System;
using System.Linq;
using System.Reflection;

namespace ARGUSnet.RaspberryPiFramework.NetworkIntegration.Services.Workers.Shell
{
    public class WorkerDispatcher
    {
        public void Dispatch(Model.Common.ActionCommand actionCommand)
        {
            var workerInstance = CreateWorkerInstance(actionCommand.WorkerName);
            InvokeMethod(workerInstance, actionCommand.WorkerMethod, actionCommand.WorkerMethodParameterValue);
        }

        private AbstractWorker CreateWorkerInstance(string workerName)
        {
            var workerType = typeof(WorkerDispatcher).GetTypeInfo().Assembly.GetTypes().FirstOrDefault(f => typeof(AbstractWorker).IsAssignableFrom(f) && f.Name == workerName);
            if (workerType == null)
            {
                throw new NotImplementedException("Worker not found:  " + workerName);
            }

            var result = (AbstractWorker)Activator.CreateInstance(workerType);
            return result;
        }

        private void InvokeMethod(AbstractWorker workerInstance, string workerMethod, object workerMethodParameterValue)
        {
            var method = workerInstance.GetType().GetTypeInfo().DeclaredMethods.FirstOrDefault(f => f.Name == workerMethod);
            if (method == null)
            {
                throw new NotImplementedException($"Method {workerMethod} not found on Worker {workerInstance.GetType().Name}");
            }

            method.Invoke(workerInstance, new[] {workerMethodParameterValue});
        }
    }
}