using UnityEngine;

public class SwimSMB : SceneLinkedSMB<PlayerController>
{
    private SpriteRenderer shadowSpriteRenderer;

    public override void OnSLStatePostEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        shadowSpriteRenderer = m_MonoBehaviour.GetShadowTransform().GetComponent<SpriteRenderer>();
        shadowSpriteRenderer.enabled = false;
    }

    public override void OnSLStateNoTransitionUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        m_MonoBehaviour.UpdateFacing();
        m_MonoBehaviour.Movement();
    }

    public override void OnSLStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        shadowSpriteRenderer.enabled = true;
    }
}
