using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    float distance;
    GameObject player;
    Rigidbody rb;
    CharacterController playerController;

    private bool isBeingPunched = false;
    PlayerRun playerFysics;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerFysics = player.GetComponent<PlayerRun>();
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance( transform.position, player.transform.position);
        if(isBeingPunched == true)
            EndMomentum(player.transform);
    }

    public void Punch(Transform transformRotation)
    {
        if (isBeingPunched != true)
        {
            rb = player.GetComponent<Rigidbody>();
            playerFysics.isOn = false;
            rb.AddForce(new Vector3(transformRotation.position.x/transformRotation.position.x, transformRotation.position.y / transformRotation.position.y,
                transformRotation.position.z / transformRotation.position.z) * -20f, ForceMode.Impulse);
            isBeingPunched = true;
        }
    }

    void EndMomentum(Transform distance)
    {

        if (Vector3.Distance(transform.position, distance.position) > 10)
        {
            rb.velocity = new Vector3(0, 0, 0);
            playerFysics.isOn = true;
            isBeingPunched = false;
        }
    }
}
