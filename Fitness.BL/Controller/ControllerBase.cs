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

        private readonly IDataHandler dataHandler = new SerializeDataHandler();
        //private readonly IDataHandler dataHandler = new DatabaseDataHandler();

        /// <summary>
        /// Load users data
        /// </summary>
        /// <returns></returns>
        protected List<T> Load<T>() where T : class
        {
            return dataHandler.Load<T>();
        }

        /// <summary>
        /// Save user's data
        /// </summary>
        protected void Save<T>(List<T> items) where T : class
        {
            dataHandler.Save<T>(items);
        }

    }
}
