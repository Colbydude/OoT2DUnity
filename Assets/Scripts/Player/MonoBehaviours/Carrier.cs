using UnityEngine;

public class Carrier : MonoBehaviour
{
    public Carriable target;
    public LayerMask hittableLayers;

    PlayerController playerController;
    RaycastHit2D foundObject;

    void Awake()
    {
        playerController = GetComponent<PlayerController>();
    }

    void FixedUpdate()
    {
        Debug.DrawRay(
            transform.position + new Vector3(0, -1.55f, 0),
            playerController.GetDirectionVector() * 1.5f,
            Color.red
        );

        foundObject = Physics2D.Raycast(
            transform.position + new Vector3(0, -1.55f, 0),
            playerController.GetDirectionVector(),
            1.5f, hittableLayers
        );

        if (foundObject) {
            Carriable carriable = foundObject.transform.GetComponent<Carriable>();

            if (carriable) {
                target = carriable;
            } else {
                carriable = null;
            }
        } else {
            target = null;
        }
    }
}
