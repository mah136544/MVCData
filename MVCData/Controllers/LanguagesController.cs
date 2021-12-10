using MVCData.Data;
using MVCData.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCData.Controllers
{
    public class LanguagesController : EFDBController
    {
        public LanguagesController(DatabaseMVCEFDbContext context) : base(context)
        {

        }

        public IActionResult Index()
        {
             LanguagesViewModel languageViewModel = new LanguagesViewModel(this, EFDBContext );

            return View(languageViewModel);
           
        }

        [HttpPost]
        public IActionResult AddLanguage(CreateLanguageViewModel personData)
        {
            LanguagesViewModel LanguageViewModel = new LanguagesViewModel(this, EFDBContext);

            LanguageViewModel.AddLanguage(personData);

            return RedirectToAction("Index");
        }

        public IActionResult DeleteLanguage(int id)
        {
            LanguagesViewModel LanguageViewModel = new LanguagesViewModel(this, EFDBContext);
            LanguageViewModel.RemoveLanguageFromDB(id);

            return RedirectToAction("Index");
        }

    }

}


