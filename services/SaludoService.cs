namespace MiApi;

public class SaludoService : ISaludoService
{
    public string Saludar(string nombre)
    {
        return $"Hola {nombre}, Saludos desde el servicio inyectado.";
    }
}

public class SaludoFormal: ISaludoService
{
    public string Saludar(string nombre)
    {
        return $"Buen dia, Sr./Sra. {nombre}.";
    }
}

public class SaludoInformal: ISaludoService
{
    public string Saludar(string nombre)
    {
        return $"!Que onda, {nombre}!";
    }
}