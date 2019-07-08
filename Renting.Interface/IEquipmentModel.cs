namespace Renting.Interface
{
    public interface IEquipmentModel
    {
        int EquipmentID { get; set; }
        string EquipmentName { get; set; }
        string EquipmentType { get; set; }
        int DaysOfHire { get; set; }
        string ProcessingMessage { get; set; }
    }
}