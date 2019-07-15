using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using log4net;
using Renting.Domain.Models;
using Renting.Interface;
using Renting.Interface.Factory;

namespace Renting.Domain.Services
{
    public class EquipmentService : IEquipmentService
    {
        private readonly IEquipmentRepository _equipmentRepository;
        private readonly IEquipmentFactory _equipmentFactory;
        private readonly ILog log = LogManager.GetLogger(typeof(EquipmentService));

        public EquipmentService(IEquipmentRepository equipmentRepository, IEquipmentFactory equipmentFactory)
        {
            this._equipmentRepository = equipmentRepository;
            this._equipmentFactory = equipmentFactory;
        }

        /// <summary>
        /// Gets the equipment view model.
        /// </summary>
        /// <returns></returns>
        public IEquipmentViewModel GetEquipmentViewModel()
        {


            try
            {
                var equipments = this._equipmentRepository.GetMachinesList();
                var equipmentListView = this._equipmentFactory.CreateEquipmentView(equipments);
                return equipmentListView;
            }
            catch (Exception exception)
            {
                log.Error($"An error has occured. Method Name : GetEquipmentViewModel - EquipmentService {exception}");
                throw new ArgumentException(exception.ToString());
            }
        }

        /// <summary>
        /// Searches the equipment.
        /// </summary>
        /// <param name="equipmentDescription">The equipment description.</param>
        /// <returns></returns>
        public IEquipmentViewModel SearchEquipment(string equipmentDescription)
        {
            try
            {
                var equipments = this._equipmentRepository.GetMachinesList();

                if (!string.IsNullOrEmpty(equipmentDescription))
                {
                    equipments = equipments.Where(r => r.EquipmentName.Contains(equipmentDescription));
                }

                var equipmentListView = this._equipmentFactory.CreateEquipmentView(equipments);

                return equipmentListView;
            }
            catch (Exception exception)
            {
                log.Error($"An error has occured. Method Name : SearchEquipment - EquipmentService {exception}");
                throw new ArgumentException(exception.ToString());
            }
        }

        /// <summary>
        /// Gets the equipment cart model.
        /// </summary>
        /// <returns></returns>
        public IEquipmentCartViewModel GetEquipmentCartModel(string message)
        {

            try
            {
                var cart = this.GetCartItems();
                var model = this._equipmentFactory.CreateEquipmentCartView(cart, message);
                return model;
            }
            catch (Exception exception)
            {
                log.Error($"An error has occured. Method Name : GetEquipmentCartModel - EquipmentService {exception}");
                throw new ArgumentException(exception.ToString());
            }
        }

        /// <summary>
        /// Adds to cart.
        /// </summary>
        /// <param name="equipment">The equipment.</param>
        public void AddToCart(IEquipmentModel equipment)
        {
            try
            {
                var equipmentListInCartItems = this.GetCartItems();


                if (equipmentListInCartItems == null)
                {
                    equipmentListInCartItems.Add(equipment);
                    HttpContext.Current.Session["Equipment"] = equipmentListInCartItems;
                }
                else
                {
                    equipmentListInCartItems.Add(equipment);
                    HttpContext.Current.Session["Equipment"] = equipmentListInCartItems;
                }
            }
            catch (Exception exception)
            {
                log.Error($"An error has occured. Method Name : AddToCart - EquipmentService {exception}");
                throw new ArgumentException(exception.ToString());
            }
        }


        /// <summary>
        /// Removes from cart.
        /// </summary>
        /// <param name="equipmentId">The equipment identifier.</param>
        public void RemoveFromCart(int equipmentId)
        {
            try
            {
                var equipments = this.GetCartItems();
                var selectedEquipment = equipments.Single(r => r.EquipmentID == equipmentId);
                if (selectedEquipment != null)
                    equipments.Remove(selectedEquipment);
            }
            catch (Exception exception)
            {
                log.Error($"An error has occured. Method Name : RemoveFromCart - EquipmentService {exception}");
                throw new ArgumentException(exception.ToString());
            }
        }


        /// <summary>
        /// Generates the invoice.
        /// </summary>
        /// <returns></returns>
        public MemoryStream GenerateInvoice()
        {
            try
            {
                var invoice = $"Rentos Equipment Renting {Environment.NewLine}";
                invoice = $"{invoice} Customer Invoice {Environment.NewLine}";
                invoice =
                    $"{invoice} ==================================================================== {Environment.NewLine}";
                invoice =
                    $"{invoice} SN    || Equipment Name            || Days of Hire    || Price {Environment.NewLine}";
                invoice =
                    $"{invoice} ==================================================================== {Environment.NewLine}";

                var equipments = this.GetCartItems();
                var sn = 0;
                var equipmentCartViewModel = new EquipmentCartViewModel();
                var price = 0;
                var totalPrice = 0;

                if (equipments.Any())
                {
                    foreach (var equipment in equipments)
                    {
                        price = equipmentCartViewModel.GetEquipmentPrice(equipment.EquipmentType, equipment.DaysOfHire);
                        totalPrice += price;


                        invoice =
                            $"{invoice} {++sn,-5} || {equipment.EquipmentName,-25} || {equipment.DaysOfHire,-15} ||   {price:N2} {Environment.NewLine}";
                    }

                    invoice =
                        $"{invoice} ============================================================= {Environment.NewLine}";
                    invoice = $"{invoice} {Environment.NewLine}";
                    invoice = $"{invoice}=====================";
                    invoice = $"{invoice} Total Price :  {totalPrice:N2} ";
                    invoice = $"{invoice}=====================";
                }

                var byteArray = Encoding.ASCII.GetBytes(invoice);
                var stream = new MemoryStream(byteArray);

                return stream;
            }
            catch (Exception exception)
            {
                log.Error($"An error has occured. Method Name : GenerateInvoice - EquipmentService {exception}");
                throw new ArgumentException(exception.ToString());
            }
        }

        /// <summary>
        /// Gets the cart items.
        /// </summary>
        /// <returns></returns>
        private IList<IEquipmentModel> GetCartItems()
        {
            try
            {
                var equipmentList = new List<IEquipmentModel>();

                var equipmentCart = HttpContext.Current.Session["Equipment"];

                if (equipmentCart != null)
                {
                    equipmentList = (List<IEquipmentModel>) equipmentCart;
                }

                return equipmentList;
            }
            catch (Exception exception)
            {
                log.Error($"An error has occured. Method Name : GetCartItems - EquipmentService {exception}");
                throw new ArgumentException(exception.ToString());
            }
        }
    }
}