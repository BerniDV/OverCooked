using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickItem : MonoBehaviour
{

    public GameObject ObjectToPickUp;
    public GameObject ObjectPicked;
    public Transform LocationToPick;

    // Start is called before the first frame update
    void Start()
    {
        
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

                ObjectPicked = ObjectToPickUp;
                ObjectPicked.GetComponent<PickableObject>().isPickable = false;
                ObjectPicked.transform.SetParent(LocationToPick);
                ObjectPicked.transform.position = LocationToPick.position;
                ObjectPicked.GetComponent<Rigidbody>().useGravity = false;
                ObjectPicked.GetComponent<Rigidbody>().isKinematic = true;


            }
            

        }
        else if (ObjectPicked != null)
        {

            if (Input.GetKeyDown("space"))
            {

                ObjectPicked.GetComponent<PickableObject>().isPickable = true;
                ObjectPicked.transform.SetParent(null);

                //Poner como parent la mesa o el plato

                ObjectPicked.GetComponent<Rigidbody>().useGravity = true;
                ObjectPicked.GetComponent<Rigidbody>().isKinematic = false;
                ObjectPicked = null;

            }

        }


    }
}
