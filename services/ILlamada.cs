namespace MiApi;

public interface ILlamada
{
    Task<string> Llamada(string nombre, int delay);
}
