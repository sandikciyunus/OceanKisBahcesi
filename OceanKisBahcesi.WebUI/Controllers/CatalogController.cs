using Microsoft.AspNetCore.Mvc;
using OceanKisBahcesi.Business.Abstract;
using OceanKisBahcesi.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OceanKisBahcesi.WebUI.Controllers
{
    public class CatalogController : Controller
    {
        private ICatalogService _catalogService;
        public CatalogController(ICatalogService catalogService)
        {
            _catalogService = catalogService;
        }
        [Route("/e-katalog")]
        public IActionResult Index()
        {
            return View(new CatalogListViewModel
            {
                Catalogs = _catalogService.GetAll()
            });
        }
    }
}
