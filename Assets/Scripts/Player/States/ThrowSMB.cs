using UnityEngine;

public class ThrowSMB : SceneLinkedSMB<PlayerController>
{
    public override void OnSLStatePostEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _monoBehaviour.SetMoveVector(new Vector2(0, 0));
        _monoBehaviour.Carrier.Throw();
    }
}
