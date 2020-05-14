using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManagerScript : MonoBehaviour
{

    public List<GameObject> Tiles;
    private int[] layout = {0,0,0,0};
    // Start is called before the first frame update
    void Start()
    {
        RandomizeTileLayout();
        Tiles = new List<GameObject>();
        Tiles.Add(GameObject.FindGameObjectWithTag("StartTile").gameObject);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void AddTile(GameObject tile)
    {
        Tiles.Add(tile);
    }

    public void RandomizeTileLayout()
    {
        for (int i = 0; i < layout.Length; i++)
        {
            layout[i] = Random.Range(2,3);
        }
    }

}
