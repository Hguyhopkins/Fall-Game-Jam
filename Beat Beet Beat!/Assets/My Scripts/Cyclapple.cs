using UnityEngine;
using System.Collections;

public class Cyclapple : MonoBehaviour {

    public GameObject player;

    private Animator anim;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
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
            Debug.Log(player.transform.position.x - transform.position.x);
            if (player.transform.position.x - transform.position.x > 0)
            {
                if (anim.GetInteger("isMoving") != 2)
                {
                    anim.SetInteger("isMoving", 2);
                }
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(player.transform.position.x, 0.1f), 0.02f);
            }
            else if (player.transform.position.x - transform.position.x < 0)
            {
                if (anim.GetInteger("isMoving") != 1)
                {
                    anim.SetInteger("isMoving", 1);
                }
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(player.transform.position.x, 0.1f), 0.02f);
            }
            else if (anim.GetInteger("isMoving") != 0)
            {
                anim.SetInteger("isMoving", 0);
            }
        }
    }
}
