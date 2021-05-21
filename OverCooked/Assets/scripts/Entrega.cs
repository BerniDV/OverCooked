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

    public string recetaEntregada;


    // Start is called before the first frame update
    void Start()
    {
        points = 0;
    }

    // Update is called once per frame
    void Update()
    {

        displayPoints();

        referenciarAComida();

        entregarComida();

        if (points == 3)
        {

            SceneManager.LoadScene(0);
        }
    }

    private void displayPoints()
    {

        PointsText.text = string.Format("{0} points", points);
    }

    private void referenciarAComida()
    {
        if (objetoEntregado != null)
        {


            if(objetoEntregado.tag == "plato")
            {

                objetoEntregado = objetoEntregado.GetComponentInParent<ComidaEnPlato>().ObjectPicked;

            }

        }


    }

    private void entregarComida()
    {

        if (objetoEntregado != null && objetoEntregado.tag == "ingrediente" && objetoEntregado.GetComponentInParent<receta>().algunaRecetaCompletada)
        {
            int puntosSuma = 0;

            if (objetoEntregado.GetComponentInParent<Atributos>().nombre == "pan")
            {

                puntosSuma = objetoEntregado.GetComponentInParent<recetaHamburguesa>().puntosReceta;
                recetaEntregada = objetoEntregado.GetComponentInParent<recetaHamburguesa>().tipoReceta;
            }

            actualizarPuntos(puntosSuma);
            Object.Destroy(objetoEntregado);
        }
    }

    private void actualizarPuntos(int puntosSuma)
    {

        points += puntosSuma;

    }

}
