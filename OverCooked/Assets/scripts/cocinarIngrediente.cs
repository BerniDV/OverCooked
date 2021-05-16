using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cocinarIngrediente : MonoBehaviour
{

    public bool sePuedeCocinar;
    public GameObject CarneCocinada;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        sePuedeCocinar = PuedeCocinar();

        SustituirModelo();
    }

    bool PuedeCocinar()
    {
        GameObject ItemPicked;

        ItemPicked = this.GetComponentInParent<PickItem>().ObjectPicked;

       if (ItemPicked != null && ItemPicked.tag == "sarten")
        {

            GameObject Ingrediente = ItemPicked.GetComponentInParent<comidaEnSarten>().ObjectPicked;

            if (Ingrediente != null && Ingrediente.tag == "ingrediente" && Ingrediente.GetComponentInParent<EstadoIngrediente>().sePuedeFreir && !Ingrediente.GetComponentInParent<EstadoIngrediente>().EstaFrito)
            {

                return true;


            }

        }

        return false;
    }

    void SustituirModelo()
    {

        if (sePuedeCocinar)
        {

            GameObject ItemPicked;
            ItemPicked = this.GetComponentInParent<PickItem>().ObjectPicked;

            GameObject Ingrediente = ItemPicked.GetComponentInParent<comidaEnSarten>().ObjectPicked;
            Object.Destroy(Ingrediente);

            GameObject MyCarneCocinada = Instantiate(CarneCocinada);
            MyCarneCocinada.transform.position = ItemPicked.GetComponentInParent<comidaEnSarten>().LocationToPick.position;
            MyCarneCocinada.transform.SetParent(ItemPicked.GetComponentInParent<comidaEnSarten>().LocationToPick);
            MyCarneCocinada.GetComponent<Rigidbody>().useGravity = false;
            MyCarneCocinada.GetComponent<Rigidbody>().isKinematic = true;


            ItemPicked.GetComponentInParent<comidaEnSarten>().ObjectPicked = MyCarneCocinada;
        }

    }
}
