using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cw11.DbModels{
    public class HospitalDbContext : DbContext{
        public DbSet<Doctor> Doctor { get; set; }
        public DbSet<Medicament> Medicament { get; set; }
        public DbSet<Patient> Patient { get; set; }
        public DbSet<Prescription> Prescription { get; set; }

        public DbSet<Prescription_Medicament> Prescription_Medicament { get; set; }

        public HospitalDbContext() { }

        public HospitalDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions){ 
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Prescription_Medicament>().HasKey(k=> new { k.IdMedicament,k.IdPrescription});

            List<Doctor> listDoctors = new List<Doctor>();
            listDoctors.Add(new Doctor { IdDoctor=1,FirstName="Jan",LastName="Kowal",Email="jank@g.com"});
            listDoctors.Add(new Doctor { IdDoctor = 2, FirstName = "Ban", LastName = "Wowal", Email = "bank@g.com"});
            listDoctors.Add(new Doctor { IdDoctor = 3, FirstName = "Kan", LastName = "Bowal", Email = "kank@g.com" });
            modelBuilder.Entity<Doctor>().HasData(listDoctors);

            List<Medicament> listMedicaments = new List<Medicament>();
            listMedicaments.Add(new Medicament { IdMedicament= 1,Name = "med1",Description = "des1",Type = "t1"});
            listMedicaments.Add(new Medicament { IdMedicament = 2, Name = "med2", Description = "des2", Type = "t2" });
            listMedicaments.Add(new Medicament { IdMedicament = 3, Name = "med3", Description = "des3", Type = "t3" });
            modelBuilder.Entity<Medicament>().HasData(listMedicaments);

            List<Patient> listPatients = new List<Patient>();
            listPatients.Add(new Patient { IdPatient = 1 ,FirstName = "Adam",LastName = "Nowak",Birthdate = Convert.ToDateTime("2020-08-01")});
            listPatients.Add(new Patient { IdPatient = 2, FirstName = "Wdam", LastName = "Wowak", Birthdate = Convert.ToDateTime("2020-09-02")});
            listPatients.Add(new Patient { IdPatient = 3, FirstName = "Idam", LastName = "Iowak", Birthdate = Convert.ToDateTime("2020-12-10")});
            modelBuilder.Entity<Patient>().HasData(listPatients);

            List<Prescription> listPrescriptions = new List<Prescription>();
            listPrescriptions.Add(new Prescription { IdPrescription = 1, Date = Convert.ToDateTime("2020-08-01"),DueDate = Convert.ToDateTime("2050-08-01"), IdPatient=0,IdDoctor=0});
            listPrescriptions.Add(new Prescription { IdPrescription = 2, Date = Convert.ToDateTime("2018-08-01"), DueDate = Convert.ToDateTime("2020-08-01"), IdPatient = 1, IdDoctor = 1});
            listPrescriptions.Add(new Prescription { IdPrescription = 3, Date = Convert.ToDateTime("2010-08-01"), DueDate = Convert.ToDateTime("2021-09-01"), IdPatient = 2, IdDoctor = 2 });
            modelBuilder.Entity<Prescription>().HasData(listPrescriptions);

            List<Prescription_Medicament> listPrescriptionMedicament = new List<Prescription_Medicament>();
            listPrescriptionMedicament.Add(new Prescription_Medicament { IdMedicament = 1,IdPrescription=1,Dose = 20,Details="d1"});
            listPrescriptionMedicament.Add(new Prescription_Medicament { IdMedicament = 2, IdPrescription = 2, Dose = 10, Details = "d2" });
            listPrescriptionMedicament.Add(new Prescription_Medicament { IdMedicament = 3, IdPrescription = 3, Dose = 5, Details = "d3" });
            modelBuilder.Entity<Prescription_Medicament>().HasData(listPrescriptionMedicament);
        }
    }
}
