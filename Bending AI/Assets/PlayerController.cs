using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;



    // Update is called once per frame
    void Update()
    {
        leftStrafe();
        rightStrafe();
        punch();
        block();
    }

    private void rightStrafe()
    {
        if (Input.GetKeyDown("d"))
        {
            animator.SetFloat("d", 1f);
        }
        if (Input.GetKeyUp("d"))
        {
            animator.SetFloat("d", -1f);
        }
    }

    private void leftStrafe()
    {
        if (Input.GetKey("a"))
        {
            animator.SetFloat("a", 1f);
        }
        if (Input.GetKeyUp("a"))
        {
            animator.SetFloat("a", -1f);
        }
    }

    private void punch()
    {
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetFloat("leftClick", 1f);
        }
        if (Input.GetMouseButtonUp(0))
        {
            animator.SetFloat("leftClick", -1f);
        }
    }

    private void block()
    {
        if (Input.GetMouseButtonDown(1))
        {
            animator.SetFloat("rightClick", 1f);
        }
        if (Input.GetMouseButtonUp(1))
        {
            animator.SetFloat("rightClick", -1f);
        }
    }


}
