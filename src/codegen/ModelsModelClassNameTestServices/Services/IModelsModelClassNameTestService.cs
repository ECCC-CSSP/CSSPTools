using System.Threading.Tasks;

namespace ModelsCSSPModelsResServices.Services
{
    public interface IModelsModelClassNameTestService
    {
        Task<bool> Run(string[] args);
    }
}