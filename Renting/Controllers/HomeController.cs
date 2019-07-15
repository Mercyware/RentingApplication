using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using log4net;
using Renting.Domain.Services;
using Renting.Interface;
using Renting.Repository.Models;

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

            return View("Index", equipments);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(EquipmentModel equipmentModel)
        {
            if (equipmentModel == null)
            {
                throw new ArgumentNullException(nameof(equipmentModel));
            }

            if (!ModelState.IsValid)
            {
                var equipments = this._equipmentService.GetEquipmentViewModel();
                return View("Index", equipments);
            }

            this._equipmentService.AddToCart(equipmentModel);
            var message = "New Equipment Added to Cart.";
            return RedirectToAction("Cart", "Equipment", new {message});
        }
    }
}