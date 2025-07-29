using HospitalPatientTreatmentRecordCoreMvcCRUD.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HospitalPatientTreatmentRecordCoreMvcCRUD.Data
{
    public class AppDbContext: IdentityDbContext<Users>
    {
        public AppDbContext(DbContextOptions<AppDbContext>options):base(options)
        {
        }
        
        public virtual DbSet<Patient>Patients { get; set; }
        public virtual DbSet<TreatmentDetail> TreatmentDetails { get; set; }
        public virtual DbSet<TreatmentType> TreatmentTypes { get; set; }

       

    }
}
