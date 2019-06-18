using System.Collections.Generic;

namespace Renting.Interface
{
    public interface IEquipmentRepository
    {
        IEnumerable<IEquipmentModel> GetMachinesList();
    }
}