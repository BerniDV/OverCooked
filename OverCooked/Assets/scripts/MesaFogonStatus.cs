using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MesaFogonStatus : MonoBehaviour
{
    public bool isUsed;

    public bool itemEnMesaFogon;
    public GameObject item;

    // Start is called before the first frame update
    void Start()
    {
        isUsed = false;

        itemEnMesaFogon = false;
        item = null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
