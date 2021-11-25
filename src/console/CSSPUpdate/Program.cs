namespace CSSPUpdate;

public class Program
{
    public static async Task<int> Main(string[] args)
    {
        Startup startup = new Startup();

        if (!await startup.Setup())
        {
            Console.WriteLine($"{ string.Format(CSSPCultureServicesRes.Error_, "CSSPUpdate - startup.Setup") }");
            return await Task.FromResult(1);
        }

        if (!await startup.CSSPUpdateService.RunCommand(args))
        {
            Console.WriteLine($"{ string.Format(CSSPCultureServicesRes.Error_, "CSSPUpdate - startup.CSSPUpdateService.RunCommand") }");
            return await Task.FromResult(1);
        }

        return await Task.FromResult(0);
    }
}

