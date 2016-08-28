using UnityEngine;
using System.Collections;

public class Artichoke : Enemy
{

    private Animator anim;
    public GameObject player;

    public bool chasing = false;

	// Use this for initialization
	void Start ()
    {

        anim = GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void Update ()
    {
        Move(); 
	}

    public override void Move()
    {
        //if (chasing)
        //{
            if ((player.transform.position.x - transform.position.x > 0)){
                transform.Translate(3 * Time.deltaTime, 0, 0);
            }
            else if ((player.transform.position.x - transform.position.x < 0))
            {
                transform.Translate(-3 * Time.deltaTime, 0, 0);
            Debug.Log("DERP");
            }
        //}
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            chasing = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            chasing = false;
        }
    }

}
