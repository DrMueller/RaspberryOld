using System;
using System.Threading.Tasks;

namespace ARGUSnet.RaspberryPiTooling.WpfUI.Infrastructure.ExceptionHandling
{
    public class ExceptionHandler
    {
        private readonly ExceptionLogger _logger;
        private Action<Exception> _exceptionCallback;

        public ExceptionHandler(ExceptionLogger logger)
        {
            _logger = logger;
        }

        #region Public/Internal Methods

        internal void HandledAction(Action action)
        {
            try
            {
                action();
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        internal async Task HandledActionAsync(Func<Task> action, Action finallyAction = null)
        {
            try
            {
                await action();
            }

            catch (OperationCanceledException)
            {
                // Nothing to do
            }

            catch (Exception ex)
            {
                HandleException(ex);
            }

            finally
            {
                finallyAction?.Invoke();
            }
        }

        internal T HandledFunction<T>(Func<T> func)
        {
            try
            {
                return func();
            }
            catch (Exception ex)
            {
                HandleException(ex);
                return default(T);
            }
        }

        internal async Task<T> HandledFunctionAsync<T>(Func<Task<T>> func)
        {
            try
            {
                var result = await func();
                return result;
            }
            catch (Exception ex)
            {
                HandleException(ex);
                return default(T);
            }
        }

        internal void SetExceptionCallback(Action<Exception> exceptionCallback)
        {
            _exceptionCallback = exceptionCallback;
        }

        #endregion

        #region Private Methods

        private void HandleException(Exception ex)
        {
            _exceptionCallback?.Invoke(ex);
            _logger.LogException(ex);
        }

        #endregion
    }
}