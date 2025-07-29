using HospitalPatientTreatmentRecordCoreMvcCRUD.Contracts;
using HospitalPatientTreatmentRecordCoreMvcCRUD.Data;
using HospitalPatientTreatmentRecordCoreMvcCRUD.Models;

namespace HospitalPatientTreatmentRecordCoreMvcCRUD.Services
{
    public class PatientRepository : IPatientRepository
    {
        private readonly AppDbContext _db;

        public PatientRepository(AppDbContext db)
        {
            _db = db;
        }

        public Patient AddPatient(Patient patient)
        {
            throw new NotImplementedException();
        }

        public Patient DeletePatient(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Patient> GetAllPatients()
        {
            throw new NotImplementedException();
        }

        public Patient GetPatient(int id)
        {
            throw new NotImplementedException();
        }

        public Patient UpdatePatient(Patient patient)
        {
            throw new NotImplementedException();
        }
    }
}
