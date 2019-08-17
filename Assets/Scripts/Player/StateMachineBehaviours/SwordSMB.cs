using UnityEngine;

public class SwordSMB : SceneLinkedSMB<PlayerController>
{
    private Collider2D swordCollider;
    private SpriteRenderer swordRenderer;

    public override void OnSLStatePostEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        swordCollider = m_MonoBehaviour.GetSwordTransform().GetComponent<Collider2D>();
        swordRenderer = m_MonoBehaviour.GetSwordTransform().GetComponent<SpriteRenderer>();

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
        swordCollider.enabled = false;
        swordRenderer.enabled = false;
    }
}
