using ActionCommandDBServices.Services;
using CultureServices.Services;
using Microsoft.Extensions.Configuration;

namespace GenerateCodeBaseServices.Services
{
    public partial class GenerateCodeBaseService : IGenerateCodeBaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Configuration { get; }
        private ICultureService CultureService { get; }
        private IActionCommandDBService ActionCommandDBService { get; }
        #endregion Properties

        #region Constructors
        public GenerateCodeBaseService(IConfiguration configuration, ICultureService cultureService, IActionCommandDBService actionCommandDBService)
        {
            Configuration = configuration;
            CultureService = cultureService;
            ActionCommandDBService = actionCommandDBService;
        }
        #endregion Constructors

        #region Functions public
        // see Helpers folder for more public functions
        #endregion Functions public

        #region Functions private
        #endregion Functions private

    }
}
