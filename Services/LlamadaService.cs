
using System.Threading.Tasks;

namespace MiApi.Services 
{
    public class LlamadaService : ILlamadaService
    {
        
        public async Task<string> RealizarLlamadaAsync(string nombre, int delayMilliseconds)
        {
            await Task.Delay(delayMilliseconds);

            return $"Llamada para '{nombre}' completada después de {delayMilliseconds} ms.";
        }
    }
}