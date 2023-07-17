using UnityEngine;

public class SwordSMB : SceneLinkedSMB<PlayerController>
{
    public override void OnSLStatePostEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Stop moving and swing the sword, making the sword collider active.
        _monoBehaviour.LockMovement();
        _monoBehaviour.StopMoving();

        _monoBehaviour.Carrier.Drop();

        _monoBehaviour.Sword.Collider.enabled = true;
        _monoBehaviour.Sword.Renderer.enabled = true;
    }

    public override void OnSLStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Disable the sword and sword collider.
        _monoBehaviour.Sword.Collider.enabled = false;
        _monoBehaviour.Sword.Renderer.enabled = false;

        _monoBehaviour.LockMovement(false);
    }
}
