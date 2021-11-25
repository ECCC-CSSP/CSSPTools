namespace CSSPWebAPIs;

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
                    configuration.AddJsonFile("appsettings_csspwebapis.json");
                    configuration.AddUserSecrets("41c4156a-4b42-42e9-923a-e9c8360dba12");
                });
                webBuilder.UseStartup<Startup>();
                webBuilder.UseUrls("http://localhost:4448");
            });
}

