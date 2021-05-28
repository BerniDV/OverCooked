using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JugarCualquierLevel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("5")) SceneManager.LoadScene("Level01");
        if (Input.GetKeyDown("6")) SceneManager.LoadScene("Level02");
        if (Input.GetKeyDown("7")) SceneManager.LoadScene("Level03");
        if (Input.GetKeyDown("8")) SceneManager.LoadScene("Level04");
        if (Input.GetKeyDown("9")) SceneManager.LoadScene("Level05");
    }
}
