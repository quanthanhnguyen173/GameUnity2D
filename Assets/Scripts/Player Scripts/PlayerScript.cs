using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{

    public float moveForce = 20f;
    public float jumpForce = 150f;
    public float maxVelocity = 4f;

    private bool grounded;
    private int countplayer;
    

    private Rigidbody2D myBody;
    private Animator anim;

    public static bool Music = false;

    private bool moveLeft, moveRight;

    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        GameObject.Find("JumpButton").GetComponent<Button>().onClick.AddListener(() => Jump());

    }

    public void SetMoveLeft(bool moveLeft)
    {
        this.moveLeft = moveLeft;
        this.moveRight = !moveLeft;
    }

    public void StopMoving()
    {
        this.moveLeft = false;
        this.moveRight = false;
    }


    // Use this for initialization
    void Start()
    {
        countplayer = 5;
    }

    void Update()
    {
        if (countplayer != GameplayController.player)
        {
            //Jump();
            myBody.AddForce(new Vector2(0, jumpForce));
            countplayer--;
        }
    }

        // Update is called once per frame
        void FixedUpdate()
    {
        PlayerWalkJoyStick();
        //PlayerWalkKeyBoard();

    }


    void PlayerWalkKeyBoard()
    {
        float forceX = 0f;
        float forceY = 0f;

        float vel = Mathf.Abs(myBody.velocity.x);

        float h = Input.GetAxisRaw("Horizontal"); //-1 0 1

        if (h > 0)
        {
            if (vel < maxVelocity)
            {
                if (grounded)
                {
                    forceX = moveForce;
                }
                else
                {
                    forceX = moveForce * 1.6f;
                    

                }
            }

            Vector3 scale = transform.localScale;
            scale.x = 1.6f;
            transform.localScale = scale;

            anim.SetBool("Walk", true);

        }
        else if (h < 0){
            if (vel < maxVelocity)
            {
                if (grounded)
                {
                    forceX = -moveForce;
                }
                else
                {
                    forceX = -moveForce * 1.6f;   
                }
            }

            Vector3 scale = transform.localScale;
            scale.x = -1.6f;
            transform.localScale = scale;

            anim.SetBool("Walk", true);

        }
        else if (h == 0)
        {
            anim.SetBool("Walk", false);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            if (grounded)
            {
                grounded = false;
                forceY = jumpForce;
                SoundController.PlaySound(soundsGame.jump);
            }
        }


        myBody.AddForce(new Vector2(forceX, forceY));
    }


    void PlayerWalkJoyStick()
    {
        float forceX = 0f;
        float vel = Mathf.Abs(myBody.velocity.x);

        if (moveRight)
        {

            if (vel < maxVelocity)
            {
                if (grounded)
                {
                    forceX = moveForce;
                }
                else
                {
                    forceX = moveForce * 1.6f;
                }
            }

            Vector3 scale = transform.localScale;
            scale.x = 1.6f;
            transform.localScale = scale;

            anim.SetBool("Walk", true);

        }
        else if (moveLeft)
        {

            if (vel < maxVelocity)
            {
                if (grounded)
                {
                    forceX = -moveForce;
                }
                else
                {
                    forceX = -moveForce * 1.6f;
                }
            }

            Vector3 scale = transform.localScale;
            scale.x = -1.6f;
            transform.localScale = scale;

            anim.SetBool("Walk", true);

        }
        else
        {
            anim.SetBool("Walk", false);
        }

        myBody.AddForce(new Vector2(forceX, 0));

    }

    void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }


    public void Jump()
    {
        if (grounded)
        {
            grounded = false;
            myBody.AddForce(new Vector2(0, jumpForce));
            SoundController.PlaySound(soundsGame.jump);

        }
    }

    public void BouncePlayerWithBouncy(float force)
    {
        if (grounded)
        {
            grounded = false;
            myBody.AddForce(new Vector2(0, force));
        }
    }
}
