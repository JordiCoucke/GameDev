using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanBePunched : MonoBehaviour
{
    float distance;
    GameObject player;
    Rigidbody rb ;
    CharacterController charactercontroller;

    AgressiveMonsterRun amr;
    // Start is called before the first frame update
    void Start()
    {
        amr = GetComponent<AgressiveMonsterRun>();
        charactercontroller = GetComponent<CharacterController>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(player.transform.position, transform.position);
        EndMomentum(player.transform);
    }

    public bool IsPunchable()
    {
        bool isPunchable = false;
        if(distance < 6)
        {
            isPunchable = true;
        }
        return isPunchable;
    }


    public void IsPunched()
    {
        rb = this.GetComponent<Rigidbody>();
        amr.isOn = false;
        rb.AddForce(new Vector3(-5f, 0, 0) * -1f, ForceMode.Impulse);
    }

    void EndMomentum(Transform distance)
    {

        if (Vector3.Distance(transform.position, distance.position) > 10)
        {
            amr.isOn = true;
        }
    }
}
