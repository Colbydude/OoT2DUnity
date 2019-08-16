using UnityEngine;

public class SwimSMB : SceneLinkedSMB<PlayerController>
{
    public override void OnSLStatePostEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        m_MonoBehaviour.GetShadowSpriteRenderer().enabled = false;
    }

    public override void OnSLStateNoTransitionUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        m_MonoBehaviour.UpdateFacing();
        m_MonoBehaviour.Movement();
    }

    public override void OnSLStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        m_MonoBehaviour.GetShadowSpriteRenderer().enabled = true;
    }
}
