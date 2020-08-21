using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    //public CharacterController controller;
    public Rigidbody rigidbody;
    public Vector3 movement;
    public Transform cam;
    public Vector3 moveDir;
    public float movementSpeed = 1f ;
    public float turnSmoothTime = 0.1f;
    public float targetAngle;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal"); //a to -1, d to 1
        float vertical = Input.GetAxisRaw("Vertical"); //s to -1. w to 1
        movement = new Vector3(horizontal, 0f, vertical); //unit vector on xz plane

        //moveDir = Quaternion.Euler(0f,targetAngle, 0f)*Vector3.forward;        

        if (movement.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(movement.x, movement.z) * Mathf.Rad2Deg + cam.eulerAngles.y; //due to unity's coordinate system orientation
            
            transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);      // not useful for bending mechanic
            rigidbody.MoveRotation(transform.rotation);                    //used to make character rotate in direection of movement

            moveDir = Quaternion.Euler(0f, targetAngle, 0f)*Vector3.forward;
        }
    }

    void FixedUpdate()
    {
        moveCharacter(moveDir.normalized);
    }

    private void moveCharacter(Vector3 direction)
    {
        rigidbody.MovePosition(transform.position + (direction * movementSpeed * Time.deltaTime)); //moves to given position
        rigidbody.angularVelocity = Vector3.zero; ///prevent rotation from environment
    }
    /*
        }*/
}
