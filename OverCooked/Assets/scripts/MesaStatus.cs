using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MesaStatus : MonoBehaviour
{
    public bool isUsed;

    public bool itemEnMesa;
    public GameObject item;

    // Start is called before the first frame update
    void Start()
    {
        isUsed = false;

        itemEnMesa = false;
        item = null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
