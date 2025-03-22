namespace AdventOfCode2024.Day6;

public class Guard(int x, int y, Direction direction = Direction.North)
{
    public int X { get; set; } = x;
    public int Y { get; set; } = y;

    public Direction CurrentDirection { get; set; } = direction;

    public void Rotate()
    {
        CurrentDirection = CurrentDirection switch
        {
            Direction.North => Direction.East,
            Direction.South => Direction.West,
            Direction.East => Direction.South,
            Direction.West => Direction.North,
            _ => CurrentDirection
        };
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(X, Y, CurrentDirection);
    }

    public override bool Equals(object? obj)
    {
        var guard = obj as Guard;
        return guard != null && Equals(guard);
    }

    private bool Equals(Guard other)
    {
        return X == other.X && Y == other.Y && CurrentDirection == other.CurrentDirection;
    }
}