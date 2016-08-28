using UnityEngine;
using System.Collections;

public class SeedScript : MonoBehaviour {

    private float timer;
    private float timeToPoof = 2.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if (timer > timeToPoof)
        {
            Destroy(this.gameObject);
        }
        else
        {
            timer += Time.deltaTime;
        }
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            coll.gameObject.GetComponent<PlayerController>().health -= 10;
            Destroy(this.gameObject);
        }
        else if (!coll.gameObject.CompareTag("Boss"))
        {
            Destroy(this.gameObject);
        }
    }
}
