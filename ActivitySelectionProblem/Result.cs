using System.Collections.Generic;
using System.Linq;

public class Result
{
    public Result() {  }

    public Result(int score, IEnumerable<Activity> activities) 
    { 
        Score = score;
        Activities = activities == null ? new List<Activity>() : activities.ToList();
    }

    public Result(Result other)
    {
        if (other != null)
        {
            Score = other.Score;
            Activities = other.Activities.ToList();
        }
    }

    public int Score { get;  }
    public ICollection<Activity> Activities { get; private set; } = new List<Activity>();
}