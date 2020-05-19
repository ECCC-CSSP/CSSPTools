using System.Threading.Tasks;

namespace ServicesRepopulateTestDBServices.Services
{
    public interface IServicesRepopulateTestDBService
    {
        Task<bool> Run(string[] args);
    }
}