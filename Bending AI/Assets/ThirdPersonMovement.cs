using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    //public CharacterController controller;
    public Rigidbody rigidbody;
    public Vector3 movement;

    public float movementSpeed = 10 ;
    public float turnSmoothTime = 0.1f;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal"); //a to -1, d to 1
        float vertical = Input.GetAxisRaw("Vertical"); //s to -1. w to 1
        movement = new Vector3(horizontal, 0f, vertical);    //normalise to keep same magnitude in all movements        
    }

    void FixedUpdate()
    {
        moveCharacter(movement);
    }

    private void moveCharacter(Vector3 direction)
    {
        rigidbody.MovePosition(transform.position + (direction * movementSpeed * Time.deltaTime));
        rigidbody.angularVelocity = Vector3.zero; ///prevent rotation from environment
    }
    /*if (movement.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(movement.x, movement.z) * Mathf.Rad2Deg; //due to unity's coordinate system orientation
            transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);

            rigidbody.MovePosition(movement + transform.position);
            //controller.Move(movement);
        }*/
}
