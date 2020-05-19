using System.Threading.Tasks;

namespace ModelsCompareDBFieldsAndCSSPModelsDLLPropServices.Services
{
    public interface IModelsCompareDBFieldsAndCSSPModelsDLLPropService
    {
        Task<bool> Run(string[] args);
    }
}