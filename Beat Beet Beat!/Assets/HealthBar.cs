using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

    public GameObject player;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<RectTransform>().sizeDelta = new Vector2(GetComponent<RectTransform>().sizeDelta.x, 120f * (player.GetComponent<PlayerController>().health / 100f));
        //transform.localPosition = new Vector3(transform.localPosition.x, (-130f + 10f * (player.GetComponent<PlayerController>().health / 100f)) / 130f, 0);
	}
}
