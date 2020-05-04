using Microsoft.EntityFrameworkCore;

namespace Backend.Entities
{
    public partial class FireContext : DbContext
    {
        public FireContext()
        {
        }

        public FireContext(DbContextOptions<FireContext> options)
            : base(options)
        {

        }

        public virtual DbSet<Classification> Classification { get; set; }
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<Crew> Crew { get; set; }
        public virtual DbSet<Engine> Engine { get; set; }


        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Clients>(entity =>
        //    {
        //        entity.Property(e => e.ClientPasswordHash).IsFixedLength();

        //        entity.Property(e => e.ClientPasswordSalt).IsFixedLength();

        //        entity.HasOne(d => d.Role)
        //            .WithMany(p => p.Clients)
        //            .HasForeignKey(d => d.RoleId)
        //            .HasConstraintName("fk_client_role");
        //    });

        //    modelBuilder.Entity<Engines>(entity =>
        //    {
        //        entity.HasOne(d => d.Classification)
        //            .WithMany(p => p.Engines)
        //            .HasForeignKey(d => d.ClassificationId)
        //            .OnDelete(DeleteBehavior.ClientSetNull)
        //            .HasConstraintName("fk_engine_classification");

        //        entity.HasOne(d => d.Crew)
        //            .WithMany(p => p.Engines)
        //            .HasForeignKey(d => d.CrewId)
        //            .HasConstraintName("fk_engine_crew");
        //    });

        //    modelBuilder.Entity<Position>(entity =>
        //    {
        //        entity.HasOne(d => d.Clients)
        //            .WithMany(p => p.Position)
        //            .HasForeignKey(d => d.ClientId)
        //            .OnDelete(DeleteBehavior.ClientSetNull)
        //            .HasConstraintName("fk_position_client");
        //    });

        //    OnModelCreatingPartial(modelBuilder);
        //}

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
