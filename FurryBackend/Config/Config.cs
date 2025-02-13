
public class Config(IConfiguration config)
{
    public string StorageUrl { get; } = config["StorageUrl"] ?? "";
}
