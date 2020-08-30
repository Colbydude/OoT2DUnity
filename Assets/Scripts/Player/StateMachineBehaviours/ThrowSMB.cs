using UnityEngine;

public class ThrowSMB : SceneLinkedSMB<PlayerController>
{
    private Carriable heldObject;

    public override void OnSLStatePostEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        m_MonoBehaviour.SetMoveVector(new Vector2(0, 0));

        heldObject = m_MonoBehaviour.HeldObject;
        heldObject.Collider2D.enabled = true;
        heldObject.gameObject.layer = Constants.Layers.ThrownObjects;
        heldObject.Throw(m_MonoBehaviour.direction, m_MonoBehaviour.throwSpeed);
        m_MonoBehaviour.HeldObject = null;
    }

    public override void OnSLStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
    }
}
