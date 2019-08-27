using UnityEngine;

public class PickupSMB : SceneLinkedSMB<PlayerController>
{
    public override void OnSLStatePostEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        m_MonoBehaviour.SetMoveVector(new Vector2(0, 0));
        // Move object to pickup position.
    }

    public override void OnSLStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Move object to carry position.
        // Set object as being carried.
    }
}
