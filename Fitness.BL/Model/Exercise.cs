using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.BL.Model
{
    [Serializable]
    /// <summary>
    /// Class Exercise
    /// </summary>
    public class Exercise
    {
        public int Id { get; set; }

        public Activity Activity { get; set; }

        public DateTime Start { get; set; }

        public DateTime Finish { get; set; }

        public User User { get; set; }

        public Exercise(DateTime start, DateTime finish, Activity activity, User user)
        {
            // TODO: Проверка
            Start = start;
            Finish = finish;
            Activity = activity;
            User = user;
        }

    }
}
