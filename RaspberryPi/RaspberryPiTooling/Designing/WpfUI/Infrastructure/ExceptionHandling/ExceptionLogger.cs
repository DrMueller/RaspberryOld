using System;
using NLog;

namespace ARGUSnet.RaspberryPiTooling.WpfUI.Infrastructure.ExceptionHandling
{
    public class ExceptionLogger
    {
        private const string ERROR_LOGGER = "ERRORS";
        private readonly Logger _logger = LogManager.GetLogger(ERROR_LOGGER);

        #region Public/Internal Methods

        internal void LogException(Exception ex)
        {
            _logger.Log(LogLevel.Error, ex);
        }

        #endregion
    }
}