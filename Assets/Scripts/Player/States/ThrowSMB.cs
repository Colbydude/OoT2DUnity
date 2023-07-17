using UnityEngine;

public class ThrowSMB : SceneLinkedSMB<PlayerController>
{
    public override void OnSLStatePostEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _monoBehaviour.EnableSwordUse(false);
        _monoBehaviour.LockMovement();
        _monoBehaviour.StopMoving();

        _monoBehaviour.Carrier.Throw();
    }

    public override void OnSLStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _monoBehaviour.EnableSwordUse();
        _monoBehaviour.LockMovement(false);
    }
}
