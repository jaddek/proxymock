using Microsoft.EntityFrameworkCore;

namespace Calendario.API.Options;

public class DBOptions
{
    public const string ConfigKey = "Database";

    public string DatabaseName { get; set; } = String.Empty;
    public string User { get; set; } = String.Empty;
    public string Password { get; set; } = String.Empty;
    public string Host { get; set; } = String.Empty;
    public string Port { get; set; } = String.Empty;

    public override string ToString()
    {
        return String.Format(
            $"Host={Host};Database={DatabaseName};Username={User};Password={Password}"
        );
    }
}