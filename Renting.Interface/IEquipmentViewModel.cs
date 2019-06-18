using System.Collections.Generic;

namespace Renting.Interface
{
    public interface IEquipmentViewModel
    {
         IEnumerable<IEquipmentModel> Equipments { get; set; }

  
    }
}