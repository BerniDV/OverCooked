using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatoStatus : MonoBehaviour
{
    public bool isUsed;

    public bool itemEnPlato;
    public GameObject item;

    // Start is called before the first frame update
    void Start()
    {
        isUsed = false;

        itemEnPlato = false;
        item = null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
