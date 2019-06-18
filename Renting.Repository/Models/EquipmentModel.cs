using Renting.Interface;

namespace Renting.Repository.Models
{
    public class EquipmentModel:IEquipmentModel
    {
        public int EquipmentID { get; set; }
        public string EquipmentName { get; set; }
        public string EquipmentType { get; set; }
        public int DaysOfHire { get; set; }
    }
}