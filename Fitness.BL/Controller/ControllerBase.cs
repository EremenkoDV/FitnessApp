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

        protected IDataHandler dataHandler = new SerializeDataHandler();

        /// <summary>
        /// Load users data
        /// </summary>
        /// <returns></returns>
        protected T Load<T>(string fileName)
        {
            return dataHandler.Load<T>(fileName);
        }

        /// <summary>
        /// Save user's data
        /// </summary>
        protected void Save<T>(string fileName, T items)
        {
            dataHandler.Save<T>(fileName, items);
        }

    }
}
