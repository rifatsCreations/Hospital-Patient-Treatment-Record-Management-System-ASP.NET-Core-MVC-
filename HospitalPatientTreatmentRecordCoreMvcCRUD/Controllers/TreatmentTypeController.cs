using HospitalPatientTreatmentRecordCoreMvcCRUD.Data;
using HospitalPatientTreatmentRecordCoreMvcCRUD.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HospitalPatientTreatmentRecordCoreMvcCRUD.Controllers
{
    [Authorize]
    public class TreatmentTypeController : Controller
    {
        private readonly AppDbContext _db;

        public TreatmentTypeController(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _db.TreatmentTypes.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TreatmentType treatmentType)
        {
            if (ModelState.IsValid)
            {
                _db.Add(treatmentType);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(treatmentType);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var treatmentType = await _db.TreatmentTypes.FindAsync(id);
            if (treatmentType == null) return NotFound();

            return View(treatmentType);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TreatmentType treatmentType)
        {
            if (id != treatmentType.TreatmentTypeId) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _db.Update(treatmentType);
                    await _db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_db.TreatmentTypes.Any(e => e.TreatmentTypeId == id))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(treatmentType);
        }


        [HttpGet]
        public ActionResult Delete(int id)
        {
            var treatmentType = _db.TreatmentTypes.Find(id);
            if (treatmentType != null)
            {
                _db.TreatmentTypes.Remove(treatmentType);
                _db.SaveChanges();

            }
            return RedirectToAction("Index");
        }
    }
}
