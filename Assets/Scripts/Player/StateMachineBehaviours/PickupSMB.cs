﻿using UnityEngine;

public class PickupSMB : SceneLinkedSMB<PlayerController>
{
    private Carriable target;
    private Vector2 startPosition;
    private Vector2 carryPosition;

    public override void OnSLStatePostEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        m_MonoBehaviour.SetMoveVector(new Vector2(0, 0));

        target = m_MonoBehaviour.GetCarriableTarget();
        target.DisableCollider();

        // Set sorting order first if Link's facing down.
        if (m_MonoBehaviour.direction == 270) {
            target.GetSpriteRenderer().sortingOrder = 2;
        }

        startPosition = target.transform.position;
        carryPosition = (Vector2) m_MonoBehaviour.GetCarryPosition().transform.position - target.carryOffset;
    }

    public override void OnSLStateNoTransitionUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Lerp towards the carry position while animating.
        // The object will then "snap" to the carry position in the next state.
        if (target != null) {
            target.transform.position = Vector2.Lerp(startPosition, carryPosition, 0.5f);
        }
    }

    public override void OnSLStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        m_MonoBehaviour.SetHeldObject(target);

        // Set the sorting order so the object shows on top of Link.
        target.GetSpriteRenderer().sortingOrder = 2;

        target = null;
        m_MonoBehaviour.SetCarriableTarget(null);
    }
}
