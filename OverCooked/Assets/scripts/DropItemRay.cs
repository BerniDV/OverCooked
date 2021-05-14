using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItemRay : MonoBehaviour
{

    public GameObject itemPicked;
    public bool anItemPicked;


    // Start is called before the first frame update
    void Start()
    {
        itemPicked = null;
        anItemPicked = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            Vector3 origin = transform.position;
            Vector3 fwd = transform.TransformDirection(Vector3.forward);
            float distance = 4.0f;
            RaycastHit hit;

            if (anItemPicked)
            {
                if (Physics.Raycast(origin, fwd, out hit, distance))
                {

                    //Estamos ante una mesa
                    if (hit.transform.tag == "Mesa")
                    {
                        //Esta ocupada?
                        bool used = hit.transform.gameObject.GetComponent<MesaStatus>().isUsed;

                        //Mesa Desocupada
                        if (!used)
                        {
                            Vector3 mesaPosition = hit.transform.gameObject.transform.position;
                            itemPicked.transform.position = mesaPosition + new Vector3(0, 2, 0);

                            hit.transform.gameObject.GetComponent<MesaStatus>().isUsed = true;
                            hit.transform.gameObject.GetComponent<MesaStatus>().itemEnMesa = true;
                            hit.transform.gameObject.GetComponent<MesaStatus>().item = itemPicked;

                            anItemPicked = false;
                            itemPicked = null;
                        }

                    }

                    //Estamos ante una mesaFogon
                    else if (hit.transform.tag == "fogon")
                    {
                        //Esta ocupada?
                        bool used = hit.transform.gameObject.GetComponent<MesaFogonStatus>().isUsed;

                        //MesaFogon Desocupada
                        if (!used && itemPicked.transform.tag == "sarten")
                        {
                            Vector3 mesaFogonPosition = hit.transform.gameObject.transform.position;
                            itemPicked.transform.position = mesaFogonPosition + new Vector3(0, 2, 0);

                            hit.transform.gameObject.GetComponent<MesaFogonStatus>().isUsed = true;
                            hit.transform.gameObject.GetComponent<MesaFogonStatus>().itemEnMesaFogon = true;
                            hit.transform.gameObject.GetComponent<MesaFogonStatus>().item = itemPicked;

                            anItemPicked = false;
                            itemPicked = null;
                        }

                        //MesaFogon Ocupada
                        //No hacemos nada a la hora de dejar objeto
                    }

                    //Estamos ante una basura
                    else if (hit.transform.tag == "basura")
                    {
                        if (itemPicked.transform.tag != "sarten")
                        {
                            Destroy(itemPicked);

                            anItemPicked = false;
                            itemPicked = null;
                        }
                    }

                    //Estamos ante una zona de entrega

                    //Estamos ante NADA
                }
            }
        }

        if (anItemPicked)
        {
            Vector3 origin = transform.position;
            Vector3 fwd = transform.forward * 3.5f;

            itemPicked.transform.position = origin + fwd + new Vector3(0, 2, 0);
        }
    }
}
