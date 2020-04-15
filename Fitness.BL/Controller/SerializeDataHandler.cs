using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.BL.Controller
{
    public class SerializeDataHandler : IDataHandler
    {
        public List<T> Load<T>() where T : class
        {
            string fileName = typeof(T).Name + ".dat";
            var formatter = new BinaryFormatter();

            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                if (fs.Length > 0 && (formatter.Deserialize(fs) is List<T> items))
                {
                    return items;
                }
                else
                {
                    return default;
                }
            }
        }

        public void Save<T>(List<T> items) where T : class
        {
            string fileName = typeof(T).Name + ".dat";
            var formatter = new BinaryFormatter();

            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, items);
            }
        }
    }
}
