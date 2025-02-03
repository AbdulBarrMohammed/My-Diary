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

        [HttpGet]
        public IActionResult Edit(int? id) {

            if (id == null || id == 0) {
                return NotFound();
            }
            DiaryEntry? diaryEntry = _db.DiaryEntries.Find(id);
            if (diaryEntry == null) {
                return NotFound();
            }

            return View(diaryEntry);
        }


        [HttpPost]
        public IActionResult Edit(DiaryEntry obj) {


            //Server side validation
            if (obj != null && obj.Title.Length < 3) {
                ModelState.AddModelError("Title", "Title too short");
            }

            if (ModelState.IsValid) {
                _db.DiaryEntries.Update(obj); //Update diary entry to the database
                _db.SaveChanges(); //Save changes made to the database
                return RedirectToAction("Index");
            }

            return View(obj);



        }


        [HttpGet]
        public IActionResult Delete(int? id) {

            if (id == null || id == 0) {
                return NotFound();
            }
            DiaryEntry? diaryEntry = _db.DiaryEntries.Find(id);
            if (diaryEntry == null) {
                return NotFound();
            }

            return View(diaryEntry);
        }



        [HttpPost]
        public IActionResult Delete(DiaryEntry obj) {

            _db.DiaryEntries.Remove(obj); //Remove diary entry to the database
            _db.SaveChanges(); //Save changes made to the database
            return RedirectToAction("Index");

        }


    }

}
