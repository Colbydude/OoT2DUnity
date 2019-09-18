using UnityEngine;

public class ThrowSMB : SceneLinkedSMB<PlayerController>
{
    private Carriable heldObject;

    public override void OnSLStatePostEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        m_MonoBehaviour.SetMoveVector(new Vector2(0, 0));

        heldObject = m_MonoBehaviour.HeldObject;
        heldObject.Throw(m_MonoBehaviour.direction, m_MonoBehaviour.throwSpeed);
    }

    public override void OnSLStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Enable the heldObject's collider after Link has finished the throw animation,
        // so that Link himself doesn't get hit. Maybe a better way to do this?
        heldObject.Collider2D.enabled = true;
        m_MonoBehaviour.HeldObject = null;
    }
}
