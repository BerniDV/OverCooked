using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class recetaSopa : MonoBehaviour
{
    //public Transform LocationArroz;
    //public GameObject arrozPicked;

    public bool TomatePicked;

    public string tipoReceta;
    public int puntosReceta;


    public bool RecetaSopaArrozCompleta;
    public bool RecetaSopaArrozConTomateCompleta;


    // Start is called before the first frame update
    void Start()
    {

        RecetaSopaArrozCompleta = false;
        RecetaSopaArrozConTomateCompleta = false;
        TomatePicked = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (this.GetComponentInParent<EstadoIngrediente>().EstaHervido && !TomatePicked)
        {

            RecetaSopaArrozCompleta = true;
            RecetaSopaArrozConTomateCompleta = false;

            this.GetComponentInParent<receta>().algunaRecetaCompletada = true;
            puntosReceta = 7;
            tipoReceta = "SopaDeArroz";
        }
        else if(this.GetComponentInParent<EstadoIngrediente>().EstaHervido && TomatePicked )
        {

            RecetaSopaArrozCompleta = false;
            RecetaSopaArrozConTomateCompleta = true;

            this.GetComponentInParent<receta>().algunaRecetaCompletada = true;
            puntosReceta = 20;
            tipoReceta = "SopaDeArrozConTomate";

        }
        else
        {

            RecetaSopaArrozCompleta = false;
            RecetaSopaArrozConTomateCompleta = false;

            this.GetComponentInParent<receta>().algunaRecetaCompletada = false;
            puntosReceta = 0;
            tipoReceta = "null";

        }

    }
}
