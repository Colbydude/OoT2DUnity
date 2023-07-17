using UnityEngine;

public class RollSMB : SceneLinkedSMB<PlayerController>
{
    public override void OnSLStatePostEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _monoBehaviour.EnableSwordUse(false);
        _monoBehaviour.LockMovement();

        _monoBehaviour.SetMoveVector(_monoBehaviour.Direction.ToVector2() * _monoBehaviour.RollSpeed);
    }

    public override void OnSLStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _monoBehaviour.EnableSwordUse();
        _monoBehaviour.LockMovement(false);
    }
}
