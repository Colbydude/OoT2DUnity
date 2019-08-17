using UnityEngine;

public class SwordSMB : SceneLinkedSMB<PlayerController>
{
    public override void OnSLStatePostEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        m_MonoBehaviour.SetMoveVector(new Vector2(0, 0));
    }

    public override void OnSLStateNoTransitionUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        m_MonoBehaviour.CheckForSword();
    }
}
