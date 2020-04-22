using System.Collections.Generic;
using System.Linq;

namespace Fitness.BL.Controller
{
    public class DatabaseDataHandler : IDataHandler
    {
        public List<T> Load<T>() where T : class
        {
            using (var db = new FitnessContext())
            {
                return db.Set<T>().Where(e => true).ToList();
            }
        }

        public void Save<T>(List<T> items) where T : class
        {
            using (var db = new FitnessContext())
            {
                //switch (typeof(T).Name)
                //{
                //    case "Activity":
                //        db.Activities.AddRange(items as Activity);
                //        break;
                //    case "Eating":
                //        db.Eatings.AddRange(items as Eating);
                //        break;
                //    case "Exercise":
                //        db.Exercises.AddRange(items as Exercise);
                //        break;
                //    case "Food":
                //        db.Foods.AddRange(items as Food);
                //        break;
                //    case "Gender":
                //        db.Genders.AddRange(items as Gender);
                //        break;
                //    case "User":
                //        db.Users.AddRange(items as User);
                //        break;

                //}

                db.Set<T>().AddRange(items);
                db.SaveChanges();
            }
        }
    }
}
