using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketsManager : MonoBehaviour {

	public RocketData[] rocketsOrbit;
    public GameObject rocketsBase;
	public GameObject[] rockets;


    private static RocketsManager _instance;

    public int count;

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

    private void Awake()
    {
        rockets = new GameObject[2];
        BuildRockets();
    }

    void Start(){
        
		rockets = GameObject.FindGameObjectsWithTag ("Rocket");
	}


    public void Build()
    {
        count++;
        if (count == 2)
        {
            BuildRockets();
			count = 0;
        }
    }


    private void BuildRockets()
    {
        print("Construi Rockets");
        for(int i = 0; i < rockets.Length; i++)
        {
			GameObject rocket = Instantiate(rocketsBase, rocketsOrbit[i].position, Quaternion.Euler(rocketsOrbit[i].rotation));
			rockets [i] = rocket;
        }
    }
		

}

[System.Serializable]
public struct RocketData{
	public Vector3 position;
	public Vector3 rotation;
}
