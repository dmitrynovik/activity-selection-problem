using System.Linq;

namespace ActivitySelectionProblem
{
    // The activity selection problem as described at: https://en.wikipedia.org/wiki/Activity_selection_problem
    public static class Regular
    {
        public static int Compute(params (int, int)[] activities) =>
            Compute(activities.Select(i => new Activity(i.Item1, i.Item2)).ToArray());

        public static int Compute(params Activity[] activities)
        {
            if (activities == null || activities.Length <= 0)
                return 0;

            var sortedActivities = activities.OrderBy(x => x.End).ToArray();
            var result = 1;
            var prev = sortedActivities[0];

            for (int i = 1; i < sortedActivities.Length; ++i)
            {
                if (sortedActivities[i].Start >= prev.End)
                {
                    result++;
                    prev = sortedActivities[i];
                }
            }
            return result;
        }
    }
}
