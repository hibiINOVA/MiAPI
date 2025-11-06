
using System.Threading.Tasks;
namespace MiApi.Services 
{
    public interface ILlamadaService
    {
        Task<string> RealizarLlamadaAsync(string nombre, int delayMilliseconds);
    }
}