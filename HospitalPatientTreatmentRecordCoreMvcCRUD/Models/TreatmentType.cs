using System.ComponentModel.DataAnnotations;

namespace HospitalPatientTreatmentRecordCoreMvcCRUD.Models
{
    public class TreatmentType
    {
        public int TreatmentTypeId { get; set; }
        [Display(Name = "Treatment Type ")]
        public string TreatmentTypeName { get; set; } = null!;
        public virtual ICollection<Patient>Patients { get; set; } = new List<Patient>();
    }
}
