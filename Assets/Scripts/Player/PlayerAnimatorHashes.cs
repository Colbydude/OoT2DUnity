using UnityEngine;

/// <summary>
/// Animator string hashes unique to the player.
/// </summary>
public static class PlayerAnimatorHashes
{
    public static readonly int Carry = Animator.StringToHash("Carry");
    public static readonly int Normal = Animator.StringToHash("Normal");
    public static readonly int Pickup = Animator.StringToHash("Pickup");
    public static readonly int Roll = Animator.StringToHash("Roll");
    public static readonly int Swim = Animator.StringToHash("Swim");
    public static readonly int Sword = Animator.StringToHash("Sword");
    public static readonly int Throw = Animator.StringToHash("Throw");
}
