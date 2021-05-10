using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeObject : MonoBehaviour
{

    public GameObject Object1;
    public GameObject Object2;
    public int select;
 
    // Start is called before the first frame update
    void Start()
    {

        Object1.gameObject.SetActive(true);
        Object2.gameObject.SetActive(false);
        select = 1;
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    public void changeModel()
    {

        setEstate();
    }

    private void setEstate()
    {

        switch (select)
        {

            case 1:

                Object2.transform.position = Object1.transform.position;
                
                Object1.gameObject.SetActive(false);
                Object2.gameObject.SetActive(true);
                select = 2;
                break;

            case 2:

                Object1.transform.position = Object2.transform.position;
                Object1.gameObject.SetActive(true);
                Object2.gameObject.SetActive(false);
                select = 1;
                break;
        }

    }

}
