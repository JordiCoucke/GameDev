using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    CharacterController controller;
    Animator animator;
    GameObject Monster;
    CanBePunched CBP;
    CharacterController monsterConroller;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (Input.GetKey(KeyCode.Space))
        {
            animator.SetBool("ShouldAttack", true);
           
        }

        Punch();

    }


    void Punch()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {

            animator.SetBool("ShouldAttack", false);

            foreach (GameObject item in GameObject.FindGameObjectsWithTag("Monster"))
            {
                CBP = item.GetComponent<CanBePunched>();
                if (CBP.IsPunchable())
                {
                    CBP.IsPunched();
                }
            }
        }
    }

}
