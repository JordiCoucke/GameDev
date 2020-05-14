using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y <= -9 )
        {
            Dies();
        }
    }

    void Dies()
    {
        SceneManager.LoadScene("GameOver");
    }
}
