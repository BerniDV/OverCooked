using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class eliminar : MonoBehaviour
{

    public GameObject ObjectToDelete;
    public bool puedeEliminar;

    // Start is called before the first frame update
    void Start()
    {

        puedeEliminar = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (ObjectToDelete!=null && puedeEliminar)
        {

            Object.Destroy(ObjectToDelete);
            puedeEliminar = false;
        }

    }
}
