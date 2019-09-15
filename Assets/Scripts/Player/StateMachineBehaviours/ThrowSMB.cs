using UnityEngine;

public class ThrowSMB : SceneLinkedSMB<PlayerController>
{
    private Carriable heldObject;

    public override void OnSLStatePostEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        m_MonoBehaviour.SetMoveVector(new Vector2(0, 0));

        heldObject = m_MonoBehaviour.GetHeldObject();
        heldObject.Throw(m_MonoBehaviour.direction, m_MonoBehaviour.throwSpeed);
    }

    public override void OnSLStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        heldObject.EnableCollider();
        m_MonoBehaviour.SetHeldObject(null);
    }
}
