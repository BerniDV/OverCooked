using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PasarLevel : MonoBehaviour
{
    GameObject objectPoints;
    //GameObject objectTime;

    public string nextLevel;
    public int puntosParaFinalizarLevel;

    // Start is called before the first frame update
    void Start()
    {
        objectPoints = GameObject.FindWithTag("entrega");
        //objectTime = GameObject.FindWithTag("Time");
        puntosParaFinalizarLevel = 20;
    }

    // Update is called once per frame
    void Update()
    {
        if(objectPoints.GetComponent<Entrega>().points > puntosParaFinalizarLevel)
        {
            SceneManager.LoadScene(nextLevel);
        }
    }
}
