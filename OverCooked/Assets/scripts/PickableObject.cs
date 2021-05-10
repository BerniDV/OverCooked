using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PickableObject : MonoBehaviour
{

    public bool isPickable = true;
    

    private void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if(other.tag == "item_pickable")
        {

            
            other.GetComponentInParent<PickItem>().ObjectToPickUp = this.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        
        if(other.tag == "item_pickable")
        {

            other.GetComponentInParent<PickItem>().ObjectToPickUp = null;
        }
    }
}
