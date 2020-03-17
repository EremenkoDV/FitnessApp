using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.BL.Controller
{
    public interface IDataHandler
    {

        T Load<T>(string fileName) where T : class;

        void Save<T>(string fileName, T item) where T : class;

    }
}
