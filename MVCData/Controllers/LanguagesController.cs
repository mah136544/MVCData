using MVCData.Data;
using MVCData.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCData.Controllers
{
    [Authorize(Roles = "Admin")]
    public class LanguagesController : EFDBController
    {
        public LanguagesController(DatabaseMVCEFDbContext context) : base(context)
        {

        }

        public IActionResult Index()
        {
            LanguagesViewModel languageViewModel = new LanguagesViewModel(this, EFDBContext);

            return View(languageViewModel);
        }

        [HttpPost]
        public IActionResult AddLanguage(AddLanguageInputModel personData)
        {
            LanguagesViewModel languageViewModel = new LanguagesViewModel(this, EFDBContext);

            languageViewModel.AddLanguage(personData);

            return RedirectToAction("Index");
        }

        public IActionResult DeleteLanguage(int id)
        {
            LanguagesViewModel languageViewModel = new LanguagesViewModel(this, EFDBContext);
            languageViewModel.RemoveLanguageFromDB(id);

            return RedirectToAction("Index");
        }

    }
}

