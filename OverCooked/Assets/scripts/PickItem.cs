using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickItem : MonoBehaviour
{
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
        if (Input.GetKeyDown("space"))
        {
            Vector3 origin = transform.position;
            Vector3 fwd = transform.TransformDirection(Vector3.forward);
            float distance = 4.0f;
            RaycastHit hit;

            if (Physics.Raycast(origin, fwd, out hit, distance))
            {
                //if( item is pickable) destroy item por ahora
                if(hit.transform.tag == "item_pickable")
                {
                    Destroy(hit.transform.gameObject);
                }
            }

        }
    }
}
