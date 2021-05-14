using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickItemRay : MonoBehaviour
{
    //only info
    public Vector3 value;
    public GameObject item;

    //real use on game
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
            value = fwd;

            //Pickear Objeto
            if (!anItemPicked)
            {
                if (Physics.Raycast(origin, fwd, out hit, distance))
                {
                    item = hit.transform.gameObject;

                    //Cogemos un plato / sarten / ingrediente
                    if (hit.transform.tag == "plato" || hit.transform.tag == "sarten" || hit.transform.tag == "ingrediente")
                    {
                        //Destroy(hit.transform.gameObject);
                        itemPicked = hit.transform.gameObject;
                        anItemPicked = true;
                    }

                    //Estamos ante una mesa
                    else if (hit.transform.tag == "Mesa")
                    {
                        //Esta ocupada?
                        bool used = hit.transform.gameObject.GetComponent<MesaStatus>().isUsed;

                        //Mesa Ocupada
                        if (used)
                        {
                            anItemPicked = true;
                            itemPicked = hit.transform.gameObject.GetComponent<MesaStatus>().item;

                            hit.transform.gameObject.GetComponent<MesaStatus>().isUsed = false;
                            hit.transform.gameObject.GetComponent<MesaStatus>().itemEnMesa = false;
                            hit.transform.gameObject.GetComponent<MesaStatus>().item = null;
                            
                        }

                        //Mesa Desocupada
                        //No hacemos nada a la hora de dejar objeto
                    }

                    //Estamos ante una mesaFogon
                    else if (hit.transform.tag == "fogon")
                    {
                        //Esta ocupada?
                        bool used = hit.transform.gameObject.GetComponent<MesaFogonStatus>().isUsed;

                        //Mesa Ocupada
                        if (used)
                        {
                            anItemPicked = true;
                            itemPicked = hit.transform.gameObject.GetComponent<MesaFogonStatus>().item;

                            hit.transform.gameObject.GetComponent<MesaFogonStatus>().isUsed = false;
                            hit.transform.gameObject.GetComponent<MesaFogonStatus>().itemEnMesaFogon = false;
                            hit.transform.gameObject.GetComponent<MesaFogonStatus>().item = null;

                        }

                        //Mesa Desocupada
                        //No hacemos nada a la hora de dejar objeto
                    }
                }
            }








            //Dejar Objeto
            else if(anItemPicked)
            {
                if (Physics.Raycast(origin, fwd, out hit, distance))
                {
                    item = hit.transform.gameObject;

                    //Estamos ante una mesa
                    if(hit.transform.tag == "Mesa")
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

                        //Mesa Ocupada
                        
                        
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
                        //Si tiene una sarten podemos dejar ingredientes
                        else
                        {
                            if(hit.transform.gameObject.GetComponent<MesaFogonStatus>().item.transform.tag == "sarten")
                            {
                                GameObject sarten = hit.transform.gameObject.GetComponent<MesaFogonStatus>().item;

                                if (itemPicked.transform.tag == "ingrediente")
                                {
                                    //Vector3 mesaPosition = hit.transform.gameObject.transform.position;
                                    //itemPicked.transform.position = mesaPosition + new Vector3(0, 2 + 1, 0);

                                    sarten.transform.gameObject.GetComponent<SartenStatus>().isUsed = true;
                                    sarten.transform.gameObject.GetComponent<SartenStatus>().itemEnSarten = true;
                                    sarten.transform.gameObject.GetComponent<SartenStatus>().item = itemPicked;

                                    anItemPicked = false;
                                    itemPicked = null;
                                }
                            }
                        }
                    }

                    //Estamos ante una basura
                    else if(hit.transform.tag == "basura")
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

        //moviendo el item delante del personaje
        if (anItemPicked)
        {
            Vector3 origin = transform.position;
            Vector3 fwd = transform.forward * 3.5f;

            itemPicked.transform.position = origin + fwd + new Vector3(0,2,0);
        }
    }
}