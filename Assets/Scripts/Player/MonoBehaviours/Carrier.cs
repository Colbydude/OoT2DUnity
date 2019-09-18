using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class Carrier : MonoBehaviour
{
    public LayerMask hittableLayers;

    protected PlayerController m_PlayerController;

    private RaycastHit2D foundObject;

    void Awake()
    {
        m_PlayerController = GetComponent<PlayerController>();
    }

    void FixedUpdate()
    {
        if (m_PlayerController.HeldObject != null) {
            return;
        }

        Debug.DrawRay(
            transform.position + new Vector3(0, -1.55f, 0),
            m_PlayerController.GetDirectionVector() * 1.5f,
            Color.red
        );

        // Raycast 12px (1.5 units) in front of Link to determine if there is an object to pickup.
        foundObject = Physics2D.Raycast(
            transform.position + new Vector3(0, -1.55f, 0),
            m_PlayerController.GetDirectionVector(),
            1.5f, hittableLayers
        );

        if (foundObject) {
            Carriable carriable = foundObject.transform.GetComponent<Carriable>();

            if (carriable) {
                m_PlayerController.CarriableTarget = carriable;
            } else {
                carriable = null;
            }
        } else {
            m_PlayerController.CarriableTarget = null;
        }
    }
}
