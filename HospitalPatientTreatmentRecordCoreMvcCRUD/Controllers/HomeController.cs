﻿using Microsoft.AspNetCore.Mvc;

namespace HospitalPatientTreatmentRecordCoreMvcCRUD.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}
