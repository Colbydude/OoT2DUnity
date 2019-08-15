using UnityEngine;

public class SwimSMB : SceneLinkedSMB<PlayerController>
{
    private Vector2 originalShadowPosition;

    public override void OnSLStatePostEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        originalShadowPosition = m_MonoBehaviour.GetShadowTransform().localPosition;
        m_MonoBehaviour.GetShadowTransform().localPosition = new Vector2(0, 0.875f);
        m_MonoBehaviour.GetShadowSpriteRenderer().enabled = false;
    }

    public override void OnSLStateNoTransitionUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        m_MonoBehaviour.UpdateFacing();
        m_MonoBehaviour.Movement();
    }

    public override void OnSLStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        m_MonoBehaviour.GetShadowTransform().localPosition = originalShadowPosition;
        m_MonoBehaviour.GetShadowSpriteRenderer().enabled = true;
    }
}
