 ﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HospitalManagementSystem.Models;

namespace HospitalManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        private HospitalContext db = new HospitalContext();

        public ActionResult Index()
        {
            // --- GCN FEATURE 1: Calculate Average Patient Stay Duration ---
            var dischargedAdmissions = db.Admissions
                .Where(a => a.DischargeDate.HasValue)
                .ToList();

            double avgStayDays = 0;
            if (dischargedAdmissions.Count > 0)
            {
                avgStayDays = dischargedAdmissions.Average(a => (a.DischargeDate.Value - a.AdmissionDate).TotalDays);
            }

            int totalBeds = db.Beds.Count();
            int occupiedBeds = db.Beds.Count(b => b.IsOccupied);
            double utilizationRate = totalBeds > 0 ? ((double)occupiedBeds / totalBeds) * 100 : 0;

            ViewBag.AvgStayDays = Math.Round(avgStayDays, 1);
            ViewBag.BedUtilization = Math.Round(utilizationRate, 1);
            ViewBag.TotalPatients = db.Patients.Count();
            ViewBag.TotalDoctors = db.Doctors.Count();

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Hospital Management System - Project Specifications Page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Medical Administration Contact Desk.";
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
