using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Entrega : MonoBehaviour
{

    public Text PointsText;
    public int points;
    public GameObject objetoEntregado;


    // Start is called before the first frame update
    void Start()
    {
        points = 0;
    }

    // Update is called once per frame
    void Update()
    {

        displayPoints();

        if (objetoEntregado != null && objetoEntregado.tag == "ingrediente")
        {

            ++points;
            Object.Destroy(objetoEntregado);
        }

        if (points == 3)
        {

            SceneManager.LoadScene(0);
        }
    }

    private void displayPoints()
    {

        PointsText.text = string.Format("{0} points", points);
    }

}
