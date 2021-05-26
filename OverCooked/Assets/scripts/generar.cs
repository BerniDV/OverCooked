using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generar : MonoBehaviour
{
    public bool IngredienteRequested;

    public GameObject Ingrediente;
    public GameObject Character;

    // Start is called before the first frame update
    void Start()
    {

        IngredienteRequested = false;


    }

    // Update is called once per frame
    void Update()
    {
        GenerarModelo();
    }

    void GenerarModelo()
    {

        if (IngredienteRequested && Character!=null && Character.tag == "item_pickable" && Character.GetComponentInParent<PickItem>().ObjectPicked == null)
        {


            GameObject MyIngrediente = Instantiate(Ingrediente);
            MyIngrediente.transform.position = Character.GetComponentInParent<PickItem>().LocationToPick.position;
            MyIngrediente.transform.SetParent(Character.GetComponentInParent<PickItem>().LocationToPick);
            MyIngrediente.GetComponent<Rigidbody>().useGravity = false;
            MyIngrediente.GetComponent<Rigidbody>().isKinematic = true;

            Character.GetComponentInParent<PickItem>().ObjectPicked = MyIngrediente;


            IngredienteRequested = false;

        }

    }

}
