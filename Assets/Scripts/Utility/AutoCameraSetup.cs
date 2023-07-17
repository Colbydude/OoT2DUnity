using Cinemachine;
using UnityEngine;

[RequireComponent(typeof(CinemachineVirtualCamera))]
public class AutoCameraSetup : MonoBehaviour
{
    [SerializeField] private bool _autoSetupCameraFollow = true;
    [SerializeField] private string _cameraFollowGameObjectName = "Player";

    void Awake()
    {
        if (!_autoSetupCameraFollow)
            return;

        CinemachineVirtualCamera cam = GetComponent<CinemachineVirtualCamera>();

        if (cam == null)
            throw new UnityException("Virtual Camera was not found, default follow cannot be assigned.");

        // We manually do a "find", because otherwise, GameObject.Find seems to return
        // an object from a "preview scene" breaking the camera as the object is not the right one.
        GameObject[] rootObj = gameObject.scene.GetRootGameObjects();
        GameObject cameraFollowGameObject = null;

        foreach (GameObject go in rootObj)
        {
            if (go.name == _cameraFollowGameObjectName)
                cameraFollowGameObject = go;
            else
            {
                Transform t = go.transform.Find(_cameraFollowGameObjectName);

                if (t != null)
                    cameraFollowGameObject = t.gameObject;
            }

            if (cameraFollowGameObject != null)
                break;
        }

        if (cameraFollowGameObject == null)
            throw new UnityException($"GameObject called {_cameraFollowGameObjectName} was not found, default follow cannot be assigned.");

        if (cam.Follow == null)
            cam.Follow = cameraFollowGameObject.transform;
    }
}
