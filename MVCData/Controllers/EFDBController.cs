
using MVCData.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCData.Controllers
{
    public class EFDBController : Controller
    {
        public readonly DatabaseMVCEFDbContext EFDBContext; 
        
    public  EFDBController(DatabaseMVCEFDbContext context)
    {
            EFDBContext = context;
    }

    }

}

