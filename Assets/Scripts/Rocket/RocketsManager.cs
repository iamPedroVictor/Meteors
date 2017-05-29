using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketsManager : MonoBehaviour {

    public Vector3[] rocketsOrbitPosition;
    public GameObject rocketsBase;
    public GameObject[] rockts;


    private static RocketsManager _instance;

    private static int count;

    public static RocketsManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<RocketsManager>();
            }
            return _instance;
        }
    }


    public void Build()
    {
        count++;

        if (count > 1)
        {
            count = 0;
            BuildRockets();
        }
    }


    private void BuildRockets()
    {
        print("Construi Rockets");
        for(int i = 0; i < rockts.Length; i++)
        {
            if (!rockts[i].activeInHierarchy){
                rockts[i] = Instantiate(rocketsBase, rocketsOrbitPosition[i], Quaternion.Euler(0,180 * i,-90)) as GameObject;
            }
        }
    }

}
