using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public float speed;

    private Rigidbody2D rb;
    private bool isJumping = false;

    public bool isLeft, isRight;

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
        }

        else if ((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))) //right
        {
            anim.SetInteger("isMoving", 1);
            isRight = true;
            isLeft = false;
        }

        else
        {
            anim.SetInteger("isMoving", 0);
        }

        transform.Translate(hor * speed * Time.deltaTime, 0, 0);
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.transform.CompareTag("Floor"))
        {
            isJumping = false;
        }
    }
}
