using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SartenStatus : MonoBehaviour
{
    public bool isUsed;

    public bool itemEnSarten;
    public GameObject item;

    // Start is called before the first frame update
    void Start()
    {
        isUsed = false;
        itemEnSarten = false;
        item = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (itemEnSarten)
        {
            Vector3 sartenPosition = transform.position;
            item.transform.position = sartenPosition + new Vector3(0, 1, 0);
        }
    }
}
