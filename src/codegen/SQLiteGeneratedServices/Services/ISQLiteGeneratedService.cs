using System.Threading.Tasks;

namespace SQLiteGeneratedServices.Services
{
    public interface ISQLiteGeneratedService
    {
        Task<bool> Run(string[] args);
    }
}