using System;

public class Activity
{
    public Activity(int start, int end)
    {
        if (start > end)
        {
            // swap:
            var tmp = start;
            start = end;
            end = tmp;
        }
        Start = start;
        End = end;
    }

    public int Start { get; }
    public int End { get; }

    public int Length => End - Start;

    public bool Overlaps(Activity other) => other != null &&
    (
        (other.Start <= Start && other.End > Start)||
        (other.Start <= End && other.End >= Start)
    );

    public override bool Equals(object other)
    {
        var a = other as Activity;
        return a != null && a.End == End && a.Start == Start;
    }

    public override int GetHashCode() => Start.GetHashCode() ^ End.GetHashCode();

    public override string ToString() => $"[{Start}..{End}]";
}