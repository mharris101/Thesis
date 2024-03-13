#nullable disable
using Microsoft.EntityFrameworkCore;

namespace ThesisAPI.Models
{
    public partial class ThesisContext : DbContext
    {
        public ThesisContext()
        {
        }

        public ThesisContext(DbContextOptions<ThesisContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ComputerEntity> Computers { get; set; }
        public virtual DbSet<ComputerUsbEntity> ComputerUsbs { get; set; }
        public virtual DbSet<DiskEntity> Disks { get; set; }
        public virtual DbSet<DiskTypeEntity> DiskTypes { get; set; }
        public virtual DbSet<MemoryEntity> Memories { get; set; }
        public virtual DbSet<PowerSupplyEntity> PowerSupplies { get; set; }
        public virtual DbSet<ProcessorEntity> Processors { get; set; }
        public virtual DbSet<UsbTypeEntity> UsbTypes { get; set; }
        public virtual DbSet<VideoCardEntity> VideoCards { get; set; }
        public virtual DbSet<WeightUnitEntity> WeightUnits { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ComputerEntity>(entity =>
            {
                entity.ToTable("Computer");

                entity.HasOne(d => d.Disk)
                    .WithMany(p => p.Computers)
                    .HasForeignKey(d => d.DiskId)
                    .HasConstraintName("FK_Disk");

                entity.HasOne(d => d.PowerSupply)
                    .WithMany(p => p.Computers)
                    .HasForeignKey(d => d.PowerSupplyId)
                    .HasConstraintName("FK_PowerSupply");

                entity.HasOne(d => d.Processor)
                    .WithMany(p => p.Computers)
                    .HasForeignKey(d => d.ProcessorId)
                    .HasConstraintName("FK_Processor");

                entity.HasOne(d => d.VideoCard)
                    .WithMany(p => p.Computers)
                    .HasForeignKey(d => d.VideoCardId)
                    .HasConstraintName("FK_VideoCard");

                entity.HasOne(d => d.WeightUnit)
                    .WithMany(p => p.Computers)
                    .HasForeignKey(d => d.WeightUnitId)
                    .HasConstraintName("FK_WeightUnit");
            });

            modelBuilder.Entity<ComputerUsbEntity>(entity =>
            {
                entity.ToTable("ComputerUsb");

                entity.HasOne(d => d.Computer)
                    .WithMany(p => p.ComputerUsbs)
                    .HasForeignKey(d => d.ComputerId)
                    .HasConstraintName("FK_Computer");

                entity.HasOne(d => d.UsbType)
                    .WithMany(p => p.ComputerUsbs)
                    .HasForeignKey(d => d.UsbTypeId)
                    .HasConstraintName("FK_UsbType");
            });

            modelBuilder.Entity<DiskEntity>(entity =>
            {
                entity.ToTable("Disk");

                entity.Property(e => e.DiskSize)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.DiskType)
                    .WithMany(p => p.Disks)
                    .HasForeignKey(d => d.DiskTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DiskType");
            });

            modelBuilder.Entity<DiskTypeEntity>(entity =>
            {
                entity.ToTable("DiskType");

                entity.Property(e => e.DiskTypeDesc)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MemoryEntity>(entity =>
            {
                entity.ToTable("Memory");

                entity.Property(e => e.MemoryDesc)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PowerSupplyEntity>(entity =>
            {
                entity.ToTable("PowerSupply");

                entity.Property(e => e.PowerSupplyDesc)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ProcessorEntity>(entity =>
            {
                entity.ToTable("Processor");

                entity.Property(e => e.ProcessorDesc)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UsbTypeEntity>(entity =>
            {
                entity.ToTable("UsbType");

                entity.Property(e => e.UsbTypeDesc)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VideoCardEntity>(entity =>
            {
                entity.ToTable("VideoCard");

                entity.Property(e => e.VideoCardDesc)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<WeightUnitEntity>(entity =>
            {
                entity.ToTable("WeightUnit");

                entity.Property(e => e.WeightUnitDesc)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}