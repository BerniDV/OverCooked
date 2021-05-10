using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class eliminar : MonoBehaviour
{

    public GameObject ObjectToDelete;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (ObjectToDelete!=null)
        {

            Object.Destroy(ObjectToDelete);
        }

    }
}
