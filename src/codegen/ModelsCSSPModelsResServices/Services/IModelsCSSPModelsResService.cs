using System.Threading.Tasks;

namespace ModelsCSSPModelsResServices.Services
{
    public interface IModelsCSSPModelsResService
    {
        Task<bool> Run(string[] args);
    }
}