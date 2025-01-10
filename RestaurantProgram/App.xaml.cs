using Microsoft.Extensions.DependencyInjection;
using RestaurantProgram.EntityFramework;

namespace RestaurantProgram;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App
{
    private static void ConfigureServices(ServiceCollection services)
    {
        services.AddDbContext<Context>();
    }
}