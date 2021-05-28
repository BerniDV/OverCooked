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

    public GameObject PedidosObject;
    public int nPedidos;

    public string recetaEntregada;


    // Start is called before the first frame update
    void Start()
    {
        

        points = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //en Start no los cogia. posiblemente porque se ejecuta este start antes
        PedidosObject = GameObject.Find("CrearPedidos");
        nPedidos = 4; //Solo hay 4 posibles pedidos.
        //

        if (Input.GetKeyDown("0")) actualizarPuntos(1);

        displayPoints();

        referenciarAComida();

        entregarComida();

        /*if (points == 3) //He puesto que se encargue un script diferente.
        {

            SceneManager.LoadScene(0);
        }*/
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
    /*
    private void entregarComida()
    {
        bool unaSolaEntrega = false;

        if (objetoEntregado != null && objetoEntregado.tag == "ingrediente" && objetoEntregado.GetComponentInParent<receta>().algunaRecetaCompletada)
        {
            for(int i=0; i<nPedidos; ++i)
            {
                if (PedidosObject.GetComponent<CrearPedido>().actividadPedidos[i]) //hay un pedido en el hueco i
                {
                    //if (objetoEntregado.GetComponentInParent<recetaHamburguesa>().tipoReceta == PedidosObject.GetComponent<CrearPedido>().nombrePedidos[i] && !unaSolaEntrega)
                    //{

                        //unaSolaEntrega = true; //Si hubiesen 4 veces la misma receta, se estaria entregando 4 veces y no es así, solo una.

                        int puntosSuma = 0;

                        if (objetoEntregado.GetComponentInParent<Atributos>().nombre == "pan")
                        {

                            puntosSuma = objetoEntregado.GetComponentInParent<recetaHamburguesa>().puntosReceta;
                            recetaEntregada = objetoEntregado.GetComponentInParent<recetaHamburguesa>().tipoReceta;
                        }
                        else
                        {

                            puntosSuma = objetoEntregado.GetComponentInParent<recetaSopa>().puntosReceta;
                            recetaEntregada = objetoEntregado.GetComponentInParent<recetaSopa>().tipoReceta;
                        }

                        actualizarPuntos(puntosSuma);
                        Object.Destroy(objetoEntregado);

                        PedidosObject.GetComponent<CrearPedido>().DestroyPedido(i);
                        
                    //}
                }
            }
        }
    }
    */

    private void entregarComida()
    {
        bool unaSolaEntrega = false;

        if (objetoEntregado != null && objetoEntregado.tag == "ingrediente" && objetoEntregado.GetComponentInParent<receta>().algunaRecetaCompletada)
        {
            for (int i = 0; i < nPedidos; ++i)
            {
                if (PedidosObject.GetComponent<CrearPedido>().actividadPedidos[i]) //hay un pedido en el hueco i
                {
                    //if (objetoEntregado.GetComponentInParent<recetaHamburguesa>().tipoReceta == PedidosObject.GetComponent<CrearPedido>().nombrePedidos[i] && !unaSolaEntrega)
                    //{

                    //unaSolaEntrega = true; //Si hubiesen 4 veces la misma receta, se estaria entregando 4 veces y no es así, solo una.

                    int puntosSuma = 0;

                    if (objetoEntregado.GetComponentInParent<Atributos>().nombre == "pan")
                    {

                        puntosSuma = objetoEntregado.GetComponentInParent<recetaHamburguesa>().puntosReceta;
                        recetaEntregada = objetoEntregado.GetComponentInParent<recetaHamburguesa>().tipoReceta;
                    }
                    else if (objetoEntregado.GetComponentInParent<Atributos>().nombre == "hotDog" || objetoEntregado.GetComponentInParent<Atributos>().nombre == "hotDogConQuetxup")
                    {

                        puntosSuma = objetoEntregado.GetComponentInParent<recetaHotdog>().puntosReceta;
                        recetaEntregada = objetoEntregado.GetComponentInParent<recetaHotdog>().tipoReceta;

                    }
                    else
                    {

                        puntosSuma = objetoEntregado.GetComponentInParent<recetaSopa>().puntosReceta;
                        recetaEntregada = objetoEntregado.GetComponentInParent<recetaSopa>().tipoReceta;
                    }

                    if (recetaEntregada == PedidosObject.GetComponent<CrearPedido>().nombrePedidos[i] && !unaSolaEntrega)
                    {
                        actualizarPuntos(puntosSuma);
                        Object.Destroy(objetoEntregado);

                        unaSolaEntrega = true;

                        PedidosObject.GetComponent<CrearPedido>().DestroyPedido(i);
                    }

                    //}
                }
            }
        }

        //Reinicializamos recetaEntregada a null
        recetaEntregada = null;
        //recetaEntregada = ""; 
    }


    public void actualizarPuntos(int puntosSuma)
    {

        points += puntosSuma;

    }

}
