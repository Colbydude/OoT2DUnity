using UnityEngine;

public class SwimSMB : SceneLinkedSMB<PlayerController>
{
    private SpriteRenderer shadowSpriteRenderer;

    public override void OnSLStatePostEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Hide Link's shadow while in the water.
        shadowSpriteRenderer = m_MonoBehaviour.ShadowTransform.GetComponent<SpriteRenderer>();
        shadowSpriteRenderer.enabled = false;

        // If Link's holding an object, not anymore.
        if (m_MonoBehaviour.HeldObject != null) {
            m_MonoBehaviour.HeldObject.Drop();
            m_MonoBehaviour.HeldObject = null;
        }
    }

    public override void OnSLStateNoTransitionUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        m_MonoBehaviour.UpdateFacing();
        m_MonoBehaviour.Movement();
    }

    public override void OnSLStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Re-enable the shadow.
        shadowSpriteRenderer.enabled = true;
    }
}
