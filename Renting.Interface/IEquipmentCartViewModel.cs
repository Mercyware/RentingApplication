using System.Collections.Generic;

namespace Renting.Interface
{
    public interface IEquipmentCartViewModel : IEquipmentViewModel
    {

        string ProcessingMessage { get; set; }

        int GetEquipmentPrice(string equipmentType, int days);
    }
}