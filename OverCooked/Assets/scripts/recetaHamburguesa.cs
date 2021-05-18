using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class recetaHamburguesa : MonoBehaviour
{

    public Transform LocationCarne;
    public GameObject carnePicked;

    public string tipoReceta;
    public int puntosReceta;
    

    public bool RecetaHamburguesaDeCarneCompleta;

    // Start is called before the first frame update
    void Start()
    {

        RecetaHamburguesaDeCarneCompleta = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (LocationCarne != null)
        {

            RecetaHamburguesaDeCarneCompleta = true;
            this.GetComponentInParent<receta>().algunaRecetaCompletada = true;
            puntosReceta = 5;
            tipoReceta = "hamburguesaDeCarne";
        }
        
    }

}
