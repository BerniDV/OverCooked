using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinCondition : MonoBehaviour
{

    public int pointsToWin;
    private int currentPoints;
    public Text points;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        string pointsString = points.text.ToString();

        string[] palabras = pointsString.Split(' ');

        string pointsSplit = palabras[0];

        int.TryParse(pointsSplit, out currentPoints);

        if (currentPoints >= pointsToWin)
        {

            SceneManager.LoadScene("WinMenu");
        }

        
    }

    int buscarIndice(string frase)
    {

        int indice = 0;

        for (int i = 0; i < frase.Length; i++)
        {

            if (frase[i] == ' ')
            {

                return i;
            }
        }

        return indice;
    }
}
