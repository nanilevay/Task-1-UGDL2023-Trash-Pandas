using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float horizontalSpeed;
    [SerializeField] private float jumpSpeed;
    
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private bool onGround;
    [SerializeField] private float maxJumpTime;

    [SerializeField] private float fallGravityScale;

    private Recorder recorder;

    float hAxis;
    private Rigidbody2D rb;

    private float jumpTime;

    Vector3 currentVelocity;

    private void Awake()
    {
        recorder = GetComponent<Recorder>();
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        hAxis = Input.GetAxis("Horizontal");

        onGround = IsOnGround();
        currentVelocity = rb.velocity;
        currentVelocity.x = hAxis * horizontalSpeed;

        Jump();

        rb.velocity = currentVelocity;

        Move();
    }

    private void LateUpdate()
    {
        ReplayData data = new ReplayData(this.transform.position);
        recorder.RecordReplayFrame(data);
    }

    private void Move()
    {
        if (currentVelocity.x > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (currentVelocity.x < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (onGround)
            {
                rb.gravityScale = 1.0f;
                currentVelocity.y = jumpSpeed;
                jumpTime = Time.time;
            }
        }
        else if (Input.GetButton("Jump"))
        {
            float elapsedTime = Time.time - jumpTime;
            if (elapsedTime > maxJumpTime)
            {
                rb.gravityScale = fallGravityScale;
            }
        }
        else
        {
            rb.gravityScale = fallGravityScale;
        }

    }
    private bool IsOnGround()
    {
        var collider = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundMask);

        return (collider != null);
    }
}
