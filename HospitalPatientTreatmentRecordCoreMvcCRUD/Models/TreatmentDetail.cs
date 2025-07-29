namespace HospitalPatientTreatmentRecordCoreMvcCRUD.Models
{
    public class TreatmentDetail
    {
        public int TreatmentDetailId { get; set; }
        public string TreatmentName { get; set; }= null!;
        public decimal Cost { get; set; }
        public int PatientId { get; set; }
        public virtual Patient Patient { get; set; }= null!;
    }
}