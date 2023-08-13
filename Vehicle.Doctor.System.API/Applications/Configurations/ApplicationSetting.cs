namespace Vehicle.Doctor.System.API.Applications.Configurations;

public class ApplicationSetting
{
    public RedisConfig Redis { get; set; } = new ();
    public JwtConfig Jwt { get; set; } = new ();
    public DatabaseConfig Database { get; set; } = new ();
    public SwaggerConfig Swagger { get; set; } = new ();
    public object Kafka { get; set; } = default!;
}

public class RedisConfig
{
    public string Url { get; set; } = string.Empty;
    public int Ttl { get; set; } = 86400; //86400s =  One day
    public bool Enabled { get; set; }
}

public class JwtConfig
{
    public int ExpiryInMinutes { get; set; }
    public string SigningKey { get; set; } = string.Empty;
    public string Site { get; set; } = string.Empty;
    public string Audience{ get; set; } = string.Empty;
}

public class DatabaseConfig
{
    public string ConnectionString { get; set; } = string.Empty;
}
public class SwaggerConfig
{
    public string Name { get; set; } = string.Empty;
    public bool IsEnable { get; set; }
}