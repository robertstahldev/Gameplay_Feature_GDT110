using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Target")]
    [SerializeField] private Transform target;

    [Header("Follow Settings")]
    [SerializeField] private float followSpeed = 8f;
    [SerializeField] private float heightOffset = 1.5f;

    [Header("Zoom Settings")]
    [SerializeField] private float distance = 7f;
    [SerializeField] private float minDistance = 3f;
    [SerializeField] private float maxDistance = 15f;
    [SerializeField] private float zoomSpeed = 3f;

    [Header("Rotation Settings")]
    [SerializeField] private float rotationSpeed = 400f;
    [SerializeField] private float yaw = 0f;
    [SerializeField] private float pitch = 25f;

    private void LateUpdate()
    {
        if (target == null) return;

        //Zoom with mouse wheel.
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        distance -= scroll * zoomSpeed;
        distance = Mathf.Clamp(
            distance, minDistance, maxDistance
        );

        //Rotate camera while holding right mouse button.
        if (Input.GetMouseButton(1))
        {
            yaw += Input.GetAxis("Mouse X") *
                   rotationSpeed * Time.deltaTime;

            pitch -= Input.GetAxis("Mouse Y") *
                     rotationSpeed * Time.deltaTime;

            pitch = Mathf.Clamp(pitch, 10f, 75f);
        }

        //Calculate camera position around the player.
        Quaternion rotation = Quaternion.Euler(
            pitch, yaw, 0f
        );

        Vector3 targetPosition =
            target.position + Vector3.up * heightOffset;

        Vector3 desiredPosition =
            targetPosition +
            rotation * new Vector3(0f, 0f, -distance);

        //Smooth camera movement.
        transform.position = Vector3.Lerp(
            transform.position,
            desiredPosition,
            followSpeed * Time.deltaTime
        );

        //Always look at the player.
        transform.LookAt(targetPosition);
    }
}