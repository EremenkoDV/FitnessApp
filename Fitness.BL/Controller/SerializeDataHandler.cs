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
        public T Load<T>(string fileName) where T : class
        {
            var formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                if (fs.Length > 0 && (formatter.Deserialize(fs) is T items))
                {
                    return items;
                }
                else
                {
                    return default(T);
                }
            }
        }

        public void Save<T>(string fileName, T item) where T : class
        {
            var formatter = new BinaryFormatter();

            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, item);
            }
        }
    }
}
