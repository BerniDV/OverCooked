using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class recetaHamburguesa : MonoBehaviour
{

    public Transform LocationCarne;
    public GameObject carnePicked;

    public Transform LocationEnsalada;
    public GameObject ensaladaPicked;
    
    public Transform LocationTomate;
    public GameObject tomatePicked;


    public string tipoReceta;
    public int puntosReceta;
    

    public bool RecetaHamburguesaDeCarneCompleta;
    public bool RecetaHamburguesaDeCarneConEnsaladaCompleta;
    public bool RecetaHamburguesaDeCarneConEnsaladaConTomateCompleta;

    // Start is called before the first frame update
    void Start()
    {

        RecetaHamburguesaDeCarneCompleta = false;
        RecetaHamburguesaDeCarneConEnsaladaCompleta = false;
        RecetaHamburguesaDeCarneConEnsaladaConTomateCompleta = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (carnePicked != null && ensaladaPicked == null && tomatePicked == null)
        {

            RecetaHamburguesaDeCarneCompleta = true;
            RecetaHamburguesaDeCarneConEnsaladaCompleta = false;
            RecetaHamburguesaDeCarneConEnsaladaConTomateCompleta = false;

            this.GetComponentInParent<receta>().algunaRecetaCompletada = true;
            puntosReceta = 5;
            tipoReceta = "hamburguesaDeCarne";
        }else
        
        if (carnePicked != null && ensaladaPicked != null && tomatePicked == null)
        {

            RecetaHamburguesaDeCarneCompleta = false;
            RecetaHamburguesaDeCarneConEnsaladaCompleta = true;
            RecetaHamburguesaDeCarneConEnsaladaConTomateCompleta = false;

            this.GetComponentInParent<receta>().algunaRecetaCompletada = true;
            puntosReceta = 10;
            tipoReceta = "hamburguesaDeCarneConEnsalada";
        }else
        
        if (carnePicked != null && ensaladaPicked != null && tomatePicked != null)
        {

            RecetaHamburguesaDeCarneCompleta = false;
            RecetaHamburguesaDeCarneConEnsaladaCompleta = false;
            RecetaHamburguesaDeCarneConEnsaladaConTomateCompleta = true;

            this.GetComponentInParent<receta>().algunaRecetaCompletada = true;
            puntosReceta = 15;
            tipoReceta = "hamburguesaDeCarneConEnsaladaConTomate";
        }
        else
        {

            RecetaHamburguesaDeCarneCompleta = false;
            RecetaHamburguesaDeCarneConEnsaladaCompleta = false;
            RecetaHamburguesaDeCarneConEnsaladaConTomateCompleta = false;

            this.GetComponentInParent<receta>().algunaRecetaCompletada = false;
            puntosReceta = 0;
            tipoReceta = "null";

        }
        
    }

}
