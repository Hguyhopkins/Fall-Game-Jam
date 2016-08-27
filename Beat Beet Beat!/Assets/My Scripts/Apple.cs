using UnityEngine;
using System.Collections;

public class Apple : Enemy
{
    public GameObject player;

    public bool chasing = false;

    private Animator anim;

	// Use this for initialization
	void Start ()
    {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        Move();

        if(!chasing)
        {
            anim.SetInteger("isMoving", 0);
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
}
