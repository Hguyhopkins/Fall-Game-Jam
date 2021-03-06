﻿using UnityEngine;
using System.Collections;

public class FruitFly : Enemy
{
    public GameObject player;

    public bool chasing = false;
    public bool whack = false;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        Move();

        if (player.GetComponent<PlayerController>().isAttacking && whack)
        {
            gameObject.SetActive(false);
        }
    }

    public override void Move()
    {
        if(chasing)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(player.transform.position.x, player.transform.position.y), 0.02f);
        }
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

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            whack = true;
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            whack = false;
        }
    }
}
