using UnityEngine;

public class ThrowSMB : SceneLinkedSMB<PlayerController>
{
    private Carriable heldObject;

    public override void OnSLStatePostEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        m_MonoBehaviour.SetMoveVector(new Vector2(0, 0));
        heldObject = m_MonoBehaviour.GetHeldObject();

        // Set object throw trajectory/velocity.
    }

    public override void OnSLStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        heldObject.EnableCollider();
        heldObject.GetSpriteRenderer().sortingOrder = 0;
        m_MonoBehaviour.SetHeldObject(null);
    }
}
