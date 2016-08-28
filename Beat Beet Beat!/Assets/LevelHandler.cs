using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelHandler : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoadLevel(string level)
    {
        transform.GetChild(0).GetComponent<Text>().text = "Loading!";
        SceneManager.LoadScene(level);
    }
}
