using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PasarLevel01 : MonoBehaviour
{
    GameObject objectPoints;
    GameObject objectTime;

    // Start is called before the first frame update
    void Start()
    {
        objectPoints = GameObject.FindWithTag("entrega");
        objectTime = GameObject.FindWithTag("Time");

    }

    // Update is called once per frame
    void Update()
    {
        if(objectPoints.GetComponent<Entrega>().points > 0)
        {
            SceneManager.LoadScene("Level1");
        }
    }
}
