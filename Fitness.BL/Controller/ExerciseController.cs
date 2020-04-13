using Fitness.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.BL.Controller
{
    public class ExerciseController : ControllerBase
    {

        //private const string EXERCISES_FILE_NAME = "exercises.dat";

        //private const string ACTIVITIES_FILE_NAME = "activies.dat";

        private readonly User user;

        public List<Exercise> Exercises { get; }
        
        public List<Activity> Activities { get; }


        public ExerciseController(User user)
        {
            this.user = user ?? throw new ArgumentNullException("Пользователь не может быть пустым или null", nameof(user));

            Exercises = Load<Exercise>() ?? new List<Exercise>(); ;
            Activities = Load<Activity>() ?? new List<Activity>(); ;
        }

        public void Add(Activity activity, DateTime begin, DateTime end)
        {

            var _activity = Activities.FirstOrDefault(e => e.Name == activity.Name);
            if (_activity == null)
            {
                Activities.Add(activity);

                var exercise = new Exercise(begin, end, activity, user);
                Exercises.Add(exercise);
                Save<Activity>(Activities);
            }
            else
            {
                var exercise = new Exercise(begin, end, _activity, user);
                Exercises.Add(exercise);
            }
            Save<Exercise>(Exercises);

        }



    }
}
