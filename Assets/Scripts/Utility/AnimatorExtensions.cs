using UnityEngine;

public static class AnimatorExtensions
{
    /// <summary>
    /// Set FaceX and FaceY float values on the animator.
    /// </summary>
    public static void SetFacing(this Animator animator, float x, float y)
    {
        animator.SetFloat(ActorAnimatorHashes.FaceX, x);
        animator.SetFloat(ActorAnimatorHashes.FaceY, y);
    }

    /// <summary>
    /// Set FaceX and FaceY float values on the animator.
    /// </summary>
    public static void SetFacing(this Animator animator, Vector2 facing)
    {
        animator.SetFacing(facing.x, facing.y);
    }
}
