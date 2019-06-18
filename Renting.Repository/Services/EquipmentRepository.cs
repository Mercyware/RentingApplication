using Renting.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Renting.Repository.Models;
using Newtonsoft.Json;
using System.Reflection;

namespace Renting.Repository.Services
{
    public class EquipmentRepository : IEquipmentRepository
    {
       


        public IEnumerable<IEquipmentModel> GetMachinesList()
        {
            var list = new List<IEquipmentModel>();
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,@"App_Data\Machines.txt");

            var equitmentText = File.ReadAllText(path);
            var equipments = JsonConvert.DeserializeObject<IEnumerable<EquipmentModel>>(equitmentText);

            return equipments;
        }
    }
}