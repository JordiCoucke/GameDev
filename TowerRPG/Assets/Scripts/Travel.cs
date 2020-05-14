using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Travel : MonoBehaviour
{
    public GameObject newPlane;
    private GameObject CurrentTerain;
    private GameObject EnvironmentObjects;

    public string direction;

    PlayerLocationTracker PLT;
    WorldManagerScript WMS;

    Travel travel;


    // Start is called before the first frame update
    void Start()
    {
        PLT = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerLocationTracker>();
        WMS = GameObject.FindGameObjectWithTag("WorldManager").GetComponent<WorldManagerScript>();

        EnvironmentObjects = transform.parent.parent.parent.GetChild(1).gameObject;

        CurrentTerain = transform.parent.parent.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameObject plane = new GameObject();
            plane.name = "InstantiatedPlane";
            Quaternion quater = new Quaternion(0, 0, 0, 0);

            if (direction == "down")
            {
                    PLT.playerWentDown();
                    PLT.BeenHereBefore();

                if (PLT.newTerrain)
                {
                    Vector3 terrainSize = new Vector3(0, 0, 28);
                    Vector3 newPosition = CurrentTerain.transform.position - terrainSize;

                    plane = Instantiate(newPlane, newPosition, quater);

                    AssignGate(plane);
                    WMS.AddTile(plane);

                    GenerateTerrainObjects(plane);

                }
                else
                {
                    WMS.Tiles[PLT.GetLocationIndex()].SetActive(true);
                }

            }
            if (direction == "up")
            {
                PLT.playerWentUp();
                PLT.BeenHereBefore();

                if (PLT.newTerrain)
                {
                    Vector3 terrainSize = new Vector3(0, 0, 28);
                    Vector3 newPosition = CurrentTerain.transform.position + terrainSize;

                    plane = Instantiate(newPlane, newPosition, quater);

                    AssignGate(plane);
                    WMS.AddTile(plane);

                    GenerateTerrainObjects(plane);

                }
                else
                {
                    WMS.Tiles[PLT.GetLocationIndex()].SetActive(true);
                }

            }
            if (direction == "left")
            {
                PLT.playerWentLeft();
                PLT.BeenHereBefore();

                if (PLT.newTerrain)
                {
                    Vector3 terrainSize = new Vector3(28, 0, 0);
                    Vector3 newPosition = CurrentTerain.transform.position - terrainSize;

                    plane = Instantiate(newPlane, newPosition, quater);

                    AssignGate(plane);
                    WMS.AddTile(plane);

                    GenerateTerrainObjects(plane);
                }
                else
                {
                    WMS.Tiles[PLT.GetLocationIndex()].SetActive(true);
                }

            }
            if (direction == "right")
            {
                PLT.playerWentRight();
                PLT.BeenHereBefore();

                if (PLT.newTerrain)
                {
                    Vector3 terrainSize = new Vector3(28, 0, 0);
                    Vector3 newPosition = CurrentTerain.transform.position + terrainSize;

                    plane = Instantiate(newPlane, newPosition, quater);
                    AssignGate(plane);
                    WMS.AddTile(plane);

                    GenerateTerrainObjects(plane);
                }
                else
                {
                    WMS.Tiles[PLT.GetLocationIndex()].SetActive(true);
                }
            }
            CurrentTerain.SetActive(false);
        }
    }

    private void RemoveArch(int direction, GameObject terrain)
    {
        Destroy(terrain.transform.GetChild(0).GetChild(direction).gameObject);
        transform.parent.parent.GetChild(direction).gameObject.SetActive(false);
    }

    private void GenerateTerrainObjects(GameObject plane)
    {
        travel.EnvironmentObjects = Instantiate(Resources.Load("EnvironmentObjects", typeof(GameObject)) as GameObject);
        DestroyChildren(travel.EnvironmentObjects);
        travel.EnvironmentObjects.transform.parent = plane.transform;
        travel.EnvironmentObjects.name = "EnvironmentObjects";
    }

    private void DestroyChildren(GameObject parent)
    {
        int childCount = parent.transform.childCount;

        for (int i = 0; i < childCount; i++)
        {
            Destroy(parent.transform.GetChild(i).gameObject);
        }
    }

    private void AssignGate(GameObject plane)
    {
        travel = plane.transform.GetChild(0).GetChild(1).GetChild(0).GetComponent<Travel>();
        travel.newPlane = this.newPlane;
        travel.direction = "left";

        travel = plane.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Travel>();
        travel.newPlane = this.newPlane;
        travel.direction = "right";

        travel = plane.transform.GetChild(0).GetChild(2).GetChild(0).GetComponent<Travel>();
        travel.newPlane = this.newPlane;
        travel.direction = "down";

        travel = plane.transform.GetChild(0).GetChild(3).GetChild(0).GetComponent<Travel>();
        travel.newPlane = this.newPlane;
        travel.direction = "up";

        PLT.planeCount++;
        plane.name = "Terrain" + PLT.planeCount;
    }
}
