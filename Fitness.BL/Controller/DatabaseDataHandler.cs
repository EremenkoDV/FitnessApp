using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.BL.Controller
{
    public class DatabaseDataHandler : IDataHandler
    {
        public T Load<T>(string fileName)
        {
            throw new NotImplementedException();
        }

        public void Save<T>(string fileName, T items)
        {
            throw new NotImplementedException();
        }
    }
}
