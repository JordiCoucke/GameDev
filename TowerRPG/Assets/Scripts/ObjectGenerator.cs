using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGenerator : MonoBehaviour
{

    public int SmallObjectCount;
    public int MediumObjectCount;
    public int LargeObjectCount;

    public int MonsterCount;

    private Quaternion rotation;

    public string level;

    // Start is called before the first frame update
    void Start()
    {

        GenerateEnvironmentObjects(level);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GenerateEnvironmentObjects(string level)
    {
        int sAmount = SetSmallObjectAmount(10,15);
        int mAmount = SetMediumObjectAmount(0, 5);
        int lAmount = SetLargeObjectAmount(0, 4);

        int monAmount = SetMonsterAmount(0,4);

        SpawnRandomSmall(sAmount);
        SpawnRandomMedium(mAmount);
        SpawnRandomLarge(lAmount);

        SpawnRandomMonster(monAmount);
        SpawnGoal();

    }
    void SpawnGoal()
    {
        int i = Random.Range(0, 10);
        if (i == 2)
        {
            SpawnObject(level, "Goal", "Goal");
        }
    }

    int SetSmallObjectAmount(int min, int max)
    {
        int smallObjectAmount;
        smallObjectAmount = Random.Range(min, max);
        return smallObjectAmount;
    }

    int SetMediumObjectAmount(int min, int max)
    {
        int mediumObjectAmount;
        mediumObjectAmount = Random.Range(min, max);
        return mediumObjectAmount;
    }

    int SetLargeObjectAmount(int min, int max)
    {
        int largeObjectAmount;
        largeObjectAmount = Random.Range(min, max);
        return largeObjectAmount;
    }

    int SetMonsterAmount(int min, int max)
    {
        int monsterAmount;
        monsterAmount = Random.Range(min, max);
        if(GameObject.FindGameObjectWithTag("StartTile"))
        {
            return 0;
        }
        return monsterAmount;
    }


    void SpawnObject(string level, string type, string assetName)
    {
        Vector3 location = GenerateLocation(type);
        Quaternion rotation = GenerateRotation(type);

        GameObject instance = Instantiate(Resources.Load(level+"/"+type+"/"+assetName, typeof(GameObject)) as GameObject,location,rotation);

        instance.transform.parent = this.gameObject.transform;

        if (transform.childCount > 1)
        {
            while (IsAtTheSameSpot(instance.transform.position, transform.childCount - 2))
            {
                Destroy(instance);
                location = GenerateLocation(type);
                rotation = GenerateRotation(type);

                instance = Instantiate(Resources.Load(level + "/" + type + "/" + assetName, typeof(GameObject)) as GameObject, location, rotation);
                instance.transform.parent = this.gameObject.transform;
            }
        }

    }


    void SpawnRandomSmall(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            SpawnObject(level, "Small", "grass" + Random.Range(0, SmallObjectCount));
        }
    }

    void SpawnRandomMedium(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            SpawnObject(level, "Medium" , "rock" + Random.Range(0, MediumObjectCount));
        }
    }

    void SpawnRandomLarge(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            SpawnObject(level,"Large", "tree" + Random.Range(0, LargeObjectCount));
        }
    }

    void SpawnRandomMonster(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            SpawnObject(level, "Monsters", "monster" + Random.Range(0, MonsterCount));
        }
    }

    Vector3 GenerateLocation(string type)
    {
        Vector3 result = new Vector3();

        Vector3 RD_Limit = new Vector3(12,2.5f,-12f);
        Vector3 LD_Limit = new Vector3(-12, 2.5f, -12f);
        Vector3 RU_Limit = new Vector3(12, 2.5f, 12f);
        Vector3 LU_Limit = new Vector3(-12, 2.5f, 12f);

        Vector3 t = transform.parent.gameObject.transform.position;

        float lengthLimit = Random.Range((t.x + RD_Limit.x), (t.x + LU_Limit.x));
        float widthLimit = Random.Range((t.z + RD_Limit.z), (t.z + RU_Limit.z));
        float heightLimit = Random.Range((t.y + RD_Limit.y), (t.y + RU_Limit.y));

        if (type == "Small")
            heightLimit -= 1.2f;

        result = new Vector3(lengthLimit,heightLimit,widthLimit);
        return result;
    }


    Quaternion GenerateRotation(string type)
    {
        Quaternion result = new Quaternion(0,0,0,0);
        int rand = Random.Range(0, 3);
        if (rand == 0)
        {
            result = new Quaternion(0, 0, 0, 0);
        }
        else if ( rand == 1)
        {
            result = new Quaternion(0, 1, 0, 1);
        }
        else if (rand == 2)
        {
            result = new Quaternion(0, 1, 0, 0);
        }

        if (type == "Small")
        {
            result = new Quaternion(0, 2f, 0, 1);
        }

        return result;
    }

    bool IsAtTheSameSpot(Vector3 childLocation, int previousChild)
    {
        bool isColliding = false;

        Vector3 otherChildLocation = transform.GetChild(previousChild).transform.position;

        if (childLocation.x < otherChildLocation.x + 10 && childLocation.x > otherChildLocation.z - 10 &&
            childLocation.z < otherChildLocation.z + 10 && childLocation.z > otherChildLocation.z - 10)
        {
            isColliding = true;
        }
        return isColliding; 
    }
}
