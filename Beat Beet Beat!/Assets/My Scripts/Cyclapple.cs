using UnityEngine;
using System.Collections;

public class Cyclapple : Enemy {

    public GameObject player;

    private Animator anim;
    private float timer;
    private float timeToAttack = 0.75f;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
	    if (anim.GetBool("isTalking") == false)
        {
            if (Input.GetKeyDown(KeyCode.Q))
                anim.SetBool("isTalking", true);
        }
        else if (anim.GetBool("readyToFight") == false)
        {
            if (Input.GetKeyDown(KeyCode.Q))
                anim.SetBool("readyToFight", true);
        }
        else
        {
            //if (Physics2D.Raycast(transform.position, transform.right))
            //{

            //}
            Debug.Log(player.transform.position.x - transform.position.x);
            if (player.transform.position.x - transform.position.x > 0)
            {
                if (anim.GetInteger("isMoving") != 2)
                {
                    anim.SetInteger("isMoving", 2);
                }
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(player.transform.position.x, 0.1f), 0.02f);
                if (timer > timeToAttack)
                {
                    GameObject seed = GameObject.Instantiate(Resources.Load("Apple Seed"), transform.position, Quaternion.identity) as GameObject;
                    seed.transform.position = new Vector2(transform.position.x, 0.2f);
                    seed.GetComponent<Rigidbody2D>().velocity = new Vector2(20, 0);
                    seed.transform.Rotate(seed.transform.forward * 90);
                    timer = 0;
                }
            }
            else if (player.transform.position.x - transform.position.x < 0)
            {
                if (anim.GetInteger("isMoving") != 1)
                {
                    anim.SetInteger("isMoving", 1);
                }
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(player.transform.position.x, 0.1f), 0.02f);
                if (timer > timeToAttack)
                {
                    GameObject seed = GameObject.Instantiate(Resources.Load("Apple Seed"), transform.position, Quaternion.identity) as GameObject;
                    seed.transform.Rotate(seed.transform.forward * -90);
                    seed.transform.position = new Vector2(transform.position.x, 0.2f);
                    seed.GetComponent<Rigidbody2D>().velocity = new Vector2(-20, 0);
                    timer = 0;
                }
            }
            else if (anim.GetInteger("isMoving") != 0)
            {
                anim.SetInteger("isMoving", 0);
            }
        }
    }

    public void Attack()
    {

    }
}
