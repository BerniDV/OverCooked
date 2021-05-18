using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cortarIngrediente : MonoBehaviour
{
    public bool sePuedeCortar;
    public GameObject ColCortada;

    // Start is called before the first frame update
    void Start()
    {

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

            GameObject ItemPicked;
            ItemPicked = this.GetComponentInParent<PickItem>().ObjectPicked;

        
            Object.Destroy(ItemPicked);

            GameObject MyColCortada = Instantiate(ColCortada);
            MyColCortada.transform.position = this.GetComponentInParent<PickItem>().LocationToPick.position;
            MyColCortada.transform.SetParent(this.GetComponentInParent<PickItem>().LocationToPick);
            MyColCortada.GetComponent<Rigidbody>().useGravity = false;
            MyColCortada.GetComponent<Rigidbody>().isKinematic = true;


            this.GetComponentInParent<PickItem>().ObjectPicked = MyColCortada;
        }

    }
}
