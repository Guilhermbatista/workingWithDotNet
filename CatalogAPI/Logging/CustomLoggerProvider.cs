using System.Collections.Concurrent;

namespace CatalogAPI.Logging;

public class CustomLoggerProvider : ILoggerProvider
{

    readonly CustomLoggerProviderConfiguration loggerConfig;

    readonly ConcurrentDictionary<string, CustomLogger> logger = new ConcurrentDictionary<string, CustomLogger>();

    public CustomLoggerProvider(CustomLoggerProviderConfiguration config)
    {
        this.loggerConfig = config;
    }

    public ILogger CreateLogger(string categoryName)
    {
        return (ILogger)logger.GetOrAdd(categoryName, name => new CustomLogger(logger, loggerConfig));
    }

    public void Dispose()
    {
       logger.Clear();
    }
}
