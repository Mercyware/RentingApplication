namespace Renting.Interface
{
    public interface IEquipmentCartViewModel : IEquipmentViewModel
    {
        int GetEquipmentPrice(string equipmentType, int days);
    }
}