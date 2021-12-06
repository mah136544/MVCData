using Microsoft.AspNetCore.Mvc;
using MVCData.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCData.Controllers
{
    public class EFDBController : Controller
    {
        public readonly MVCEFDbContext EFDBContext; 
        public EFDBController(MVCEFDbContext context)
        {
            EFDBContext = context;
        }
     }
}
