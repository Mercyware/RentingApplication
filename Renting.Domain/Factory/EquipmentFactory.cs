using System.Collections.Generic;
using Renting.Interface;
using Renting.Interface.Factory;
using System;
using Renting.Domain.Services;
using Renting.Domain.Models;

namespace Renting.Domain.Factory
{
    public class EquipmentFactory : IEquipmentFactory
    {
        /// <summary>
        /// Creates the equipment view.
        /// </summary>
        /// <param name="equipments">The equipments.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">equipments</exception>
        public IEquipmentViewModel CreateEquipmentView(IEnumerable<IEquipmentModel> equipments)
        {
            if (equipments == null)
            {
                throw new ArgumentNullException(nameof(equipments));
            }

            //Generate the view data
            var viewModel = new EquipmentViewModel
            {
                Equipments = equipments
            };

            return viewModel;
        }


        /// <summary>
        /// Creates the equipment cart view.
        /// </summary>
        /// <param name="equipments">The equipments.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">equipments</exception>
        public IEquipmentCartViewModel CreateEquipmentCartView(IEnumerable<IEquipmentModel> equipments)
        {
            if (equipments == null)
            {
                throw new ArgumentNullException(nameof(equipments));
            }

            //Generate the view data
            var viewModel = new EquipmentCartViewModel
            {
                Equipments = equipments
            };

            return viewModel;
        }
    }
}