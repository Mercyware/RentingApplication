using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renting.Repository.DB
{
    class DBConnection
    {

        public IList<String> ReadInventory()
        {
            string[] lines;
            var list = new List<string>();
            var fileStream = new FileStream(@"inventory.txt", FileMode.Open, FileAccess.Read);
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
            {
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    list.Add(line);
                }
            }

            return  lines = list.ToArray();
        }
    }
}
