using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadoIngrediente : MonoBehaviour
{

    public bool sePuedeCortar;
    public bool sePuedeFreir;
    public bool EstaCortado;
    public bool EstaFrito;
    public bool SePuedeHervir;
    public bool EstaHervido;


    // Start is called before the first frame update
    void Start()
    {

        

    }

    // Update is called once per frame
    void Update()
    {

        if (EstaFrito)
        {

            this.GetComponentInParent<PickableObject>().isPickable = false;
        }
    }
}
