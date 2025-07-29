using System.ComponentModel.DataAnnotations;
using HospitalPatientTreatmentRecordCoreMvcCRUD.Models;

namespace HospitalPatientTreatmentRecordCoreMvcCRUD.Models.ViewModels
{
    public class PatientViewModel
    {
        public int PatientId { get; set; }

        public string PatientName { get; set; } = null!;

        public bool IsAdmitted { get; set; }

        public string ContactNumber { get; set; } = null!;

        [Required, Display(Name = "Admit Date"), DataType(DataType.Date),
        DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime AdmitDate { get; set; }

        public string Address { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;

        public IFormFile ProfileFile { get; set; } = null!;


        public int TreatmentTypeId { get; set; }

        public virtual TreatmentType? TreatmentType { get; set; } = null!;

        public string TreatmentTypeName { get; set; } = null!;

        public virtual ICollection<TreatmentDetail> TreatmentDetails { get; set; } = new List<TreatmentDetail>();

        public IList<Patient> patient { get; set; } = new List<Patient>();

        public List<TreatmentType>? TreatmentTypes { get; set; } = new List<TreatmentType>();
    }
}
