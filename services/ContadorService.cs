namespace MiApi;

public interface IContadorService
{
    int ObtenerValor();
}

public class ContadorService : IContadorService
{
    private int _contador;

    public ContadorService()
    {
        _contador = new Random().Next(1, 999);
    }

    public int ObtenerValor()
    {
        return _contador;
    }
}
