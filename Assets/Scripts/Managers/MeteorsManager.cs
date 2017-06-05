using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorsManager : MonoBehaviour , IReadyStart {

    public Transform meteorRef;
    public float radiusSpawn;
    public Vector3 center = Vector3.zero;
	private static MeteorsManager _instance;
	public static MeteorsManager Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = FindObjectOfType<MeteorsManager>();
			}
			return _instance;
		}
	}

    public float timeRepeating = 3f;

    private void Start()
    {
        InvokeRepeating("InstantiateMeteor", 0, timeRepeating);
    }


    private void InstantiateMeteor(){

        Vector3 pos = RandomCircle(center, radiusSpawn);
        Instantiate(meteorRef, pos, Quaternion.identity);

    }

    Vector3 RandomCircle(Vector3 center, float radius)
    {
        float ang = UnityEngine.Random.value * 360;
        Vector3 pos;
        pos.x = center.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
        pos.y = center.y + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
        pos.z = center.z;
        return pos;
    }

    public void StartGame()
    {
        InvokeRepeating("InstantiateMeteor", timeRepeating, timeRepeating);
    }
}
