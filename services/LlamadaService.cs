namespace MiApi;

public class LlamadaService: ILlamada
{
    public async Task<string> Llamada(string nombre, int delay)
    {
        await Task.Delay(delay);
        return $"Llamada realizada a {nombre} después de {delay} ms.";
    }
}
