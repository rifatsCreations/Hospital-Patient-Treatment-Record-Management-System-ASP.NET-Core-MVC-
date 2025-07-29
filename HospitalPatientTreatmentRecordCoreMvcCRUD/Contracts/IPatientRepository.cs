using HospitalPatientTreatmentRecordCoreMvcCRUD.Models;

namespace HospitalPatientTreatmentRecordCoreMvcCRUD.Contracts
{
    public interface IPatientRepository
    {
        IEnumerable<Patient> GetAllPatients();
        Patient GetPatient(int id);
        Patient UpdatePatient(Patient patient);
        Patient AddPatient(Patient patient);
        Patient DeletePatient(int id);

    }
}
