using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using myDiary.Data;
using myDiary.Models;

namespace myDiary.Controllers
{
    public class DiaryEntriesController : Controller
    {

        private readonly ApplicationDbContext _db;

        public DiaryEntriesController(ApplicationDbContext db) {
            _db = db;
        }

        public IActionResult Index()
        {

            List<DiaryEntry> entries = _db.DiaryEntries.ToList();
            return View(entries);
        }


        public IActionResult Create() {
            return View();
        }

        [HttpPost]
        public IActionResult Create(DiaryEntry obj) {


            //Server side validation
            if (obj != null && obj.Title.Length < 3) {
                ModelState.AddModelError("Title", "Title too short");
            }

            if (ModelState.IsValid) {
                _db.DiaryEntries.Add(obj); //Ads new diary entry to the database
                _db.SaveChanges(); //Save changes made to the database
                return RedirectToAction("Index");
            }

            return View(obj);



        }

    }
}
