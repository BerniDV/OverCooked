using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraProgreso : MonoBehaviour
{
    Slider progreso;

    public float valorMax;
    public float valorAct;

    // Start is called before the first frame update
    void Start()
    {
        valorMax = 1.0f;
        valorAct = 0.0f;
    }

    void Awake()
    {
        progreso = GetComponent<Slider>();
    }


    void ActualizarValor(float valorMax, float valorAct)
    {
        float aux = valorAct / valorMax;
        progreso.value = aux;
    }
    // Update is called once per frame
    void Update()
    {
        ActualizarValor(valorMax, valorAct);
    }
}
