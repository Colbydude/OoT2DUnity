using UnityEngine;

public class SwordSMB : SceneLinkedSMB<PlayerController>
{
    private Collider2D swordCollider;
    private SpriteRenderer swordRenderer;

    public override void OnSLStatePostEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        swordCollider = m_MonoBehaviour.Sword.Collider2D;
        swordRenderer = m_MonoBehaviour.Sword.SpriteRenderer;

        // Stop moving and swing the sword, making the sword collider active.
        m_MonoBehaviour.SetMoveVector(new Vector2(0, 0));
        swordCollider.enabled = true;
        swordRenderer.enabled = true;
    }

    public override void OnSLStateNoTransitionUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        m_MonoBehaviour.CheckForSword();
    }

    public override void OnSLStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Disable the sword and sword collider.
        swordCollider.enabled = false;
        swordRenderer.enabled = false;
    }
}
