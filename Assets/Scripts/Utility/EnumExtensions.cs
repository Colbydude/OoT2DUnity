using UnityEngine;

public static class EnumExtensions
{
    public static Vector2 ToVector2(this Direction direction)
    {
        switch (direction)
        {
            case Direction.Right: return new Vector2(1, 0);
            case Direction.Up: return new Vector2(0, 1);
            case Direction.Left: return new Vector2(-1, 0);
            default: return new Vector2(0, -1);
        }
    }
}
