using UnityEngine;
using System.Collections;

public class FollowMe : MonoBehaviour
{

    public GameObject player;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(player.GetComponent<PlayerController>().isLeft)
        {
            transform.position = new Vector2(player.transform.position.x + 1f, transform.position.y);
        }

       else if (player.GetComponent<PlayerController>().isRight)
        {
            transform.position = new Vector2(player.transform.position.x - 1f, transform.position.y);
        }
    }
}
