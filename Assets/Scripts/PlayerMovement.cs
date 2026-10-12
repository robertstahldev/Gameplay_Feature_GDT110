using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpHeight = 2f;
    [SerializeField] private float gravity = -9.81f;

    [Header("Camera Movement")]
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private float turnSpeed = 10f;

    private CharacterController controller;
    private Vector3 verticalVelocity;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        //Get the camera's forward and right directions.
        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        //Ignore the camera's vertical angle.
        forward.y = 0f;
        right.y = 0f;

        forward.Normalize();
        right.Normalize();

        //Move relative to the camera.
        Vector3 moveDirection = forward * vertical + right * horizontal;
        moveDirection = Vector3.ClampMagnitude(moveDirection, 1f);

        //Rotate the player toward the movement direction.
        if (moveDirection.sqrMagnitude > 0.01f)
        {
            Quaternion targetRotation =
                Quaternion.LookRotation(moveDirection);

            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                targetRotation,
                turnSpeed * Time.deltaTime
            );
        }

        bool grounded = controller.isGrounded;

        if (grounded && verticalVelocity.y < 0f)
        {
            verticalVelocity.y = -2f;
        }

        if (Input.GetButtonDown("Jump") && grounded)
        {
            verticalVelocity.y = Mathf.Sqrt(
                jumpHeight * -2f * gravity
            );
        }

        verticalVelocity.y += gravity * Time.deltaTime;

        //Combine horizontal and vertical movement.
        Vector3 movement =
            moveDirection * moveSpeed + verticalVelocity;

        CollisionFlags flags =
            controller.Move(movement * Time.deltaTime);

        //Check whether the movement hit the ground.
        if ((flags & CollisionFlags.Below) != 0 &&
            verticalVelocity.y < 0f)
        {
            verticalVelocity.y = -2f;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log($"Space pressed. Grounded: {grounded}");
        }
    }
}