using System;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Player Input proxy.
/// </summary>
public class PlayerInputReader : MonoBehaviour, OoTActions.IPlayerActions
{
    private OoTActions controls;

    public Vector2 MoveComposite { get; private set; }

    public event Action ActionPerformed;
    public event Action SwordPerformed;
    public event Action ShieldPerformed;
    public event Action Item1Performed;
    public event Action Item2Performed;
    public event Action Item3Performed;
    public event Action NaviPerformed;
    public event Action TargetPerformed;
    public event Action ToggleMapPerformed;
    public event Action OpenSubscreenPerformed;

    private void OnEnable()
    {
        if (controls != null)
            return;

        controls = new OoTActions();
        controls.Player.SetCallbacks(this);
        Enable();
    }

    private void OnDisable()
    {
        Disable();
    }

    public void Enable()
    {
        controls.Player.Enable();
    }

    public void Disable()
    {
        controls.Player.Disable();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        MoveComposite = context.ReadValue<Vector2>();
    }

    public void OnAction(InputAction.CallbackContext context)
    {
        if (!context.performed)
            return;

        ActionPerformed?.Invoke();
    }

    public void OnSword(InputAction.CallbackContext context)
    {
        if (!context.performed)
            return;

        SwordPerformed?.Invoke();
    }

    public void OnShield(InputAction.CallbackContext context)
    {
        if (!context.performed)
            return;

        ShieldPerformed?.Invoke();
    }

    public void OnItem1(InputAction.CallbackContext context)
    {
        if (!context.performed)
            return;

        Item1Performed?.Invoke();
    }

    public void OnItem2(InputAction.CallbackContext context)
    {
        if (!context.performed)
            return;

        Item2Performed?.Invoke();
    }

    public void OnItem3(InputAction.CallbackContext context)
    {
        if (!context.performed)
            return;

        Item3Performed?.Invoke();
    }

    public void OnNavi(InputAction.CallbackContext context)
    {
        if (!context.performed)
            return;

        NaviPerformed?.Invoke();
    }

    public void OnTarget(InputAction.CallbackContext context)
    {
        if (!context.performed)
            return;

        TargetPerformed?.Invoke();
    }

    public void OnToggleMap(InputAction.CallbackContext context)
    {
        if (!context.performed)
            return;

        ToggleMapPerformed?.Invoke();
    }

    public void OnOpenSubscreen(InputAction.CallbackContext context)
    {
        if (!context.performed)
            return;

        OpenSubscreenPerformed?.Invoke();
    }
}
