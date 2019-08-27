using UnityEngine;

public class NormalSMB : SceneLinkedSMB<PlayerController>
{
    public override void OnSLStateNoTransitionUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        m_MonoBehaviour.UpdateFacing();
        m_MonoBehaviour.Movement();
        m_MonoBehaviour.CheckForRoll();
        m_MonoBehaviour.CheckForSword();
        m_MonoBehaviour.CheckForPickup();
    }
}
