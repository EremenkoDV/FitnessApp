using System.Collections.Generic;

namespace Fitness.BL.Controller
{
    public interface IDataHandler
    {

        List<T> Load<T>() where T : class;

        void Save<T>(List<T> items) where T : class;

    }
}
