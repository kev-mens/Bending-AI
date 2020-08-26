using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonController : MonoBehaviour
{
    float speed = 1.75f;
    float rotSpeed = 75;
    float gravity = 8;
    float rotX = 0f;
    float rotY = 0f;

    public Transform Bot;
    public Transform Camera; 
    public Transform Head;
    Vector3 moveDir = Vector3.zero;
    CharacterController controller; 
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
    Cursor.visible=false;
    
    //get character controller and animator attached to object
     controller = GetComponent<CharacterController> ();
     anim = GetComponent<Animator> ();   
    }

    // Update is called once per frame
    void Update()
    {
        applyGravity();
        walkForward();
        rotateCharacter();
        leftStrafe();
        rightStrafe();
        punch();
        block();
    }

    private void walkForward()

    {
        if (controller.isGrounded)
        {
            if (Input.GetKey(KeyCode.W))
            {
                anim.SetInteger("w", 1);
                moveDir = new Vector3(0, 0, 1);
                moveDir *= speed;
                moveDir = Bot.TransformDirection(moveDir);
            }
            if (Input.GetKeyUp(KeyCode.W))
            {
                anim.SetInteger("w", 0);
                moveDir = new Vector3(0, 0, 0);
            }
        }
    }

    private void applyGravity()
    {
        //apply gravity
        moveDir.y -= gravity * Time.deltaTime;
        controller.Move(moveDir * Time.deltaTime);
    }

    private void rotateCharacter()
    {
        //find rotation based on mouse postion
        rotX += Input.GetAxis("Mouse X") * rotSpeed * Time.deltaTime;
        Bot.localRotation = Quaternion.AngleAxis(rotX, Vector3.up);

        //camera and head vertical rotations from mouse position
        rotY += Input.GetAxis("Mouse Y") * rotSpeed * -Time.deltaTime;
        Camera.localRotation = Quaternion.AngleAxis(rotY, Vector3.right);
        Head.localRotation = Quaternion.AngleAxis(rotY, Vector3.right);
    }

    private void rightStrafe()
    {
        if (Input.GetKeyDown("d"))
        {
            anim.SetFloat("d", 1f);
        }
        if (Input.GetKeyUp("d"))
        {
            anim.SetFloat("d", -1f);
        }
    }

    private void leftStrafe()
    {
        if (Input.GetKey("a"))
        {
            anim.SetFloat("a", 1f);
        }
        if (Input.GetKeyUp("a"))
        {
            anim.SetFloat("a", -1f);
        }
    }

    private void punch()
    {
        if (Input.GetMouseButtonDown(0))
        {
            anim.SetFloat("leftClick", 1f);
        }
        if (Input.GetMouseButtonUp(0))
        {
            anim.SetFloat("leftClick", -1f);
        }
    }

    private void block()
    {
        if (Input.GetMouseButtonDown(1))
        {
            anim.SetFloat("rightClick", 1f);
        }
        if (Input.GetMouseButtonUp(1))
        {
            anim.SetFloat("rightClick", -1f);
        }
    }
}
