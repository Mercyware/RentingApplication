using System;
using System.Runtime.CompilerServices;
using Renting.Interface;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Renting.Repository.Models
{
    public class EquipmentModel : IEquipmentModel
    {
        public int EquipmentID { get; set; }

        public string EquipmentName { get; set; }

        public string EquipmentType { get; set; }

        [Required]
        [Range(1, 90,ErrorMessage = ("Number of days to hire is between 1 and 90 days"))]
        public int DaysOfHire { get; set; }

        public string ProcessingMessage { get; set; }
    }
}