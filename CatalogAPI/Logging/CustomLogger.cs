using System.Collections.Concurrent;

namespace CatalogAPI.Logging
{
    public class CustomLogger : ILogger
    {
        readonly string loggerName;
        readonly CustomLoggerProviderConfiguration configuration;

        public CustomLogger(string loggerName, CustomLoggerProviderConfiguration configuration)
        {
            this.loggerName = loggerName;
            this.configuration = configuration;
        }

        public CustomLogger(ConcurrentDictionary<string, CustomLogger> logger, CustomLoggerProviderConfiguration loggerConfig)
        {
            Logger = logger;
            LoggerConfig = loggerConfig;
        }

        public ConcurrentDictionary<string, CustomLogger> Logger { get; }
        public CustomLoggerProviderConfiguration LoggerConfig { get; }

        public IDisposable? BeginScope<TState>(TState state) where TState : notnull
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return logLevel == configuration.LogLevel;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            string message = $"{logLevel.ToString()} {eventId.Id} - {formatter(state, exception)}";

            WriteTextToFile(message);
        }

        private void WriteTextToFile(string message)
        {
            string caminhoArquivoLog = @"D:\teste\log.txt";

            using (StreamWriter streamWriter = new StreamWriter(caminhoArquivoLog, true))
            {
                try
                {
                    streamWriter.WriteLine(message);
                    streamWriter.Close();
                }
                catch (Exception) 
                {
                    throw;
                }
            }
                
        }
    }
}
