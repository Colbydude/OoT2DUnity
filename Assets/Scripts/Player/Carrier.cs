using UnityEngine;

[RequireComponent(typeof(Actor))]
public class Carrier : MonoBehaviour
{
    [SerializeField] private Transform _carryPosition;
    [SerializeField] private LayerMask _hittableLayers;

    private RaycastHit2D _foundObject;
    private Carriable _heldObject;
    private Carriable _target;

    public Transform CarryPosition => _carryPosition;
    public Carriable HeldObject => _heldObject;
    public Carriable Target => _target;

    public Actor Actor { get; private set; }

    private void Awake()
    {
        Actor = GetComponent<Actor>();
    }

    private void FixedUpdate()
    {
        if (_heldObject != null)
            return;

        Debug.DrawRay(
            transform.position + new Vector3(0, -1.55f, 0),
            Actor.Direction.ToVector2() * 1.5f,
            Color.red
        );

        // Raycast 12px (1.5 units) in front of the transform to determine if there is an object to pickup.
        _foundObject = Physics2D.Raycast(
            transform.position + new Vector3(0, -1.55f, 0),
            Actor.Direction.ToVector2(),
            1.5f, _hittableLayers
        );

        _target = _foundObject ? _foundObject.transform.GetComponent<Carriable>() : null;
    }

    private void LateUpdate()
    {
        // Move the held object.
        if (_heldObject != null)
        {
            _heldObject.transform.position = (Vector2)_carryPosition.transform.position - _heldObject.CarryOffset;
            return;
        }
    }

    /// <summary>
    /// Set the given carriable object as held.
    /// </summary>
    public void Carry(Carriable carriable)
    {
        _heldObject = carriable;
        _heldObject.Renderer.sortingOrder = 2;
    }

    /// <summary>
    /// Drop the held object.
    /// </summary>
    public void Drop()
    {
        if (_heldObject == null)
            return;

        _heldObject.Drop();
        _heldObject = null;
    }

    /// <summary>
    /// Throw the held object in the direction the actor is facing.
    /// </summary>
    public void Throw()
    {
        if (_heldObject == null)
            return;

        _heldObject.Collider.enabled = true;
        _heldObject.gameObject.layer = (int)Layer.ThrownObjects;
        _heldObject.Throw(Actor.Direction);
        _heldObject = null;
    }
}
