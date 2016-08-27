using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyHandler : MonoBehaviour {

    public List<GameObject> enemies;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
	    if (enemies.Count > 0)
        {
            foreach (GameObject enemy in enemies)
            {
                if (enemy.GetComponent<Enemy>().Health <= 0)
                {
                    GameObject.Destroy(enemy);
                }
            }
        }
	}
}
