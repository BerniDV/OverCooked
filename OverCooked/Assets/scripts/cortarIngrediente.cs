using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cortarIngrediente : MonoBehaviour
{
    public bool sePuedeCortar;
    public GameObject ColCortada;
    public GameObject TomateCortado;
    public float tiempoHastaCortado;

    // Start is called before the first frame update
    void Start()
    {
        tiempoHastaCortado = 4.0f;
    }

    // Update is called once per frame
    void Update()
    {
        sePuedeCortar = PuedeCortar();
        
        SustituirModelo();
    }

    bool PuedeCortar()
    {
        GameObject ItemPicked;

        ItemPicked = this.GetComponentInParent<PickItem>().ObjectPicked;



        if (ItemPicked != null && ItemPicked.tag == "ingrediente" && ItemPicked.GetComponentInParent<EstadoIngrediente>().sePuedeCortar && !ItemPicked.GetComponentInParent<EstadoIngrediente>().EstaCortado)
        {

            return true;

        }
   

        return false;
    }

    void SustituirModelo()
    {

        if (sePuedeCortar)
        {
            tiempoHastaCortado -= Time.deltaTime;
            if (tiempoHastaCortado < 0.0f)
            {
                GameObject ItemPicked;
                ItemPicked = this.GetComponentInParent<PickItem>().ObjectPicked;

                string nameIngrediente = this.GetComponentInParent<PickItem>().ObjectPicked.GetComponentInParent<Atributos>().nombre;


                Object.Destroy(ItemPicked);

                GameObject ObjetoCortado = null;

                if (nameIngrediente == "col")
                {

                    ObjetoCortado = Instantiate(ColCortada);
                    ObjetoCortado.transform.position = this.GetComponentInParent<PickItem>().LocationToPick.position;
                    ObjetoCortado.transform.SetParent(this.GetComponentInParent<PickItem>().LocationToPick);
                    ObjetoCortado.GetComponent<Rigidbody>().useGravity = false;
                    ObjetoCortado.GetComponent<Rigidbody>().isKinematic = true;

                }
                else if (nameIngrediente == "Tomate")
                {


                    ObjetoCortado = Instantiate(TomateCortado);
                    ObjetoCortado.transform.position = this.GetComponentInParent<PickItem>().LocationToPick.position;
                    ObjetoCortado.transform.SetParent(this.GetComponentInParent<PickItem>().LocationToPick);
                    ObjetoCortado.GetComponent<Rigidbody>().useGravity = false;
                    ObjetoCortado.GetComponent<Rigidbody>().isKinematic = true;

                }

                if (ObjetoCortado != null)
                {

                    this.GetComponentInParent<PickItem>().ObjectPicked = ObjetoCortado;

                }
            }
        }
        else tiempoHastaCortado = 4.0f;

    }
}
