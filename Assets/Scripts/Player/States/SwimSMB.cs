using UnityEngine;

public class SwimSMB : SceneLinkedSMB<PlayerController>
{
    public override void OnSLStatePostEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Hide Link's shadow while in the water.
        _monoBehaviour.Shadow.Renderer.enabled = false;

        // If Link's holding an object, not anymore.
        _monoBehaviour.Carrier.Drop();
    }

    public override void OnSLStateNoTransitionUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _monoBehaviour.UpdateFacing();
        _monoBehaviour.Movement();
    }

    public override void OnSLStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Re-enable the shadow.
        _monoBehaviour.Shadow.Renderer.enabled = true;
    }
}
