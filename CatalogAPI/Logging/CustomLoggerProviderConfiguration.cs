using System.Collections.Concurrent;

namespace CatalogAPI.Logging;

public class CustomLoggerProviderConfiguration
{
    public LogLevel LogLevel { get; set; } = LogLevel.Warning;
    public int EventId { get; set; } = 0;

    public static implicit operator CustomLoggerProviderConfiguration(ConcurrentDictionary<string, CustomLogger> v)
    {
        throw new NotImplementedException();
    }
}
