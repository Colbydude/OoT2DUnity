using UnityEngine;

public class CarrySMB : SceneLinkedSMB<PlayerController>
{
    public override void OnSLStateNoTransitionUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Have the object move with Link in the carry position.
        _monoBehaviour.Carrier.HeldObject.transform.position = (Vector2)_monoBehaviour.Carrier.CarryPosition.transform.position - _monoBehaviour.Carrier.HeldObject.CarryOffset;

        _monoBehaviour.UpdateFacing();
        _monoBehaviour.Movement();
        _monoBehaviour.CheckForThrow();
    }
}
