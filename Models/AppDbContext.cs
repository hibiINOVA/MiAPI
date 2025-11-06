using Microsoft.EntityFrameworkCore;

namespace MiApi;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }
    
    public DbSet<Convocatoria> Convocatorias { get; set; }
    public DbSet<InscripcionM> Inscripciones { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configuración de la relación entre Convocatoria e Inscripcion
        modelBuilder.Entity<InscripcionM>()
            .HasOne(i => i.Convocatoria)
            .WithMany(c => c.Inscripciones) // ✅ Es el nombre de la propiedad, NO el tipo
            .HasForeignKey(i => i.IdConvocatoria)
            .OnDelete(DeleteBehavior.Cascade);
    }
}