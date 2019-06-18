using System.Collections.Generic;
using Renting.Interface;

namespace Renting.Domain.Models
{
    public class EquipmentViewModel:IEquipmentViewModel
    {
        public IEnumerable<IEquipmentModel> Equipments { get; set; }
    }
}