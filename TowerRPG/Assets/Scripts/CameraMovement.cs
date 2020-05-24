using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;            
    public float smoothing = 6f;       
    private float CameraYPos = 16.5f;
    Vector3 offset;                     

    void Start()
    {
       
        offset = transform.position - target.position;
    }

    void Update()
    {
    
        Vector3 targetCamPos = target.position + offset;

        
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, CameraYPos, transform.position.z);
    }
}
