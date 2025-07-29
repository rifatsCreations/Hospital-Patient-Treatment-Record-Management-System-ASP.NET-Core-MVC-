using Microsoft.AspNetCore.Identity;

namespace HospitalPatientTreatmentRecordCoreMvcCRUD.Models
{
    public class Users:IdentityUser
    {
        public string FullName { get; set; }
    }
}
