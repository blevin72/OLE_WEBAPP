using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OLE_WEBAPP.Data;

public class Startup
{
    private IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        // Add any additional services here if needed
    }
}
