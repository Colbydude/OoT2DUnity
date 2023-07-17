using UnityEngine;

public class SwimSMB : SceneLinkedSMB<PlayerController>
{
    public override void OnSLStatePostEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _monoBehaviour.EnableSwordUse(false);

        // If Link's holding an object, not anymore.
        _monoBehaviour.Carrier.Drop();

        // Hide Link's shadow while in the water.
        _monoBehaviour.Shadow.Renderer.enabled = false;
    }

    public override void OnSLStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _monoBehaviour.EnableSwordUse();

        // Re-enable the shadow.
        _monoBehaviour.Shadow.Renderer.enabled = true;
    }
}
