namespace MiApi;

// Clase principal - Saludo normal
public class SaludoService : ISaludoService
{
    public string Saludar(string nombre)
    {
        return $"Hola, {nombre}! Saludo desde el servicio inyectado";
    }
}

// Saludo formal
public class SaludoFormal : ISaludoService
{
    public string Saludar(string nombre)
    {
        return $"Buenos días, Sr./Sra. {nombre}. Es un placer saludarle.";
    }
}

// Saludo informal
public class SaludoInformal : ISaludoService
{
    public string Saludar(string nombre)
    {
        return $"¡Qué onda {nombre}! ¿Cómo estás?";
    }
}
