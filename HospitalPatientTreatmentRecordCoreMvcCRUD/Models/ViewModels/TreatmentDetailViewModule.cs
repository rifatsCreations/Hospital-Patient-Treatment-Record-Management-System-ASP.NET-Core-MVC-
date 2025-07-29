namespace HospitalPatientTreatmentRecordCoreMvcCRUD.Models.ViewModels
{
    public class TreatmentDetailViewModule
    {
        public int TreatmentDetailId { get; set; }
        public string TreatmentName { get; set; } = null!;
        public decimal Cost { get; set; }
    }
}
