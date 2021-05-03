using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{

    public CharacterController controller;
    public Rigidbody playerRigidBody;
    public float speed = 6.0f;

    private float inputX;
    private float inputZ;

    bool isIdle;

    public float rotateVelocity = 0.1f;
   

    // Start is called before the first frame update
    void Start()
    {

        playerRigidBody = GetComponent<Rigidbody>();
        isIdle = true;
    }

    // Update is called once per frame
    void Update()
    {

        inputX = Input.GetAxis("Horizontal");
        inputZ = Input.GetAxis("Vertical");

        //transform.LookAt(transform.position + new Vector3(inputX, 0, inputZ));

        //playerRigidBody.velocity = new Vector3(inputX * speed, playerRigidBody.velocity.y , inputZ*speed);
        controller.Move(new Vector3(inputX * speed * Time.deltaTime, playerRigidBody.velocity.y, inputZ * speed * Time.deltaTime));
        var angle = Mathf.Atan2(inputZ, inputX) * Mathf.Rad2Deg;

        Vector3 move = new Vector3(inputX * rotateVelocity * Time.deltaTime, 0, inputZ * rotateVelocity * Time.deltaTime);

        if (move.magnitude > 0.1f)
        {
            transform.forward = move;
            if (isIdle)
            {
                //animator.SetTrigger("run");
                isIdle = false;
            }
        }
        else if (!isIdle)
        {
            //animator.SetTrigger("idle");
            isIdle = true;
        }

    }
}
