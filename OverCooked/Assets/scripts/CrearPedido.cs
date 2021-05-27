using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrearPedido : MonoBehaviour
{
    //public GameObject pedido;
    public GameObject canvas;
    public int nPedidosDiferentes;

    //public GameObject[] listaPedidos;
    public Slider[]   listaPedidos;
    public GameObject[]   imagenPedidos;
    public string[] nombrePedidos;
    public bool[] actividadPedidos;
    public float[] progresoPedidos;
    
    float timeToNextPedido;
    float timePedido;

    // Start is called before the first frame update
    void Start()
    {

        nPedidosDiferentes = 7;

        //listaPedidos = new GameObject[4];
        listaPedidos     = new Slider[4];
        imagenPedidos    = new  GameObject[4];
        nombrePedidos    = new string[4];
        actividadPedidos = new   bool[4];
        progresoPedidos  = new  float[4];

        canvas = GameObject.FindWithTag("canvasUI");

        //for (int i = 0; i < 4; ++i) listaPedidos[i] = null;
        for (int i = 0; i < 4; ++i) actividadPedidos[i] = false;
        
        timeToNextPedido = 12.0f; // 12 segundos
        timePedido = 60.0f; //60 segundos
    }

    int primerPedidoLibre()
    {
        for(int i=0; i<4; ++i)
        {
            if (!actividadPedidos[i]) return i;
        }
        return -1;
    }

    public void DestroyPedido(int index)
    {
        if (actividadPedidos[index])
        {

            actividadPedidos[index] = false;
            progresoPedidos[index] = 0.0f;
            nombrePedidos[index] = "";

            Destroy(listaPedidos[index].gameObject);
            Destroy(imagenPedidos[index].gameObject);

        }
    }

    void CrearImagenNombrePedido(int index)
    {
        int randPedido = Random.Range(0, nPedidosDiferentes);

        switch (randPedido)
        {
            case 0:
                imagenPedidos[index] = (GameObject)Instantiate(GameObject.FindGameObjectWithTag("ImagenPedidoPanHamburguesa"));
                nombrePedidos[index] = "hamburguesaDeCarne";
                break;
            case 1:
                imagenPedidos[index] = (GameObject)Instantiate(GameObject.FindGameObjectWithTag("ImagenPedidoPanHamburguesaCol"));
                nombrePedidos[index] = "hamburguesaDeCarneConEnsalada";
                break;
            case 2:
                imagenPedidos[index] = (GameObject)Instantiate(GameObject.FindGameObjectWithTag("ImagenPedidoPanHamburguesaColTomate"));
                nombrePedidos[index] = "hamburguesaDeCarneConEnsaladaConTomate";
                break;
            case 3: 
                imagenPedidos[index] = (GameObject)Instantiate(GameObject.FindGameObjectWithTag("ImagenPedidoArroz"));
                nombrePedidos[index] = "SopaDeArroz";
                break;
            case 4:
                imagenPedidos[index] = (GameObject)Instantiate(GameObject.FindGameObjectWithTag("ImagenPedidoArrozTomate"));
                nombrePedidos[index] = "SopaDeArrozConTomate";
                break;
            case 5:
                imagenPedidos[index] = (GameObject)Instantiate(GameObject.FindGameObjectWithTag("ImagenPedidoTacoCarne"));
                nombrePedidos[index] = "HotDog";
                break;
            case 6:
                imagenPedidos[index] = (GameObject)Instantiate(GameObject.FindGameObjectWithTag("ImagenPedidoTacoCarneTomate"));
                nombrePedidos[index] = "HotDogConQuetxup";
                break;
        }

        imagenPedidos[index].gameObject.transform.Translate(0, 1000.0f, 0); //perfecto para moverla correctamente
        //imagenPedidos[index].gameObject.transform.Translate(-450.0f + (index) * 300.0f, 230.0f, -180.0f);
        imagenPedidos[index].gameObject.transform.Translate(-450.0f + (index) * 300.0f, 250.0f, -180.0f); // de 230 a 250 para el fullhd loco
        imagenPedidos[index].gameObject.transform.SetParent(canvas.transform, false);
    }

    // Update is called once per frame
    void Update()
    {
        
        //esperar fins nou pedido
        timeToNextPedido -= Time.deltaTime;
        if (timeToNextPedido <= 0.0f)
        {
            //Encontrar primer hueco libre;
            int index = primerPedidoLibre();
            if(index >= 0)
            {
                //creariamos primer pedido disponible
                CrearImagenNombrePedido(index);
                /*
                imagenPedidos[index] = (GameObject)Instantiate(GameObject.FindGameObjectWithTag("ImagenPedido"));
                imagenPedidos[index].gameObject.transform.Translate(0, 1000.0f, 0); //perfecto para moverla correctamente
                imagenPedidos[index].gameObject.transform.Translate(-450.0f + (index) * 300.0f, 230.0f, -180.0f);
                imagenPedidos[index].gameObject.transform.SetParent(canvas.transform, false);
                */
                listaPedidos[index] = Instantiate(GameObject.FindGameObjectWithTag("BarraProgreso").GetComponent<Slider>());
                listaPedidos[index].gameObject.transform.Translate(0, 1000.0f, 0); //perfecto para moverla correctamente
                //listaPedidos[index].gameObject.transform.Translate(-450.0f+(index)*300.0f, 140.0f, -180.0f); 
                listaPedidos[index].gameObject.transform.Translate(-450.0f + (index) * 300.0f, 200.0f, -180.0f); // de 140 a 200 para el fullhd loco
                listaPedidos[index].gameObject.transform.SetParent(canvas.transform, false);

                actividadPedidos[index] = true;
                progresoPedidos[index] = 0.0f;

                //listaPedidos[index].gameObject.transform.position += new Vector3(0.0f, 1000.0f, 0.0f);
            }

            timeToNextPedido = 5.0f;
        }

        //Actualitzar Pedidos
        for(int i=0; i<4; ++i)
        {
            if (actividadPedidos[i]) //solo actualizar activos
            {
                progresoPedidos[i] += Time.deltaTime;
                listaPedidos[i].value = progresoPedidos[i] / timePedido;
            }
        }

        //Mirar si algun progresoPedido arriba a timePedido
        for(int i=0; i<4; ++i)
        {
            if (progresoPedidos[i] >= timePedido) DestroyPedido(i);
        }

        //Mirar si se entrega algun pedido correcto
        //por ahora las teclas 1, 2, 3, 4 destruyen el pedido correspondiente.
        if (Input.GetKeyDown("1")) DestroyPedido(0);
        if (Input.GetKeyDown("2")) DestroyPedido(1);
        if (Input.GetKeyDown("3")) DestroyPedido(2);
        if (Input.GetKeyDown("4")) DestroyPedido(3);
    }
}
