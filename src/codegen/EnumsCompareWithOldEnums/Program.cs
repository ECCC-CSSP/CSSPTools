using EnumsCompareWithOldEnumsServices.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EnumsCompareWithOldEnums
{
    partial class Program
    {
        #region Variables
        public static IServiceCollection serviceCollection;
        #endregion Variables

        #region Entry
        static void Main(string[] args)
        {
            serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton<IEnumsCompareWithOldEnumsService, EnumsCompareWithOldEnumsService>();
            ServiceProvider provider = serviceCollection.BuildServiceProvider();
            IEnumsCompareWithOldEnumsService enumsCompareWithOldEnumsService = provider.GetService<IEnumsCompareWithOldEnumsService>();

            enumsCompareWithOldEnumsService.Run(args);
        }
        #endregion Entry

        #region Functions private
        #endregion Functions private
    }
}
