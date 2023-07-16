using UnityEngine;

public class PickupSMB : SceneLinkedSMB<PlayerController>
{
    private Carriable _target;
    private Vector2 _startPosition;
    private Vector2 _carryPosition;

    public override void OnSLStatePostEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _monoBehaviour.SetMoveVector(new Vector2(0, 0));

        _target = _monoBehaviour.Carrier.Target;
        _target.Collider.enabled = false;

        // Set sorting order first if Link's facing down.
        if (_monoBehaviour.Direction == Direction.Down)
            _target.Renderer.sortingOrder = 2;

        _startPosition = _target.transform.position;
        _carryPosition = (Vector2)_monoBehaviour.Carrier.CarryPosition.transform.position - _target.CarryOffset;
    }

    public override void OnSLStateNoTransitionUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Lerp towards the carry position while animating.
        // The object will then "snap" to the carry position in the next state.
        // @TODO: Update to just update the Player's CarryPosition with the animation instead of manually lerping.
        if (_target != null)
            _target.transform.position = Vector2.Lerp(_startPosition, _carryPosition, 0.5f);
    }

    public override void OnSLStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _monoBehaviour.Carrier.Carry(_target);
    }
}
