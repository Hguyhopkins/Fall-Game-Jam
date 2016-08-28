using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public float speed;

    private Rigidbody2D rb;
    private bool isJumping = false;

    public bool isLeft, isRight;

    public bool left = false;
    public bool right = false;

    public bool swinging = false;
    public bool isAttacking = false;

    private Animator anim;

	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody2D>();

        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        
        float hor = Input.GetAxisRaw("Horizontal");
        if (!isJumping && GetComponent<Rigidbody2D>().velocity.y < 1 && Input.GetAxisRaw("Vertical") > 0)
        { 
            GetComponent<Rigidbody2D>().AddForce(transform.up * 250);
            isJumping = true;
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) //left
        {
            anim.SetInteger("isMoving", 2);
            isLeft = true;
            isRight = false;

            left = true;
            right = false;
            
        }

        else if ((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))) //right
        {
            anim.SetInteger("isMoving", 1);
            isRight = true;
            isLeft = false;

            left = false;
            right = true;
        }

        else
        {
            anim.SetInteger("isMoving", 0);
        }

        transform.Translate(hor * speed * Time.deltaTime, 0, 0);

        if(Input.GetMouseButton(0))
        {
            swinging = true;
        }
        else
        {
            swinging = false;
        }

        if(!swinging)
        {
            anim.SetBool("attackLeft", false);
            anim.SetBool("attackRight", false);
            isAttacking = false;
        }

        if (Input.GetMouseButton(0) && left)
        {
            anim.SetBool("attackLeft", true);
            isAttacking = true;
        }

        if (Input.GetMouseButton(0) && right)
        {
            anim.SetBool("attackRight", true);
            isAttacking = true;
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.transform.CompareTag("Floor"))
        {
            isJumping = false;
        }
    }
}
