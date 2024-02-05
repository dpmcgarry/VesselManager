namespace libVesselManager;

public class MariaDBOptions
{
    public const string MariaDB = "MariaDB";
    public string Host { get; set; } = "localhost";
    public int Port { get; set; } = 3306;
    public string Database { get; set; } = "boatdb";
    public string User { get; set; } = String.Empty;
    public string Password { get; set; } = String.Empty;
}