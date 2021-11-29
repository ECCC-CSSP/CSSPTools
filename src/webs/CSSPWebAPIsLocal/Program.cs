namespace CSSPWebAPIsLocal;

public class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Start();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.ConfigureAppConfiguration(configuration =>
                {
                    configuration.AddJsonFile("appsettings_csspwebapislocal.json");
                });
                webBuilder.UseStartup<Startup>();
                webBuilder.UseUrls("http://localhost:4446");
            });
}

