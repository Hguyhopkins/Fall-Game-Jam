using UnityEngine;
using System.Collections;

public class LimaDog : MonoBehaviour
{
    private Animator anim;

    public GameObject followThing;

    public bool followIt = true;


	// Use this for initialization
	void Start ()
    {
        anim.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
	    
        if(followIt)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(followThing.transform.position.x, transform.position.y), 0.02f);

            anim.SetInteger("isMoving", 1);

            if (transform.position.x < followThing.transform.position.x)
            {
                transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);
            }

            if (transform.position.x > followThing.transform.position.x)
            {
                transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
            }
        }

        if(!followIt)
        {
            anim.SetInteger("isMoving", 0);
        }

	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Ball")
        {
            followIt = false;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Ball")
        {
            followIt = true;
        }
    }
}
