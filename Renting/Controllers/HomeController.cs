using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Renting.Interface;

namespace Renting.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEquipmentService _equipmentService;

        public HomeController(IEquipmentService equipmentService)
        {
            this._equipmentService = equipmentService;
        }

        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Index()
        {
            var equipments = this._equipmentService.GetEquipmentViewModel();

            return View("Index",equipments);
        }

       
       
    }
}