using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class recetaSopa : MonoBehaviour
{
    //public Transform LocationArroz;
    //public GameObject arrozPicked;


    public string tipoReceta;
    public int puntosReceta;


    public bool RecetaSopaArrozCompleta;


    // Start is called before the first frame update
    void Start()
    {

        RecetaSopaArrozCompleta = false;

    }

    // Update is called once per frame
    void Update()
    {

        if (this.GetComponentInParent<EstadoIngrediente>().EstaHervido)
        {

            RecetaSopaArrozCompleta = true;

            this.GetComponentInParent<receta>().algunaRecetaCompletada = true;
            puntosReceta = 7;
            tipoReceta = "SopaDeArroz";
        }
        else
        {

            RecetaSopaArrozCompleta = false;

            this.GetComponentInParent<receta>().algunaRecetaCompletada = false;
            puntosReceta = 0;
            tipoReceta = "null";

        }

    }
}
