using System.Collections.Generic;
using System.IO;

namespace Renting.Interface
{
    public interface IEquipmentService
    {
        /// <summary>
        /// Gets the equipment view model.
        /// </summary>
        /// <returns></returns>
        IEquipmentViewModel GetEquipmentViewModel();

        /// <summary>
        /// Adds to cart.
        /// </summary>
        /// <param name="equipment">The equipment.</param>
        void AddToCart(IEquipmentModel equipment);

        /// <summary>
        /// Removes from cart.
        /// </summary>
        /// <param name="equipmentId">The equipment identifier.</param>
        void RemoveFromCart(int equipmentId);

        /// <summary>
        /// Gets the equipment cart model.
        /// </summary>
        /// <returns></returns>
        IEquipmentCartViewModel GetEquipmentCartModel(string message);

        /// <summary>
        /// Searches the equipment.
        /// </summary>
        /// <param name="equipmentDescription">The equipment description.</param>
        /// <returns></returns>
        IEquipmentViewModel SearchEquipment(string equipmentDescription);

        /// <summary>
        /// Generates the invoice.
        /// </summary>
        /// <returns></returns>
        MemoryStream GenerateInvoice();
    }
}