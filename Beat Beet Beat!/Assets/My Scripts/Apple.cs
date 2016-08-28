using UnityEngine;
using System.Collections;

public class Apple : Enemy
{
    public GameObject player;

    public bool chasing = false;
    public bool whack = false;

    private Animator anim;
    private SpriteRenderer rend;

	// Use this for initialization
	void Start ()
    {
        anim = GetComponent<Animator>();
        rend = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        Move();

        if(!chasing)
        {
            anim.SetInteger("isMoving", 0);
        }

        if(player.GetComponent<PlayerController>().isAttacking && whack)
        {
            gameObject.SetActive(false);
        }
	}

    public override void Move()
    {
        if(chasing)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(player.transform.position.x, 0.1f), 0.02f);

            if(player.transform.position.x - transform.position.x >= 0)
            {
                anim.SetInteger("isMoving", 1);
            }

            else if(player.transform.position.x - transform.position.x <= 0)
            {
                anim.SetInteger("isMoving", 2);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            chasing = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            chasing = false;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            whack = true;
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            whack = false;
        }
    }
}
