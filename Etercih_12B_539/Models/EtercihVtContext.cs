using Microsoft.EntityFrameworkCore;

namespace Etercih_12B_539.Models;

public partial class EtercihVtContext : DbContext
{
    public EtercihVtContext()
    {
    }

    public EtercihVtContext(DbContextOptions<EtercihVtContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Etercih> Etercihs { get; set; }

    public virtual DbSet<TercihSecenekleri> TercihSecenekleris { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=ETercihVT;Persist Security Info=True;User ID=öğrenci;Password=123;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Etercih>(entity =>
        {
            entity.ToTable("Etercih");

            entity.Property(e => e.EtercihId).HasColumnName("ETercihID");
            entity.Property(e => e.KullaniciId).HasColumnName("KullaniciID");
            entity.Property(e => e.SecenekId).HasColumnName("SecenekID");
            entity.Property(e => e.Zaman).HasColumnType("datetime");
        });

        modelBuilder.Entity<TercihSecenekleri>(entity =>
        {
            entity.HasKey(e => e.SecenekId);

            entity.ToTable("TercihSecenekleri");

            entity.Property(e => e.SecenekId).HasColumnName("SecenekID");
            entity.Property(e => e.Secenek).HasMaxLength(250);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
