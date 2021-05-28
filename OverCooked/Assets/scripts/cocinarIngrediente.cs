using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cocinarIngrediente : MonoBehaviour
{

    public bool sePuedeCocinar;
    public GameObject CarneCocinada;

    public bool sePuedeHervir;
    public GameObject ArrozHervido;

    public float tiempoHastaCarneCocinada;
    public float tiempoHastaArrozCocinado;

    // Start is called before the first frame update
    void Start()
    {
        tiempoHastaCarneCocinada =  8.0f;
        tiempoHastaArrozCocinado = 16.0f;
    }

    // Update is called once per frame
    void Update()
    {
        sePuedeCocinar = PuedeCocinar();

        sePuedeHervir = PuedeHervir();

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

    bool PuedeHervir()
    {
        GameObject ItemPicked;

        ItemPicked = this.GetComponentInParent<PickItem>().ObjectPicked;

        if (ItemPicked != null && ItemPicked.tag == "olla")
        {

            GameObject Ingrediente = ItemPicked.GetComponentInParent<comidaEnOlla>().ObjectPicked;

            if (Ingrediente != null && Ingrediente.tag == "ingrediente" && Ingrediente.GetComponentInParent<EstadoIngrediente>().SePuedeHervir && !Ingrediente.GetComponentInParent<EstadoIngrediente>().EstaHervido)
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
            tiempoHastaCarneCocinada -= Time.deltaTime;
            if (tiempoHastaCarneCocinada < 0.0f)
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

                //preparar arroz
            }
        }
        else tiempoHastaCarneCocinada = 8.0f;

        if (sePuedeHervir && this.GetComponentInParent<PickItem>().ObjectPicked.GetComponentInParent<comidaEnOlla>().ObjectPicked.GetComponentInParent<Atributos>().nombre == "arroz")
        {
            tiempoHastaArrozCocinado -= Time.deltaTime;
            if (tiempoHastaArrozCocinado < 0.0f)
            {
                GameObject ItemPicked;
                ItemPicked = this.GetComponentInParent<PickItem>().ObjectPicked;

                GameObject Ingrediente = ItemPicked.GetComponentInParent<comidaEnOlla>().ObjectPicked;
                Object.Destroy(Ingrediente);

                GameObject MyArrozHervido = Instantiate(ArrozHervido);
                MyArrozHervido.transform.position = ItemPicked.GetComponentInParent<comidaEnOlla>().LocationToPick.position;
                MyArrozHervido.transform.SetParent(ItemPicked.GetComponentInParent<comidaEnOlla>().LocationToPick);
                MyArrozHervido.GetComponent<Rigidbody>().useGravity = false;
                MyArrozHervido.GetComponent<Rigidbody>().isKinematic = true;


                ItemPicked.GetComponentInParent<comidaEnOlla>().ObjectPicked = MyArrozHervido;
            }
        }
        else tiempoHastaArrozCocinado = 16.0f;

    }
}
