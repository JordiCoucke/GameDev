using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLocationTracker : MonoBehaviour
{
    public int[] location = { 0, 0 };
    public List<int[]> locationList = new List<int[]>();
    public bool newTerrain = true;
    public int planeCount = 0;
    WorldManagerScript WMScript;

    // Start is called before the first frame update
    void Start()
    {
        locationList.Add(new int[] { 0, 0 });
        WMScript = GameObject.Find("WorldManager").GetComponent<WorldManagerScript>();
        WMScript.AddTile(GameObject.FindGameObjectWithTag("StartTile"));
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void playerWentLeft()
    {
        location[0]--;
    }
    public void playerWentRight()
    {
        location[0]++;
    }
    public void playerWentUp()
    {
        location[1]++;
    }
    public void playerWentDown()
    {
        location[1]--;
    }

    public void BeenHereBefore()
    {

        if (HasItemInList())
        {
            newTerrain = false;
        }
        else
        {
            newTerrain = true;
            locationList.Add(new int[] { location[0], location[1] });
        }
    }

    private bool HasItemInList()
    {
        bool hasItem = false;

        for (int i = 0; i < locationList.Count; i++)
        {
            if (locationList[i][0] == location[0] && locationList[i][1] == location[1])
            {
                hasItem = true;
            }
        }

        return hasItem;
    }

    public int GetLocationIndex()
    {
        int index = 0;
        for (int i = 0; i < locationList.Count; i++)
        {
            if (locationList[i][0] == location[0] && locationList[i][1] == location[1])
            {
                index = i;
            }
        }

        return index;
    }
}
