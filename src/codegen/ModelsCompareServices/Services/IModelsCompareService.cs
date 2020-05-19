using System.Threading.Tasks;

namespace ModelsCompareServices.Services
{
    public interface IModelsCompareService
    {
        Task<bool> Run(string[] args);
    }
}