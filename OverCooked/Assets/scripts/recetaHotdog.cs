using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class recetaHotdog : MonoBehaviour
{
    public bool TomatePicked;
    public bool CarnePicked;

    public string tipoReceta;
    public int puntosReceta;


    public bool RecetaHotDog;
    public bool RecetaHotDogConQuetxup;


    // Start is called before the first frame update
    void Start()
    {

        RecetaHotDog = false;
        RecetaHotDogConQuetxup = false;
        TomatePicked = false;
        CarnePicked = false;
    }

    // Update is called once per frame
    void Update()
    {

        if ((CarnePicked && !TomatePicked) || this.GetComponentInParent<Atributos>().nombre == "hotDog")
        {

            RecetaHotDog = true;
            RecetaHotDogConQuetxup = false;

            this.GetComponentInParent<receta>().algunaRecetaCompletada = true;
            puntosReceta = 11;
            tipoReceta = "HotDog";
        }
        else if ((CarnePicked && TomatePicked) || this.GetComponentInParent<Atributos>().nombre == "hotDogConQuetxup")
        {

            RecetaHotDog = false;
            RecetaHotDogConQuetxup = true;

            this.GetComponentInParent<receta>().algunaRecetaCompletada = true;
            puntosReceta = 25;
            tipoReceta = "HotDogConQuetxup";

        }
        else
        {

            RecetaHotDog = false;
            RecetaHotDogConQuetxup = false;

            this.GetComponentInParent<receta>().algunaRecetaCompletada = false;
            puntosReceta = 0;
            tipoReceta = "null";

        }

    }
}
