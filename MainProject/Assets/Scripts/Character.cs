using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class Character : Unit
{
    public int lives = 3;
    public AudioSource uro, death;

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
    [SerializeField]
    public Image jum;

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
        jum.color = Color.Lerp(jum.color, Color.clear, 0.4f * Time.deltaTime);

        if (jum.color.a <= 0.01f)
        {
            jum.color = Color.clear;
        }

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
        directionInput = dir;                                        //Определение направления движения и движение
    }

    public void Jump(bool isJump)
    {
        isJump = groundCheck;                                        //Определение нахождения на земле

        if (groundCheck)                                             //Если персонаж на земле
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpPower); //Применить к объекту персонажа толчок вверх
        }
    }

    public override void ReceiveDamage()
    {
        Lives--;                                                   //Вычисление одной жизни
        uro.Play();                                                //Проигрывание музыки получения урона

        rb2d.velocity = Vector3.zero;                              //Определение объекта, отвечающего за физику
        rb2d.AddForce(transform.up * 10.0F, ForceMode2D.Impulse);  //Эффект отброса объекта персонажа в сторону

        if (lives <= 0)                                            //Если жизней меньше, либо равно нулю
        {
            Advertisement.Show();

            death.Play();                                          //Проигрывание звука смерти
            levelManager.RespawnPlayer();                          //Респавн персонажа к последней точке
            lives = 3;                                             //Возврат количества жизней к изначальному значению
            livesBar.Refresh();                                    //Обновление объекта, показывающего количество жизней на экране
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