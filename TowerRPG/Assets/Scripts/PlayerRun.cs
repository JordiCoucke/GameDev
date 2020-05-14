using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRun : MonoBehaviour
{

    float speed = 10;
    float gravity = 9.81f;
    public Vector3 moveDir = Vector3.zero;

    public bool isOn = true;

    CharacterController controller;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        Moving();
    }

    void Moving()
    {
        if (controller.isGrounded)
        {
            if (Input.GetKey(KeyCode.W))
            {
                MoveUp();
            }

            if (Input.GetKey(KeyCode.S))
            {
                MoveDown();
            }

            if (Input.GetKey(KeyCode.D))
            {
                MoveRight();
            }

            if (Input.GetKey(KeyCode.A))
            {
                MoveLeft();
            }


            if (Input.GetKey(KeyCode.W))
            {
                if (Input.GetKey(KeyCode.D))
                {
                    MoveURight();
                }
            }

            if (Input.GetKey(KeyCode.S))
            {
                if (Input.GetKey(KeyCode.A))
                {
                    MoveDLeft();
                }
            }

            if (Input.GetKey(KeyCode.W))
            {
                if (Input.GetKey(KeyCode.A))
                {
                    MoveULeft();
                }
            }

            if (Input.GetKey(KeyCode.S))
            {
                if (Input.GetKey(KeyCode.D))
                {
                    MoveDRight();
                }
            }


            if (Input.GetKey(KeyCode.LeftShift))
            {
                Jump();
            }

            if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.Space))
            {
                animator.SetBool("ShouldRun", false);
                moveDir = new Vector3(0, 0, 0);
            }
        }
        Physics(isOn);
    }

    private void Physics(bool isOn)
    {
        moveDir.y -= (gravity*4) * Time.deltaTime;
        if (isOn == true)
        {
            controller.Move(moveDir * Time.deltaTime);
        }
    }

    private void Jump()
    {
        animator.SetBool("ShouldRun", false);

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
            moveDir = new Vector3(1, 1.5f, 0);
        else
            moveDir = new Vector3(0, 1.5f, 0);
        moveDir *= speed;
        moveDir = transform.TransformDirection(moveDir);
    }

    private void MoveUp()
    {
        animator.SetBool("ShouldRun", true);

        transform.eulerAngles = new Vector3(0, 315, 0);

        moveDir = new Vector3(1, 0, 0);
        moveDir *= speed;
        moveDir = transform.TransformDirection(moveDir);
    }

    private void MoveDown()
    {
        animator.SetBool("ShouldRun", true);

        transform.eulerAngles = new Vector3(0, 135, 0);

        moveDir = new Vector3(1, 0, 0);
        moveDir *= speed;
        moveDir = transform.TransformDirection(moveDir);
    }

    private void MoveRight()
    {
        animator.SetBool("ShouldRun", true);

        transform.eulerAngles = new Vector3(0, 45, 0);

        moveDir = new Vector3(1, 0, 0);
        moveDir *= speed;
        moveDir = transform.TransformDirection(moveDir);
    }

    private void MoveLeft()
    {
        animator.SetBool("ShouldRun", true);

        transform.eulerAngles = new Vector3(0, 225, 0);

        moveDir = new Vector3(1, 0, 0);
        moveDir *= speed;
        moveDir = transform.TransformDirection(moveDir);
    }




    private void MoveURight()
    {
        animator.SetBool("ShouldRun", true);

        transform.eulerAngles = new Vector3(0, 0, 0);

        moveDir = new Vector3(1, 0, 0);
        moveDir *= speed;
        moveDir = transform.TransformDirection(moveDir);
    }
    private void MoveDLeft()
    {
        animator.SetBool("ShouldRun", true);

        transform.eulerAngles = new Vector3(0, 180, 0);

        moveDir = new Vector3(1, 0, 0);
        moveDir *= speed;
        moveDir = transform.TransformDirection(moveDir);
    }
    private void MoveDRight()
    {
        animator.SetBool("ShouldRun", true);

        transform.eulerAngles = new Vector3(0, 90, 0);

        moveDir = new Vector3(1, 0, 0);
        moveDir *= speed;
        moveDir = transform.TransformDirection(moveDir);
    }
    private void MoveULeft()
    {
        animator.SetBool("ShouldRun", true);

        transform.eulerAngles = new Vector3(0, 270, 0);

        moveDir = new Vector3(1, 0, 0);
        moveDir *= speed;
        moveDir = transform.TransformDirection(moveDir);
    }
}
