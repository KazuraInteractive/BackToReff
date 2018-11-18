using UnityEngine;
using System.Collections;

public class Character : Unit
{
    [SerializeField]
    public int lives = 3;

    public AudioSource uro,jump;

    public int Lives
    {
        get { return lives; }
        set
        {
           if (value < 3) lives = value;
            livesBar.Refresh();
        }
    }
    private LivesBar livesBar;

    [SerializeField]
    private float playerSpeed = 3.0F;
    [SerializeField]
    private float jumpPower = 15.0F;

    private bool groundCheck = false;
    public int directionInput;
    public bool facingRight = true;

    public LevelManager levelManager;

    private Rigidbody2D rb2d;

    public void liveadd()
    {
        lives++;
        livesBar.Refresh();
        Debug.Log(lives);
    }

    private void Awake()
    {
        livesBar = FindObjectOfType<LivesBar>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        CheckGround();
        rb2d.velocity = new Vector2(playerSpeed * directionInput, rb2d.velocity.y);
    }

    void Update()
    {
        if ((directionInput < 0) && (facingRight))
        {
            Flip();
        }

        if ((directionInput > 0) && (!facingRight))
        {
            Flip();
        }
        groundCheck = true;

    }

    public void Run(int dir)
    {
        directionInput = dir;
    }

    public void Jump(bool isJump)
    {
        isJump = groundCheck;

        if (groundCheck)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpPower);
            jump.Play();
        }
    }

    public override void ReceiveDamage()
    {
        Lives--;
        uro.Play();

        rb2d.velocity = Vector3.zero;
        rb2d.AddForce(transform.up * 10.0F, ForceMode2D.Impulse);

        Debug.Log(lives);

        if (lives <= 0)
        {
            levelManager.RespawnPlayer();
            lives = 3;
            livesBar.Refresh();
        }
    }

    private void CheckGround()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.3F);

        groundCheck = colliders.Length > 1;
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}