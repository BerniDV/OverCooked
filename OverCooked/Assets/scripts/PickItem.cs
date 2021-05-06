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
            TranspaseObjectPicked = other.gameObject;
            other.GetComponentInParent<PickItem>().ObjectToPickUp = this.ObjectPicked;
        }
    }


    private void OnTriggerExit(Collider other)
    {

        if (other.tag == "Mesa")
        {

            TranspaseObjectPicked = null;
            other.GetComponentInParent<PickItem>().ObjectToPickUp = null;
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

        if(ObjectToPickUp != null && ObjectToPickUp.GetComponent<PickableObject>().isPickable == true && ObjectPicked == null)
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

                    if (TranspaseObjectPicked.GetComponentInParent<PickItem>().ObjectPicked != null)
                    {

                        ObjectPicked = TranspaseObjectPicked.GetComponentInParent<PickItem>().ObjectPicked;
                        ObjectPicked.GetComponent<PickableObject>().isPickable = false;
                        ObjectPicked.transform.SetParent(LocationToPick);
                        ObjectPicked.transform.position = LocationToPick.position;
                        ObjectPicked.GetComponent<Rigidbody>().useGravity = false;
                        ObjectPicked.GetComponent<Rigidbody>().isKinematic = true;
                        TranspaseObjectPicked.GetComponentInParent<PickItem>().ObjectPicked = null;


                    }
                    else
                    {

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
        else if (ObjectPicked != null && this.tag == "item_pickable")
        {

            if (Input.GetKeyDown("space"))
            {

                if (TranspaseObjectPicked != null)
                {

                    if(TranspaseObjectPicked.GetComponentInParent<PickItem>().ObjectPicked == null){

                        TranspaseObjectPicked.GetComponentInParent<PickItem>().ObjectPicked = this.ObjectPicked;
                        ObjectPicked.GetComponent<PickableObject>().isPickable = true;
                        TranspaseObjectPicked.GetComponentInParent<PickItem>().ObjectPicked.transform.SetParent(TranspaseObjectPicked.GetComponentInParent<PickItem>().LocationToPick);
                        TranspaseObjectPicked.GetComponentInParent<PickItem>().ObjectPicked.transform.position = TranspaseObjectPicked.GetComponentInParent<PickItem>().LocationToPick.position;
                        ObjectPicked.GetComponent<Rigidbody>().useGravity = false;
                        ObjectPicked.GetComponent<Rigidbody>().isKinematic = true;
                        this.ObjectPicked = null;
                        this.ObjectToPickUp = null;
                    }
                }
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
}
