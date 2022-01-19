using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreClienteApiHospitales.Controllers
{
    public class HospitalesController : Controller
    {
        public IActionResult HospitalesCliente()
        {
            return View();
        }
    }
}
