using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{

    public float health = 100;

	// Use this for initialization
	void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public float Health
    {
        get { return health; }
        set { health = value; }
    }

    public virtual void Move()
    {

    }


}
