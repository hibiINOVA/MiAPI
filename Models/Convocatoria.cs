using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiApi;

public class Convocatoria
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ConvocatoriaID { get; set; }
    
    public string Nombre { get; set; }
    
    [Column(TypeName = "decimal(3,2)")]
    public decimal Costo { get; set; }

    // ⬇️ AGREGA ESTA LÍNEA ⬇️
    public ICollection<InscripcionM> Inscripciones { get; set; }
}