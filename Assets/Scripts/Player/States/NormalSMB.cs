using UnityEngine;

public class NormalSMB : SceneLinkedSMB<PlayerController>
{
    public override void OnSLStateNoTransitionUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _monoBehaviour.UpdateFacing();
        _monoBehaviour.Movement();
        _monoBehaviour.CheckForRoll();
        _monoBehaviour.CheckForSword();
        _monoBehaviour.CheckForPickup();
    }
}
