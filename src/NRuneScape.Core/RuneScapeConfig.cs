using System.Reflection;

namespace NRuneScape
{
    public class RuneScapeConfig
    {
        public static string Version { get; } =
            typeof(RuneScapeConfig).GetTypeInfo().Assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion ??
            typeof(RuneScapeConfig).GetTypeInfo().Assembly.GetName().Version.ToString(3) ??
            "Unknown";

        public static string UserAgent { get; } = $"NRuneScape (https://github.com/AntiTcb/NRuneScape, v{Version}";
        public static readonly string APIUrl = "http://services.runescape.com";

        public const int MaxItemsPerPage = 12;
        public LogSeverity LogLevel { get; set; } = LogSeverity.Info;
    }
}
