using UnityEngine;

public class RollSMB : SceneLinkedSMB<PlayerController>
{
    public override void OnSLStatePostEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Vector2 directionVector = _monoBehaviour.Direction.ToVector2();
        _monoBehaviour.SetMoveVector(new Vector2(directionVector.x * _monoBehaviour.RollSpeed, directionVector.y * _monoBehaviour.RollSpeed));
    }
}
