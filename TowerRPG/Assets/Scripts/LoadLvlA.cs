using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLvlA : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < -10)
        {
            LoadLevelA();
        }
    }

    public void LoadLevelA()
    {
        SceneManager.LoadScene("levelA");
    }
}
