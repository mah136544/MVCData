﻿using MVCData.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCData.Controllers;

namespace MVCData.Models
{
    public class LanguagesViewModel : DBModel
    {
        public LanguagesViewModel(Controller aController, DatabaseMVCEFDbContext dbContext) : base(aController, dbContext)
        {

        }

      

        public DBLanguage AddLanguage(AddLanguageInputModel languageData)
        {
            DBLanguage language = null;

            if (aController.ModelState.IsValid)
            {
                language = new DBLanguage(languageData);

                AddLanguageToDB(language);
            }

            return language;
        }
        public int AddLanguageToDB(DBLanguage aLanguage)
        {
            aLanguage.Id = 0;                                 // Set ID to 0 to allow addition to database

            EFDBContext.Languages.Add(aLanguage);
            EFDBContext.SaveChanges();
            return EFDBContext.Languages.Count();
        }

        public bool RemoveLanguageFromDB(int ID)
        {
            bool success = false;

            DBLanguage language = EFDBContext.Languages.Find(ID);
            if (language != null)
            {
                Languages.Remove(language);
                EFDBContext.Languages.Remove(language);
                EFDBContext.SaveChanges();
                success = true;
            }
            return success;
        }
    }
}


