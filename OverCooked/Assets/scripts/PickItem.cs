using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickItem : MonoBehaviour
{

    public GameObject TranspaseObjectPicked;
    public GameObject ObjectToPickUp;
    public GameObject ObjectPicked;
    public Transform LocationToPick;

    // Start is called before the first frame update
    void Start()
    {

       
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Mesa")
        {

            
            


                if (other.GetComponentInParent<PickItem>().ObjectPicked == null)
                {

                     TranspaseObjectPicked = other.gameObject;
                     other.GetComponentInParent<PickItem>().ObjectToPickUp = this.ObjectPicked;
                }
                else
                {
                    if (ObjectPicked != null)
                    {

                        TranspaseObjectPicked = other.GetComponentInParent<PickItem>().ObjectPicked;
                        this.ObjectToPickUp = other.GetComponentInParent<PickItem>().ObjectPicked;

                    }
                    else
                    {
                        TranspaseObjectPicked = other.gameObject;
                        this.ObjectToPickUp = other.GetComponentInParent<PickItem>().ObjectPicked;

                    }
                    
                }

            

            

        }
        else if (other.tag == "MesaCortar")
        {


            if (other.GetComponentInParent<PickItem>().ObjectPicked == null && ObjectPicked != null && ObjectPicked.tag == "ingrediente" && ObjectPicked.GetComponentInParent<EstadoIngrediente>().sePuedeCortar)
            {

                TranspaseObjectPicked = other.gameObject;
                other.GetComponentInParent<PickItem>().ObjectToPickUp = this.ObjectPicked;
            }
            else
            {
                if (ObjectPicked == null)
                {

                    TranspaseObjectPicked = other.gameObject;
                    this.ObjectToPickUp = other.GetComponentInParent<PickItem>().ObjectPicked;

                }
              

            }


        }
        else if (other.tag == "plato")
        {
            if (other.GetComponentInParent<ComidaEnPlato>().ObjectPicked == null )
            {
                TranspaseObjectPicked = other.gameObject;

                if (ObjectPicked != null && ObjectPicked.tag != "plato" && ObjectPicked.tag != "sarten")
                {
                    other.GetComponentInParent<ComidaEnPlato>().ObjectToPickUp = this.ObjectPicked;

                }

            }
            else
            {
                this.ObjectToPickUp = other.GetComponentInParent<ComidaEnPlato>().ObjectPicked;
                TranspaseObjectPicked = other.gameObject;
            }

        }
        else if (other.tag == "sarten"  )
        {
            if (other.GetComponentInParent<comidaEnSarten>().ObjectPicked == null)
            {

                

                if (ObjectPicked != null && ObjectPicked.tag == "ingrediente" && ObjectPicked.GetComponentInParent<EstadoIngrediente>().sePuedeFreir && !ObjectPicked.GetComponentInParent<EstadoIngrediente>().EstaFrito)
                {

                    TranspaseObjectPicked = other.gameObject;
                    other.GetComponentInParent<comidaEnSarten>().ObjectToPickUp = this.ObjectPicked;

                }
                else
                {
                    this.ObjectToPickUp = other.GetComponentInParent<comidaEnSarten>().ObjectPicked;
                    TranspaseObjectPicked = other.gameObject;
                }

            }

        }
        else if (other.tag == "fogon" )
        {
            /*
            if (other.GetComponentInParent<PickItem>().ObjectPicked != null && this.ObjectPicked != null)
            {

                TranspaseObjectPicked = other.GetComponentInParent<PickItem>().ObjectPicked;
                other.GetComponentInParent<PickItem>().ObjectPicked.GetComponentInParent<PickItem>().ObjectToPickUp = this.ObjectPicked;

            }
            else
            {

                if (other.GetComponentInParent<PickItem>().ObjectPicked == null)
                {
                    TranspaseObjectPicked = other.gameObject;
                    other.GetComponentInParent<PickItem>().ObjectToPickUp = this.ObjectPicked;
                }
                else
                {

                    TranspaseObjectPicked = other.gameObject;
                }

            }
            */

            if (other.GetComponentInParent<PickItem>().ObjectPicked == null)
            {

                TranspaseObjectPicked = other.gameObject;
                other.GetComponentInParent<PickItem>().ObjectToPickUp = this.ObjectPicked;
            }
            else
            {
                if (ObjectPicked != null)
                {

                    TranspaseObjectPicked = other.GetComponentInParent<PickItem>().ObjectPicked;
                    this.ObjectToPickUp = other.GetComponentInParent<PickItem>().ObjectPicked;

                }
                else
                {
                    TranspaseObjectPicked = other.gameObject;
                    this.ObjectToPickUp = other.GetComponentInParent<PickItem>().ObjectPicked;

                }

            }




        }
        else if (other.tag == "basura")
        {
            if (this.ObjectPicked != null &&  this.ObjectPicked.tag == "ingrediente" )
            {

                TranspaseObjectPicked = other.gameObject;
                other.GetComponentInParent<eliminar>().ObjectToDelete = this.ObjectPicked;

            }
            else if(this.ObjectPicked != null && this.ObjectPicked.tag == "sarten")
            {

                if (ObjectPicked.GetComponentInParent<comidaEnSarten>().ObjectPicked != null)
                {
                    TranspaseObjectPicked = other.gameObject;
                    other.GetComponentInParent<eliminar>().ObjectToDelete = ObjectPicked.GetComponentInParent<comidaEnSarten>().ObjectPicked;
                }
                

            }else if (this.ObjectPicked != null && this.ObjectPicked.tag == "plato")
            {

                if (ObjectPicked.GetComponentInParent<ComidaEnPlato>().ObjectPicked != null)
                {
                    TranspaseObjectPicked = other.gameObject;
                    other.GetComponentInParent<eliminar>().ObjectToDelete = ObjectPicked.GetComponentInParent<ComidaEnPlato>().ObjectPicked;
                }
            }

        }
        else if (other.tag == "entrega")
        {

            if (ObjectPicked != null)
            {
                this.TranspaseObjectPicked = other.gameObject;
                //other.GetComponentInParent<Entrega>().objetoEntregado
            }
        }
    }


    private void OnTriggerExit(Collider other)
    {

        if (other.tag == "Mesa")
        {

            TranspaseObjectPicked = null;
            other.GetComponentInParent<PickItem>().ObjectToPickUp = null;
        }
        else if (other.tag == "MesaCortar")
        {

            TranspaseObjectPicked = null;
            other.GetComponentInParent<PickItem>().ObjectToPickUp = null;
        }
        else if (other.tag == "plato")
        {

            TranspaseObjectPicked = null;
            other.GetComponentInParent<ComidaEnPlato>().ObjectToPickUp = null;

        }
        else if (other.tag == "sarten")
        {

            TranspaseObjectPicked = null;
            other.GetComponentInParent<comidaEnSarten>().ObjectToPickUp = null;

        }
        else if (other.tag == "fogon")
        {

            TranspaseObjectPicked = null;
            other.GetComponentInParent<PickItem>().ObjectToPickUp = null;

        }
        else if (other.tag == "entrega")
        {
            TranspaseObjectPicked = null;
        }
        else if (other.tag == "basura")
        {

            other.GetComponentInParent<eliminar>().ObjectToDelete = null;
            TranspaseObjectPicked = null;
        }

    }

    // Update is called once per frame
    void Update()
    {
        //picking item
        /*Vector3 fwd = transform.TransformDirection(Vector3.forward);
        if (Physics.Raycast(transform.position, fwd, 10))
        {

        }*/


        //no permitir que el lugar donde poner algo sea el mismo objetos que se transporta (evitampos autorelacion recursiva)

        if (TranspaseObjectPicked != null && ObjectPicked!= null && TranspaseObjectPicked == ObjectPicked)
        {

            TranspaseObjectPicked = null;
        }

        //Cojer objetos del interior de un plato que esta en una mesa
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {

            if (TranspaseObjectPicked != null && TranspaseObjectPicked.tag == "Mesa" && TranspaseObjectPicked.GetComponentInParent<PickItem>().ObjectPicked != null)
            {
                if (TranspaseObjectPicked.GetComponentInParent<PickItem>().ObjectPicked.tag == "plato")
                {

                   // TranspaseObjectPicked.GetComponentInParent<PickItem>().ObjectPicked.GetComponentInParent<PickableObject>().isPickable = true;
                    TranspaseObjectPicked = TranspaseObjectPicked.GetComponentInParent<PickItem>().ObjectPicked;
                    //this.ObjectToPickUp = TranspaseObjectPicked.GetComponentInParent<PickItem>().ObjectPicked.GetComponentInParent<ComidaEnPlato>().ObjectPicked;
                }


            }
            
            if(TranspaseObjectPicked != null && TranspaseObjectPicked.tag == "plato" && TranspaseObjectPicked.GetComponentInParent<ComidaEnPlato>().ObjectPicked != null)
            {

                if (TranspaseObjectPicked.GetComponentInParent<ComidaEnPlato>().ObjectPicked.tag == "ingrediente")
                {

                    TranspaseObjectPicked.GetComponentInParent<ComidaEnPlato>().ObjectPicked.GetComponentInParent<PickableObject>().isPickable = true;
                    this.ObjectToPickUp = TranspaseObjectPicked.GetComponentInParent<ComidaEnPlato>().ObjectPicked;
                }

            }

        }


        if (ObjectToPickUp != null && ObjectToPickUp.GetComponent<PickableObject>().isPickable == true && ObjectPicked == null)
        {

            if (Input.GetKeyDown("space"))
            {
                

                if (TranspaseObjectPicked == null)
                {

                    ObjectPicked = ObjectToPickUp;
                    ObjectPicked.GetComponent<PickableObject>().isPickable = false;
                    ObjectPicked.transform.SetParent(LocationToPick);
                    ObjectPicked.transform.position = LocationToPick.position;
                    ObjectPicked.GetComponent<Rigidbody>().useGravity = false;
                    ObjectPicked.GetComponent<Rigidbody>().isKinematic = true;
                    
                }
                else
                {

                    if (TranspaseObjectPicked.tag == "Mesa" && TranspaseObjectPicked.GetComponentInParent<PickItem>().ObjectPicked != null && TranspaseObjectPicked.GetComponentInParent<PickItem>().ObjectPicked.GetComponentInParent<PickableObject>().isPickable && this.ObjectPicked == null)
                    {
                        //llevar objetos colocado en una mesa
                        ObjectPicked = TranspaseObjectPicked.GetComponentInParent<PickItem>().ObjectPicked;
                        ObjectPicked.GetComponent<PickableObject>().isPickable = false;
                        ObjectPicked.transform.SetParent(LocationToPick);
                        ObjectPicked.transform.position = LocationToPick.position;
                        ObjectPicked.GetComponent<Rigidbody>().useGravity = false;
                        ObjectPicked.GetComponent<Rigidbody>().isKinematic = true;
                        TranspaseObjectPicked.GetComponentInParent<PickItem>().ObjectPicked = null;


                    }else if (TranspaseObjectPicked.tag == "MesaCortar" && TranspaseObjectPicked.GetComponentInParent<PickItem>().ObjectPicked != null && TranspaseObjectPicked.GetComponentInParent<PickItem>().ObjectPicked.GetComponentInParent<PickableObject>().isPickable && this.ObjectPicked == null)
                    {
                        //llevar objetos colocado en una mesacortar
                        ObjectPicked = TranspaseObjectPicked.GetComponentInParent<PickItem>().ObjectPicked;
                        ObjectPicked.GetComponent<PickableObject>().isPickable = false;
                        ObjectPicked.transform.SetParent(LocationToPick);
                        ObjectPicked.transform.position = LocationToPick.position;
                        ObjectPicked.GetComponent<Rigidbody>().useGravity = false;
                        ObjectPicked.GetComponent<Rigidbody>().isKinematic = true;
                        TranspaseObjectPicked.GetComponentInParent<PickItem>().ObjectPicked = null;


                    }
                    else if (TranspaseObjectPicked.tag == "fogon" && TranspaseObjectPicked.GetComponentInParent<PickItem>().ObjectPicked != null && TranspaseObjectPicked.GetComponentInParent<PickItem>().ObjectPicked.GetComponentInParent<PickableObject>().isPickable && this.ObjectPicked == null)
                    {
                        //llevar sarten colocada en fogon
                        ObjectPicked = TranspaseObjectPicked.GetComponentInParent<PickItem>().ObjectPicked;
                        ObjectPicked.GetComponent<PickableObject>().isPickable = false;
                        ObjectPicked.transform.SetParent(LocationToPick);
                        ObjectPicked.transform.position = LocationToPick.position;
                        ObjectPicked.GetComponent<Rigidbody>().useGravity = false;
                        ObjectPicked.GetComponent<Rigidbody>().isKinematic = true;
                        TranspaseObjectPicked.GetComponentInParent<PickItem>().ObjectPicked = null;


                    }
                    else if (TranspaseObjectPicked.tag == "plato" && TranspaseObjectPicked.GetComponentInParent<ComidaEnPlato>().ObjectPicked != null && TranspaseObjectPicked.GetComponentInParent<ComidaEnPlato>().ObjectPicked.GetComponentInParent<PickableObject>().isPickable)
                    {
                        //llevar objetos colocado en un plato

                          

                        ObjectPicked = TranspaseObjectPicked.GetComponentInParent<ComidaEnPlato>().ObjectPicked;
                        ObjectPicked.GetComponent<PickableObject>().isPickable = false;
                        ObjectPicked.transform.SetParent(LocationToPick);
                        ObjectPicked.transform.position = LocationToPick.position;
                        ObjectPicked.GetComponent<Rigidbody>().useGravity = false;
                        ObjectPicked.GetComponent<Rigidbody>().isKinematic = true;
                        TranspaseObjectPicked.GetComponentInParent<ComidaEnPlato>().ObjectPicked = null;

                        
                    }
                    else if (TranspaseObjectPicked.tag == "sarten" && TranspaseObjectPicked.GetComponentInParent<comidaEnSarten>().ObjectPicked != null && TranspaseObjectPicked.GetComponentInParent<comidaEnSarten>().ObjectPicked.GetComponentInParent<PickableObject>().isPickable)
                    {
                        //llevar objetos colocado en una sarten



                        ObjectPicked = TranspaseObjectPicked.GetComponentInParent<comidaEnSarten>().ObjectPicked;
                        ObjectPicked.GetComponent<PickableObject>().isPickable = false;
                        ObjectPicked.transform.SetParent(LocationToPick);
                        ObjectPicked.transform.position = LocationToPick.position;
                        ObjectPicked.GetComponent<Rigidbody>().useGravity = false;
                        ObjectPicked.GetComponent<Rigidbody>().isKinematic = true;
                        TranspaseObjectPicked.GetComponentInParent<comidaEnSarten>().ObjectPicked = null;


                    }
                    else
                    {
                        //llevar objeto al lado de una mesa sin estar conectado a la mesa
                        ObjectPicked = ObjectToPickUp;
                        ObjectPicked.GetComponent<PickableObject>().isPickable = false;
                        ObjectPicked.transform.SetParent(LocationToPick);
                        ObjectPicked.transform.position = LocationToPick.position;
                        ObjectPicked.GetComponent<Rigidbody>().useGravity = false;
                        ObjectPicked.GetComponent<Rigidbody>().isKinematic = true;
                    }
                }

                
            }


        }
        else if (ObjectPicked != null && this.tag == "item_pickable") //Soltar objeto
        {

            if (Input.GetKeyDown("space"))
            {

                if (TranspaseObjectPicked != null) 
                {

                    //Poner objetoi en una mesa
                    if (TranspaseObjectPicked.tag == "Mesa" && TranspaseObjectPicked.GetComponentInParent<PickItem>().ObjectPicked == null) {

                        TranspaseObjectPicked.GetComponentInParent<PickItem>().ObjectPicked = this.ObjectPicked;
                        ObjectPicked.GetComponent<PickableObject>().isPickable = true;
                        TranspaseObjectPicked.GetComponentInParent<PickItem>().ObjectPicked.transform.SetParent(TranspaseObjectPicked.GetComponentInParent<PickItem>().LocationToPick);
                        TranspaseObjectPicked.GetComponentInParent<PickItem>().ObjectPicked.transform.position = TranspaseObjectPicked.GetComponentInParent<PickItem>().LocationToPick.position;
                        ObjectPicked.GetComponent<Rigidbody>().useGravity = false;
                        ObjectPicked.GetComponent<Rigidbody>().isKinematic = true;
                        this.ObjectPicked = null;
                        this.ObjectToPickUp = null;

                        //Poner objeto en mesa cortar
                    } else if (TranspaseObjectPicked.tag == "MesaCortar" && TranspaseObjectPicked.GetComponentInParent<PickItem>().ObjectPicked == null)
                    {

                        TranspaseObjectPicked.GetComponentInParent<PickItem>().ObjectPicked = this.ObjectPicked;
                        ObjectPicked.GetComponent<PickableObject>().isPickable = true;
                        TranspaseObjectPicked.GetComponentInParent<PickItem>().ObjectPicked.transform.SetParent(TranspaseObjectPicked.GetComponentInParent<PickItem>().LocationToPick);
                        TranspaseObjectPicked.GetComponentInParent<PickItem>().ObjectPicked.transform.position = TranspaseObjectPicked.GetComponentInParent<PickItem>().LocationToPick.position;
                        ObjectPicked.GetComponent<Rigidbody>().useGravity = false;
                        ObjectPicked.GetComponent<Rigidbody>().isKinematic = true;
                        this.ObjectPicked = null;
                        this.ObjectToPickUp = null;

                        //dejar en plato
                    }
                    else if (TranspaseObjectPicked.tag == "plato" && TranspaseObjectPicked.GetComponentInParent<ComidaEnPlato>().ObjectPicked == null && ObjectPicked.tag == "ingrediente")
                    {
                        TranspaseObjectPicked.GetComponentInParent<ComidaEnPlato>().ObjectPicked = this.ObjectPicked;
                        ObjectPicked.GetComponent<PickableObject>().isPickable = false;
                        TranspaseObjectPicked.GetComponentInParent<ComidaEnPlato>().ObjectPicked.transform.SetParent(TranspaseObjectPicked.GetComponentInParent<ComidaEnPlato>().LocationToPick);
                        TranspaseObjectPicked.GetComponentInParent<ComidaEnPlato>().ObjectPicked.transform.position = TranspaseObjectPicked.GetComponentInParent<ComidaEnPlato>().LocationToPick.position;
                        ObjectPicked.GetComponent<Rigidbody>().useGravity = false;
                        ObjectPicked.GetComponent<Rigidbody>().isKinematic = true;
                        this.ObjectPicked = null;
                        this.ObjectToPickUp = null;


                    }
                    //dejar en sarten
                    else if (TranspaseObjectPicked.tag == "sarten" && TranspaseObjectPicked.GetComponentInParent<comidaEnSarten>().ObjectPicked == null && ObjectPicked != null && ObjectPicked.GetComponentInParent<EstadoIngrediente>().sePuedeFreir)
                    {
                        TranspaseObjectPicked.GetComponentInParent<comidaEnSarten>().ObjectPicked = this.ObjectPicked;
                        ObjectPicked.GetComponent<PickableObject>().isPickable = true;
                        TranspaseObjectPicked.GetComponentInParent<comidaEnSarten>().ObjectPicked.transform.SetParent(TranspaseObjectPicked.GetComponentInParent<comidaEnSarten>().LocationToPick);
                        TranspaseObjectPicked.GetComponentInParent<comidaEnSarten>().ObjectPicked.transform.position = TranspaseObjectPicked.GetComponentInParent<comidaEnSarten>().LocationToPick.position;
                        ObjectPicked.GetComponent<Rigidbody>().useGravity = false;
                        ObjectPicked.GetComponent<Rigidbody>().isKinematic = true;
                        this.ObjectPicked = null;
                        this.ObjectToPickUp = null;


                    }
                    // dejar sarten en fogon
                    else if (TranspaseObjectPicked.tag == "fogon" && ObjectPicked.tag == "sarten" && TranspaseObjectPicked.GetComponentInParent<PickItem>().ObjectPicked == null)
                    {

                        TranspaseObjectPicked.GetComponentInParent<PickItem>().ObjectPicked = this.ObjectPicked;
                        ObjectPicked.GetComponent<PickableObject>().isPickable = true;
                        TranspaseObjectPicked.GetComponentInParent<PickItem>().ObjectPicked.transform.SetParent(TranspaseObjectPicked.GetComponentInParent<PickItem>().LocationToPick);
                        TranspaseObjectPicked.GetComponentInParent<PickItem>().ObjectPicked.transform.position = TranspaseObjectPicked.GetComponentInParent<PickItem>().LocationToPick.position;
                        ObjectPicked.GetComponent<Rigidbody>().useGravity = false;
                        ObjectPicked.GetComponent<Rigidbody>().isKinematic = true;
                        this.ObjectPicked = null;
                        this.ObjectToPickUp = null;

                    }
                    //dejar ingrediente de sarten a plato
                    else if (TranspaseObjectPicked.tag == "plato" && ObjectPicked.tag == "sarten" && TranspaseObjectPicked.GetComponentInParent<ComidaEnPlato>().ObjectPicked == null && ObjectPicked.GetComponentInParent<comidaEnSarten>().ObjectPicked != null) {

                        TranspaseObjectPicked.GetComponentInParent<ComidaEnPlato>().ObjectPicked = ObjectPicked.GetComponentInParent<comidaEnSarten>().ObjectPicked;
                        ObjectPicked.GetComponentInParent<comidaEnSarten>().ObjectPicked.GetComponent<PickableObject>().isPickable = false;
                        TranspaseObjectPicked.GetComponentInParent<ComidaEnPlato>().ObjectPicked.transform.SetParent(TranspaseObjectPicked.GetComponentInParent<ComidaEnPlato>().LocationToPick);
                        TranspaseObjectPicked.GetComponentInParent<ComidaEnPlato>().ObjectPicked.transform.position = TranspaseObjectPicked.GetComponentInParent<ComidaEnPlato>().LocationToPick.position;
                        ObjectPicked.GetComponentInParent<comidaEnSarten>().ObjectPicked.GetComponent<Rigidbody>().useGravity = false;
                        ObjectPicked.GetComponentInParent<comidaEnSarten>().ObjectPicked.GetComponent<Rigidbody>().isKinematic = true;
                        ObjectPicked.GetComponentInParent<comidaEnSarten>().ObjectPicked = null;
                        ObjectPicked.GetComponentInParent<comidaEnSarten>().ObjectToPickUp = null;


                    }//dejar ingrediente de sarten a pan dentro de plato
                    else if (TranspaseObjectPicked.tag == "plato" && TranspaseObjectPicked.GetComponentInParent<ComidaEnPlato>().ObjectPicked != null && TranspaseObjectPicked.GetComponentInParent<ComidaEnPlato>().ObjectPicked.GetComponentInParent<Atributos>().nombre == "pan" && ObjectPicked.tag == "sarten" && ObjectPicked.GetComponentInParent<comidaEnSarten>().ObjectPicked != null)
                    {
                        GameObject objectInSasrten = ObjectPicked.GetComponentInParent<comidaEnSarten>().ObjectPicked;

                        //Colocar segun ingrediente 
                        switch (objectInSasrten.GetComponentInParent<Atributos>().nombre)
                        {

                            case "carneCocinada":

                                TranspaseObjectPicked.GetComponentInParent<ComidaEnPlato>().ObjectPicked.GetComponentInParent<recetaHamburguesa>().carnePicked = objectInSasrten;
                                objectInSasrten.GetComponent<PickableObject>().isPickable = false;
                                TranspaseObjectPicked.GetComponentInParent<ComidaEnPlato>().ObjectPicked.GetComponentInParent<recetaHamburguesa>().carnePicked.transform.SetParent(TranspaseObjectPicked.GetComponentInParent<ComidaEnPlato>().ObjectPicked.GetComponentInParent<recetaHamburguesa>().LocationCarne);
                                TranspaseObjectPicked.GetComponentInParent<ComidaEnPlato>().ObjectPicked.GetComponentInParent<recetaHamburguesa>().carnePicked.transform.position = TranspaseObjectPicked.GetComponentInParent<ComidaEnPlato>().ObjectPicked.GetComponentInParent<recetaHamburguesa>().LocationCarne.position;
                                objectInSasrten.GetComponent<Rigidbody>().useGravity = false;
                                objectInSasrten.GetComponent<Rigidbody>().isKinematic = true;
                                this.ObjectPicked.GetComponentInParent<comidaEnSarten>().ObjectPicked = null;
                                this.ObjectToPickUp = null;

                                break;

                        }




                    }
                    else if (TranspaseObjectPicked.tag == "basura" && this.ObjectPicked != null ) {


                        TranspaseObjectPicked.GetComponentInParent<eliminar>().puedeEliminar = true;

                    }
                    //entregar ingrediente
                    else if (TranspaseObjectPicked.tag == "entrega" && this.ObjectPicked != null)
                    {

                        TranspaseObjectPicked.GetComponentInParent<Entrega>().objetoEntregado = this.ObjectPicked;
                        

                    }

                }    
                
                //dejar en el suelo
                else {

                    ObjectPicked.GetComponent<PickableObject>().isPickable = true;
                    ObjectPicked.transform.SetParent(null);

                    ObjectPicked.GetComponent<Rigidbody>().useGravity = true;
                    ObjectPicked.GetComponent<Rigidbody>().isKinematic = false;
                    ObjectPicked = null;
                    this.ObjectToPickUp = null;

                }

            }

        }


    }

    private void limpiarReferencias()
    {

        if (ObjectPicked != null && ObjectPicked.tag == TranspaseObjectPicked.tag)
        {

            TranspaseObjectPicked = null;
        }
    }
}
    
