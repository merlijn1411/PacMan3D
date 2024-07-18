using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovementController : MonoBehaviour
{
	[Header("FPS Attributes")]
	[SerializeField] private Camera playerCamera;
	[SerializeField] private float walkSpeed;
	[SerializeField] private float runSpeed;
	[SerializeField] private float jumpForce;
	[SerializeField] private float grafity;

	[SerializeField] private float sensitivity;
	private const float LookYLimit = 80f;

	[SerializeField] private Vector3 moveDirection = Vector3.zero;
	private float _rotationX = 0;

	[SerializeField] private bool canMove = true;

	private CharacterController _characterController;

	private void Start()
	{
		_characterController = GetComponent<CharacterController>();

		// Cursor.lockState = CursorLockMode.Locked;
		// Cursor.visible = false;
	}

	private void Update()
	{
		#region Handles Movement
		var forward = transform.TransformDirection(Vector3.forward);
		var right = transform.TransformDirection(Vector3.right);

		//To Run with Left-Shift

		var isRunning = false;

		var curSpeedX = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Vertical") : 0;
		var curSpeedY = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Horizontal") : 0;

		var movementDirectionY = moveDirection.y;
		moveDirection = (forward * curSpeedX) + (right * curSpeedY);

		#endregion

		#region Handles Jumping
			if (Input.GetButton("Jump") && canMove && _characterController.isGrounded)
			{
				moveDirection.y = jumpForce;
			}
			else
			{
				moveDirection.y = movementDirectionY;
			}

			if (!_characterController.isGrounded)
			{
				moveDirection.y -= grafity * Time.deltaTime;
			}
		#endregion


		#region Handles Roation

		_characterController.Move(moveDirection * Time.deltaTime);

		if (canMove)
		{
			_rotationX += -Input.GetAxis("Mouse Y") * sensitivity;
			_rotationX = Mathf.Clamp(_rotationX, -LookYLimit, LookYLimit);
			playerCamera.transform.localRotation = Quaternion.Euler(_rotationX, 0, 0);
			transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * sensitivity, 0);
		}

		#endregion
	}
}
