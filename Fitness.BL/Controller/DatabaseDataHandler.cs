using Fitness.BL.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.BL.Controller
{
    public class DatabaseDataHandler : IDataHandler
    {
        public T Load<T>(string fileName) where T : class
        {
            using (var db = new FitnessContext())
            {
                return db.Set<T>().FirstOrDefault();
            }
        }

        public void Save<T>(string fileName, T item) where T : class
        {
            using (var db = new FitnessContext())
            {
                //switch (typeof(T).Name)
                //{
                //    case "Activity":
                //        db.Activities.Add(item as Activity);
                //        break;
                //    case "Eating":
                //        db.Eatings.Add(item as Eating);
                //        break;
                //    case "Exercise":
                //        db.Exercises.Add(item as Exercise);
                //        break;
                //    case "Food":
                //        db.Foods.Add(item as Food);
                //        break;
                //    case "Gender":
                //        db.Genders.Add(item as Gender);
                //        break;
                //    case "User":
                //        db.Users.Add(item as User);
                //        break;

                //}

                db.Set<T>().Add(item);
                db.SaveChanges();
            }
        }
    }
}
