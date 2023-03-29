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


    [SerializeField] private bool deathThisFrame = false;
    private bool disableMovement = false;

    [SerializeField] private float fallGravityScale;


    private BoxCollider2D coll;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private bool facingRight = true;

    private Recorder recorder;

    float hAxis;

    private float jumpTime;

    Vector3 currentVelocity;

    private void Awake()
    {
        recorder = GetComponent<Recorder>();
        sr = GetComponentInChildren<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // subscribe to events
        GameEventsManager.instance.onGoalReached += OnGoalReached;
    }

    private void OnDestroy()
    {
        // unsubscribe from events
        GameEventsManager.instance.onGoalReached -= OnGoalReached;
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
        // record replay data for this frame
        ReplayData data = new PlayerReplayData(this.transform.position, onGround,
            rb.velocity, sr.color.a, facingRight, deathThisFrame);
        recorder.RecordReplayFrame(data);
        deathThisFrame = false;
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

    private IEnumerator HandleDeath()
    {
        // freeze player movemet
        rb.gravityScale = 0;
        disableMovement = true;
        rb.velocity = Vector3.zero;
        // prevent other collisions
        coll.enabled = false;
        // hide the player visual
        sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 0);
        // keep track of when the player died for replay
        deathThisFrame = true;

        yield return new WaitForSeconds(0.4f);

        // start a new recording for the replay on every respawn
        recorder.StartNewRecording();
    }
    private void OnGoalReached()
    {
        // freeze movement
        rb.gravityScale = 0;
        rb.velocity = Vector3.zero;
        disableMovement = true;
        // hide player visual
        sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 0);
    }
}