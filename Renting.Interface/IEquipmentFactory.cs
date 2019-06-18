using System.Collections.Generic;

namespace Renting.Interface.Factory
{
    public interface IEquipmentFactory
    {
        /// <summary>
        /// Creates the equipment view.
        /// </summary>
        /// <param name="equipments">The equipments.</param>
        /// <returns></returns>
        IEquipmentViewModel CreateEquipmentView(IEnumerable<IEquipmentModel> equipments);

        /// <summary>
        /// Creates the equipment cart view.
        /// </summary>
        /// <param name="equipments">The equipments.</param>
        /// <returns></returns>
        IEquipmentCartViewModel CreateEquipmentCartView(IEnumerable<IEquipmentModel> equipments);
    }
}