using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] GameObject target;
    [SerializeField] Camera cam;

    Vector3 camFollowVelocity = Vector3.zero;
    [SerializeField] float camFollowSpeed = 0.5f;
    [SerializeField] Vector3 camOffset = new Vector3();

    private void Awake()
    {
        cam = Camera.main;

        if (GameObject.FindWithTag("Player"))
        {
            target = GameObject.FindWithTag("Player");
        }
        else Debug.LogWarning("You utter disgrace! You have not instantiated a player object! Hope you're proud of yourself");
    }

    private void Update()
    {
        Vector3 targetPosition = Vector3.SmoothDamp(cam.transform.position,
                                                        new Vector3(target.transform.position.x + camOffset.x, target.transform.position.y + camOffset.y, target.transform.position.z + camOffset.z),
                                                            ref camFollowVelocity, camFollowSpeed);
        cam.transform.position = targetPosition;
    }
}
