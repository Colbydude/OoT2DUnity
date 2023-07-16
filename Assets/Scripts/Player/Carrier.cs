using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class Carrier : MonoBehaviour
{
    [SerializeField] private Transform _carryPosition;
    [SerializeField] private LayerMask _hittableLayers;

    private Direction _direction;
    private RaycastHit2D _foundObject;
    private Carriable _heldObject;
    private Carriable _target;

    public Transform CarryPosition => _carryPosition;
    public Carriable HeldObject => _heldObject;
    public Carriable Target => _target;

    private void FixedUpdate()
    {
        if (_heldObject != null)
            return;

        Debug.DrawRay(
            transform.position + new Vector3(0, -1.55f, 0),
            _direction.ToVector2() * 1.5f,
            Color.red
        );

        // Raycast 12px (1.5 units) in front of the transform to determine if there is an object to pickup.
        _foundObject = Physics2D.Raycast(
            transform.position + new Vector3(0, -1.55f, 0),
            _direction.ToVector2(),
            1.5f, _hittableLayers
        );

        _target = _foundObject ? _foundObject.transform.GetComponent<Carriable>() : null;
    }

    public void Carry(Carriable carriable)
    {
        _heldObject = carriable;
        _heldObject.Renderer.sortingOrder = 2;
    }

    public void Drop()
    {
        if (_heldObject == null)
            return;

        _heldObject.Drop();
        _heldObject = null;
    }

    public void SetDirection(Direction direction)
    {
        _direction = direction;
    }

    public void Throw()
    {
        if (_heldObject == null)
            return;

        _heldObject.Collider.enabled = true;
        _heldObject.gameObject.layer = (int)Layers.ThrownObjects;
        _heldObject.Throw(_direction);
        _heldObject = null;
    }
}
