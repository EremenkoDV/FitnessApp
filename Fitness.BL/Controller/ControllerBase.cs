using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.BL.Controller
{
    public abstract class ControllerBase
    {

        /// <summary>
        /// Load users data
        /// </summary>
        /// <returns></returns>
        protected virtual T Load<T>(string fileName)
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

        /// <summary>
        /// Save user's data
        /// </summary>
        protected virtual void Save<T>(string fileName, T items)
        {
            var formatter = new BinaryFormatter();

            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, items);
            }
        }

    }
}
