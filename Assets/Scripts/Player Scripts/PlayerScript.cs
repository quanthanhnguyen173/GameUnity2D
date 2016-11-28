using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour
{

    public float moveForce = 20f;
    public float jumpForce = 400f;
    public float maxVelocity = 4f;

    private bool grounded;

    private Rigidbody2D myBody;
    private Animator anim;

    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        PlayerWalkKeyBoard();

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
                    forceX = moveForce * 1.1f;
                }
            }

            Vector3 scale = transform.localScale;
            scale.x = 1f;
            transform.localScale = scale;

            anim.SetBool("Walk", true);
        }else if (h < 0){
            if (vel < maxVelocity)
            {
                if (grounded)
                {
                    forceX = -moveForce;
                }
                else
                {
                    forceX = -moveForce * 1.1f;
                }
            }

            Vector3 scale = transform.localScale;
            scale.x = -1f;
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
            }
        }


        myBody.AddForce(new Vector2(forceX, forceY));




    }

    void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }


}
