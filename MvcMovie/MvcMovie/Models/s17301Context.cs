using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MvcMovie.Models
{
    public partial class s17301Context : DbContext
    {
        public s17301Context()
        {
        }

        public s17301Context(DbContextOptions<s17301Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Doctors> Doctors { get; set; }
        public virtual DbSet<Medicaments> Medicaments { get; set; }
        public virtual DbSet<Patients> Patients { get; set; }
        public virtual DbSet<Prescription> Prescription { get; set; }
        public virtual DbSet<PrescriptionMedicaments> PrescriptionMedicaments { get; set; }
     

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=db-mssql;Initial Catalog=s17301;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doctors>(entity =>
            {
                entity.HasKey(e => e.IdDoctor);

                entity.Property(e => e.FirstName).IsRequired();

                entity.Property(e => e.LastName).IsRequired();
            });


            modelBuilder.Entity<Medicaments>(entity =>
            {
                entity.HasKey(e => e.IdMedicament);

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.Name).IsRequired();

                entity.Property(e => e.Type).IsRequired();
            });

            modelBuilder.Entity<Patients>(entity =>
            {
                entity.HasKey(e => e.IdPatient);

                entity.Property(e => e.FirstName).IsRequired();

                entity.Property(e => e.LastName).IsRequired();
            });

            modelBuilder.Entity<Prescription>(entity =>
            {
                entity.HasKey(e => e.IdPrescription);

                entity.HasIndex(e => e.IdDoctor);

                entity.HasIndex(e => e.IdPatient);

                entity.HasOne(d => d.IdDoctorNavigation)
                    .WithMany(p => p.Prescription)
                    .HasForeignKey(d => d.IdDoctor);

                entity.HasOne(d => d.IdPatientNavigation)
                    .WithMany(p => p.Prescription)
                    .HasForeignKey(d => d.IdPatient);
            });

            modelBuilder.Entity<PrescriptionMedicaments>(entity =>
            {
                entity.HasKey(e => new { e.IdMedicament, e.IdPrescription });

                entity.HasIndex(e => e.IdPrescription);

                entity.Property(e => e.Details).IsRequired();

                entity.HasOne(d => d.IdMedicamentNavigation)
                    .WithMany(p => p.PrescriptionMedicaments)
                    .HasForeignKey(d => d.IdMedicament);

                entity.HasOne(d => d.IdPrescriptionNavigation)
                    .WithMany(p => p.PrescriptionMedicaments)
                    .HasForeignKey(d => d.IdPrescription);
            });

        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
