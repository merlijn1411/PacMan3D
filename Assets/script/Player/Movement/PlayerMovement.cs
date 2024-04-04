using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float groundDrag;

    

    [Header("Ground Check")]
    [SerializeField] private float playerHeight;
    [SerializeField] private LayerMask whatIsGround;
    private bool _isGrounded;

    [SerializeField] private Transform orientation;

    private float _horizontalInput;
    private float _verticalInput;

    private Vector3 _moveDirection;

    private Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.freezeRotation= true;
    }


    private void Update()
    {
        //ground check
        _isGrounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);

        MyInput();
        SpeedControl();

        // handle drag 
        if (_isGrounded)
            _rb.drag = groundDrag;
        else
            _rb.drag = 0;
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }
    private void MyInput()
    {
        _horizontalInput = Input.GetAxisRaw("Horizontal");
        _verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void MovePlayer()
    {
        //calculeert de beweging directie
        _moveDirection = orientation.forward * _verticalInput + orientation.right * _horizontalInput;

            _rb.AddForce(_moveDirection.normalized * (moveSpeed * 10f), ForceMode.Force);

        
    }

    private void SpeedControl()
    {
        var velocity = _rb.velocity;
        Vector3 flatVel = new Vector3(velocity.x, 0f, velocity.z);

        //limiet van velocity als we dat nodig hebben 
        if(flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            _rb.velocity = new Vector3(limitedVel.x, _rb.velocity.y, limitedVel.z);
        }
    }
    


}
