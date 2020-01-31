using System;
using System.Linq;

namespace ActivitySelectionProblem
{
    // Weighted activity selection problem as described at: https://en.wikipedia.org/wiki/Activity_selection_problem#Weighted_activity_selection_problem
    public static class Weighted 
    {
        public static int Compute(params (int, int)[] activities) => 
            Compute(activities.Select(i => new Activity(i.Item1, i.Item2)).ToArray());

        public static int Compute(params Activity[] activities)
        {
            if (activities == null || activities.Length <= 0)
                return 0;

            var sortedActivities =  activities.OrderBy(x => x.End).ToList();
            var scores = new int[sortedActivities.Count];

            for (int i = 0; i < sortedActivities.Count; ++i)
            {
                var currentActivity = sortedActivities[i];
                var prevScore = i == 0 ? currentActivity.Length : scores[i - 1];

                var prevActivity = sortedActivities.LastOrDefault(a => a != currentActivity && a.End <= sortedActivities[i].Start);
                if (prevActivity == null)
                {
                    scores[i] = Math.Max(prevScore, currentActivity.Length);
                }
                else
                {
                    var prevActivityIndex = sortedActivities.IndexOf(prevActivity);
                    if (prevScore < scores[prevActivityIndex] + currentActivity.Length)
                    {
                        scores[i] = scores[prevActivityIndex] + currentActivity.Length;
                    }
                    else scores[i] = prevScore;
                }
            }
            return scores[scores.Length - 1];
        }
    }
}
