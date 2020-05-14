using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUI : MonoBehaviour
{
    public Text LevelIndicator;
    public string LvlLetter = "B";
    private string TileNumberX = "0";
    private string TileNumberY = "0";
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        LevelIndicator.text = LvlLetter + TileNumberX + "." + TileNumberY;
        AddNextTile();
    }

    void AddNextTile()
    {
        int tileConversionIntX = int.Parse(TileNumberX);
        int tileConversionIntY = int.Parse(TileNumberY);
        tileConversionIntX = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerLocationTracker>().location[0];
        tileConversionIntY = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerLocationTracker>().location[1];
        TileNumberX = tileConversionIntX.ToString();
        TileNumberY = tileConversionIntY.ToString();
    }
}
