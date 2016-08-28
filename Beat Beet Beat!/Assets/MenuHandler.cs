using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuHandler : MonoBehaviour
{
    public GameObject[] menu1;
    public GameObject[] menu2;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SwapMenu()
    {
        foreach (GameObject i in menu1)
        {
            i.SetActive(false);
        }
        foreach (GameObject i in menu2)
        {
            i.SetActive(true);
        }
    }
}
