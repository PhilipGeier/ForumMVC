using Forum.Services;
using Microsoft.Extensions.Configuration;

namespace Forum.AutofacDI;

public class AppSettingsDatabaseService : IDatabaseService
{
    private readonly IConfiguration _configuration;

    public AppSettingsDatabaseService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string GetConnectionString()
        => _configuration["ConnectionString"];
}