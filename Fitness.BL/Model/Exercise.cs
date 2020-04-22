using System;

namespace Fitness.BL.Model
{
    [Serializable]
    /// <summary>
    /// Class Exercise
    /// </summary>
    public class Exercise
    {
        public int Id { get; set; }

        public DateTime Start { get; set; }

        public DateTime Finish { get; set; }

        public int ActivityId { get; set; }

        public virtual Activity Activity { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }

        public Exercise() { }

        public Exercise(DateTime start, DateTime finish, Activity activity, User user)
        {
            // TODO: Проверка
            Start = start;
            Finish = finish;
            Activity = activity ?? throw new ArgumentNullException("Полученный пользователь равен null", nameof(activity));
            ActivityId = activity.Id;
            User = user ?? throw new ArgumentNullException("Полученный пользователь равен null", nameof(user));
            UserId = user.Id;
        }

    }
}
