using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgressiveMonsterRun : MonoBehaviour
{
    float speed = 8;
    float gravity = 9.81f;
    Vector3 moveDir = Vector3.zero;
    private GameObject player;

    private EnemyAttack EA;
    public bool isOn = true;

    Rigidbody rb;

    CharacterController controller;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        EA = GetComponent<EnemyAttack>();
        rb = this.GetComponent<Rigidbody>();
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Vector3 direction = player.transform.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction);


        rotation.x = 0;
        rotation.z = 0;

        rotation *= Quaternion.Euler(0, 90, 0);

        transform.rotation = rotation;
        Physics(isOn);

        float distance = Vector3.Distance(player.transform.position, transform.position);

        if (distance > 2.5f)
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        else
            EA.Punch(transform);


    }



    private void Physics(bool isOn)
    {

        moveDir.y -= (gravity) * Time.deltaTime;
        if (isOn == true)
        {
            controller.Move(moveDir * Time.deltaTime);
        }
    }
}
