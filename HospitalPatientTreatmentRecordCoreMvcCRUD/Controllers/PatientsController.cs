using HospitalPatientTreatmentRecordCoreMvcCRUD.Data;
using HospitalPatientTreatmentRecordCoreMvcCRUD.Models;
using HospitalPatientTreatmentRecordCoreMvcCRUD.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HospitalPatientTreatmentRecordCoreMvcCRUD.Controllers
{
    [Authorize]
    public class PatientsController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IWebHostEnvironment _env;

        public PatientsController(AppDbContext db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
        }

        public IActionResult Index()
        {
            var patients = _db.Patients.Include(tt => tt.TreatmentType).Include(td => td.TreatmentDetails).ToList();
            return View(patients);
        }
       
        public IActionResult Create()
        {
            PatientViewModel patient = new PatientViewModel();
            patient.TreatmentTypes = _db.TreatmentTypes.ToList();
            return View(patient);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>Create(PatientViewModel pv)
        {
            Patient patient = new Patient();
            string imageFileName = null;
            imageFileName = await GetImageFileName(pv.ProfileFile);

            patient.ImageUrl = imageFileName;
            patient.PatientName = pv.PatientName;
            patient.IsAdmitted = pv.IsAdmitted;
            patient.ContactNumber = pv.ContactNumber;
            patient.AdmitDate = pv.AdmitDate;
            patient.Address = pv.Address;
            patient.TreatmentTypeId=pv.TreatmentTypeId;
            patient.TreatmentDetails = pv.TreatmentDetails;
            _db.Patients.Add(patient);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");


        }

        private async Task<string?> GetImageFileName(IFormFile profileFile)
        {
            string uniqueFileName = null;
            if (profileFile != null)
            {
                uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(profileFile.FileName); ;
                var uploadFolder = Path.Combine(_env.WebRootPath, "images");
                var filePath = Path.Combine(uploadFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await profileFile.CopyToAsync(fileStream);
                }
               
            }
            return uniqueFileName;
        }

        public async Task<ActionResult> Delete(int id)
        {
            var patients = await _db.Patients.Where(p => p.PatientId == id).FirstOrDefaultAsync();

            if (patients == null)
            {
                return NotFound();
            }
            if (!string.IsNullOrEmpty(patients.ImageUrl))
            {
                string imagePath = Path.Combine(_env.WebRootPath, "images", patients.ImageUrl);
                if (System.IO.File.Exists(imagePath))
                {
                    System.IO.File.Delete(imagePath);
                }

            }
            _db.Patients.Remove(patients);
            await _db.SaveChangesAsync();


            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var patients = _db.Patients.Include(tt => tt.TreatmentType).Include(td => td.TreatmentDetails).FirstOrDefault(p => p.PatientId == id);
            if (patients == null)
            {
                return NotFound();
            }

            var patientViewModel = new PatientViewModel
            {
                PatientId = patients.PatientId,
                PatientName = patients.PatientName,
                IsAdmitted = patients.IsAdmitted,
                ContactNumber = patients.ContactNumber,
                AdmitDate = patients.AdmitDate,
                Address = patients.Address,
                ImageUrl = patients.ImageUrl,
                TreatmentDetails = patients.TreatmentDetails,
                TreatmentTypeId = patients.TreatmentTypeId,
                TreatmentTypes = _db.TreatmentTypes.ToList()
            };
            return View(patientViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>Edit(PatientViewModel patientViewModel,string OldImageUrl)
        {
            var patient = await _db.Patients.Include(tt => tt.TreatmentType).Include(td => td.TreatmentDetails).FirstOrDefaultAsync(p => p.PatientId == patientViewModel.PatientId);

            if(patient == null) 
            { 
                return NotFound();
            }

            if (patientViewModel.ProfileFile != null)
            {
                if (!string.IsNullOrEmpty(patient.ImageUrl))
                {
                    var oldImagePath = Path.Combine(_env.WebRootPath, "images", patient.ImageUrl);
                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }
                   
                }
                string imageFileName = await GetImageFileName(patientViewModel.ProfileFile);
                patient.ImageUrl = imageFileName;
            }
            else
            {
                patient.ImageUrl = OldImageUrl;
            }

            patient.PatientName = patientViewModel.PatientName;
            patient.IsAdmitted = patientViewModel.IsAdmitted;
            patient.ContactNumber = patientViewModel.ContactNumber;
            patient.AdmitDate = patientViewModel.AdmitDate;
            patient.Address= patientViewModel.Address;
            patient.TreatmentTypeId = patientViewModel.TreatmentTypeId;


            var existingDetails = patient.TreatmentDetails.ToList();

            foreach (var exDetails in existingDetails)
            {
                _db.TreatmentDetails.Remove(exDetails);
            }

            foreach (var item in patientViewModel.TreatmentDetails)
            {
                _db.TreatmentDetails.Add(new TreatmentDetail
                {
                    TreatmentName = item.TreatmentName,
                    Cost = item.Cost,
                    PatientId = patient.PatientId
                });
            }

            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
