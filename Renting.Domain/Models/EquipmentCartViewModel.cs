using System.Collections.Generic;
using Renting.Interface;

namespace Renting.Domain.Models
{
    public class EquipmentCartViewModel : IEquipmentCartViewModel
    {
        public IEnumerable<IEquipmentModel> Equipments { get; set; }

        public string ProcessingMessage { get; set; }

        public int GetEquipmentPrice(string equipmentType, int days)
        {
            var price = 0;
            var oneTimePrice = 100;
            var premiumPrice = 60;
            var regularPrice = 40;

            if (equipmentType == "H")
            {
                price = oneTimePrice + (premiumPrice * days);
            }

            if (equipmentType == "R")
            {
                var initialPrice = 0;
                if (days > 2)
                {
                    initialPrice = premiumPrice * 2 + (regularPrice * (days - 2));
                }
                else
                {
                    initialPrice = premiumPrice * 2;
                }

                price = oneTimePrice + initialPrice;
            }

            if (equipmentType == "S")
            {
                var initialPrice = 0;
                if (days > 3)
                {
                    initialPrice = premiumPrice * 3 + (regularPrice * (days - 3));
                }
                else
                {
                    initialPrice = premiumPrice * 3;
                }

                price = initialPrice;
            }

            return price;
        }

    }
}