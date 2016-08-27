using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float speed;

    private Rigidbody2D rb;
    private bool isJumping = false;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();

	}
	
	// Update is called once per frame
	void Update () {
        
        float hor = Input.GetAxisRaw("Horizontal");
        if (!isJumping && GetComponent<Rigidbody2D>().velocity.y < 1 && Input.GetAxisRaw("Vertical") > 0)
        { 
            GetComponent<Rigidbody2D>().AddForce(transform.up * 750);
            isJumping = true;
        }
        transform.Translate(hor * speed * Time.deltaTime, 0, 0);
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.transform.CompareTag("Floor"))
        {
            Debug.Log("CRANBERRIES");
            isJumping = false;
        }
    }
}
