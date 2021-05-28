using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreacionCoche : MonoBehaviour
{
    // Start is called before the first frame update
    public bool[] existeCoche;
    public GameObject[] cocheEnCarril;
    public GameObject[] coches;
    public float timeToNextCar;

    void Start()
    {
        existeCoche = new bool[2];
        cocheEnCarril = new GameObject[2];
        for (int i = 0; i < 2; ++i) existeCoche[i] = false;


        //coches = new GameObject[4];
        //timeToNextCar = 25.0f;
        timeToNextCar = 10.0f; // luego cada random entre 10 y 20 segundos.
    }

    int primerCarrilLibre()
    {
        for(int i = 0; i<2; ++i)
        {
            if (!existeCoche[i]) return i;
        }
        return -1;
    }

    void ocuparCarril(int index)
    {
        int randCoche = Random.Range(0, 4);
        cocheEnCarril[index] = (GameObject) Instantiate(coches[randCoche]);
        
        existeCoche[index] = true;

        //si index = 0 entonces girar 0 grados. left to right. mover a -85/0/20
        //si index = 1 entonces girar 180 grados. right to left. mover a  85/0/40
        switch (index)
        {
            case 0:
                //darle direccion a la hora de conducir;
                cocheEnCarril[index].gameObject.GetComponent<MoverCoche>().inverse = 1.0f;
                //Colocarlo;
                cocheEnCarril[index].gameObject.transform.Translate(-85.0f, 0.0f, 20.0f);
                break;

            case 1:
                //darle direccion a la hora de conducir;
                cocheEnCarril[index].gameObject.GetComponent<MoverCoche>().inverse = -1.0f;
                //Colocarlo;
                cocheEnCarril[index].gameObject.transform.Translate( 85.0f, 0.0f, 40.0f);
                cocheEnCarril[index].gameObject.transform.Rotate(0.0f, 180.0f, 0.0f);
                break;
        }
        
    }

    void DestruirCoche()
    {
        if (existeCoche[0] && cocheEnCarril[0].transform.position.x >=  85)
        {
            existeCoche[0] = false;
            Destroy(cocheEnCarril[0].gameObject);
        }

        if (existeCoche[1] && cocheEnCarril[1].transform.position.x <= -85)
        {
            existeCoche[1] = false;
            Destroy(cocheEnCarril[1].gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        timeToNextCar -= Time.deltaTime;
        if (timeToNextCar <= 0.0f)
        {
            timeToNextCar = Random.Range(5.0f, 15.0f);
            int index = primerCarrilLibre();
            if(index >= 0)
            {
                //hay algun carril libre.
                ocuparCarril(index);
            }
            
        }

        DestruirCoche();
    }
}
