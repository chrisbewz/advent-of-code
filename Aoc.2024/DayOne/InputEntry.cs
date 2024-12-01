namespace DayOne;

public struct InputEntry
{
    public int Left { get; init;}
    public int Right { get; init; }

    public int Distance => Math.Abs(this.Left - this.Right);

    /// <summary>Initializes a new instance of the <see cref="T:System.Object" /> class.</summary>
    public InputEntry(int left, int right)
    {
        this.Left = left;
        this.Right = right;
    }
}
