using UnityEngine;

public class CarrySMB : SceneLinkedSMB<PlayerController>
{
    private Carriable heldObject;

    public override void OnSLStatePostEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        heldObject = m_MonoBehaviour.GetHeldObject();
    }

    public override void OnSLStateNoTransitionUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Have the object move with Link in the carry position.
        heldObject.transform.position = (Vector2) m_MonoBehaviour.GetCarryPosition().transform.position - heldObject.carryOffset;

        m_MonoBehaviour.UpdateFacing();
        m_MonoBehaviour.Movement();
        m_MonoBehaviour.CheckForThrow();
    }
}
