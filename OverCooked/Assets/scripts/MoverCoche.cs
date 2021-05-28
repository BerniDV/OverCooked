using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverCoche : MonoBehaviour
{
    public Rigidbody rigidBody;
    public float speed;
    public float inverse;

    // Start is called before the first frame update
    void Start()
    {
        speed = 9.0f;
        //inverse = -1.0f;
    }
    
    // Update is called once per frame
    void Update()
    {
        rigidBody.MovePosition(rigidBody.position + new Vector3(1.0f, 0.0f, 0.0f) * speed * Time.deltaTime * inverse); ;
    }
}
