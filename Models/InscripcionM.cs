using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiApi;

public class InscripcionM
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    public int IdConvocatoria { get; set; }
    
    public string Nombre { get; set; }
    
    public string Correo { get; set; }

    // Propiedad de navegación
    [ForeignKey("IdConvocatoria")]
    public Convocatoria Convocatoria { get; set; }
}