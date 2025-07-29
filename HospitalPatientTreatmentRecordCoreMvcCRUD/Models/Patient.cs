using System.ComponentModel.DataAnnotations;

namespace HospitalPatientTreatmentRecordCoreMvcCRUD.Models
{
    public class Patient
    {
        public int PatientId { get; set; }
        public string PatientName { get; set; }=null!;
       
        public bool IsAdmitted { get; set; }
        public string ContactNumber { get; set; } = null!;
        [Required, Display(Name = "Admit Date"), DataType(DataType.Date),
       DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime AdmitDate { get; set; }
        public string Address { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;


        public int TreatmentTypeId { get; set; }

        public virtual TreatmentType TreatmentType { get; set; } = null!;
        public virtual ICollection<TreatmentDetail> TreatmentDetails { get; set; } = new List<TreatmentDetail>();
    }
}
