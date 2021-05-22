using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sustituirModelos : MonoBehaviour
{

    public bool carnepicked;
    bool unaVezCarne;
    public GameObject HotDog;

    public bool tomatePicked;
    bool unaVezTomate;
    public GameObject HotDogConQuetxup;

    // Start is called before the first frame update
    void Start()
    {
        carnepicked = false;
        unaVezCarne = false;
        unaVezTomate = false;
    }

    // Update is called once per frame
    void Update()
    {
        SustituirModelo();
    }

    void SustituirModelo()
    {

        if (carnepicked && !unaVezCarne)
        {

            unaVezCarne = true;
            GameObject Ingrediente = GetComponentInParent<ComidaEnPlato>().ObjectPicked;
            Object.Destroy(Ingrediente);

            GameObject MyHotDog = Instantiate(HotDog);
            MyHotDog.transform.position = GetComponentInParent<ComidaEnPlato>().LocationToPick.position;
            MyHotDog.transform.SetParent(GetComponentInParent<ComidaEnPlato>().LocationToPick);
            MyHotDog.GetComponent<Rigidbody>().useGravity = false;
            MyHotDog.GetComponent<Rigidbody>().isKinematic = true;
            MyHotDog.GetComponentInParent<recetaHotdog>().CarnePicked = true;



            GetComponentInParent<ComidaEnPlato>().ObjectPicked = MyHotDog;
            



        }

        if (tomatePicked && !unaVezTomate)
        {

            unaVezTomate = true;
            GameObject Ingrediente = GetComponentInParent<ComidaEnPlato>().ObjectPicked;
            Object.Destroy(Ingrediente);

            GameObject MyHotDog = Instantiate(HotDogConQuetxup);
            MyHotDog.transform.position = GetComponentInParent<ComidaEnPlato>().LocationToPick.position;
            MyHotDog.transform.SetParent(GetComponentInParent<ComidaEnPlato>().LocationToPick);
            MyHotDog.GetComponent<Rigidbody>().useGravity = false;
            MyHotDog.GetComponent<Rigidbody>().isKinematic = true;
            MyHotDog.GetComponentInParent<recetaHotdog>().TomatePicked = true;



            GetComponentInParent<ComidaEnPlato>().ObjectPicked = MyHotDog;




        }

    }
}
