/// <summary>
/// Direction in radians. Used for Actor facing and movement.
/// </summary>
public enum Direction
{
    Right = 0,
    Up = 90,
    Left = 180,
    Down = 270,
}

/// <summary>
/// Unity layers.
/// </summary>
public enum Layer
{
    Default = 0,
    TransparentFX = 1,
    IgnoreRaycast = 2,
    Water = 4,
    UI = 5,
    Player = 8,
    Enemies = 9,
    Objects = 10,
    Ground = 11,
    PlayerWeapon = 12,
    ThrownObjects = 13,
}

/// <summary>
/// Actions that the player can take. Changes context of the Action button.
/// </summary>
public enum PlayerAction
{
    None,
    Attack, // Roll
    Check,
    Climb,
    Decide,
    Dive,
    Down,
    Drop,
    Enter,
    Faster,
    Grab,
    Jump,
    Navi, // Unused
    Next,
    Open,
    PutAway,
    Reel,
    Save,
    Speak,
    Stop,
    Throw,
}
