using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SpaceShipMode
{
    Orbit,
    Launch
}

public class Orbit : MonoBehaviour {

    public Transform centerOrbit;
    [Range(20,100)]
    public float speedRotateAround;
    [Range(0, 20)]
    public float speedLaunch;

    public SpaceShipMode spaceShip;

	private const string meteorTag = "Meteor";

	private void Awake(){
		spaceShip = SpaceShipMode.Orbit;
		centerOrbit = GameObject.FindGameObjectWithTag ("World").transform;
	}
		

    private void Update()
    {
		if (GameManager.Instance.state != GameState.GamePlay)
			return;
        if (Input.GetMouseButtonDown(0))
        {
            if (spaceShip == SpaceShipMode.Orbit)
            {
                spaceShip = SpaceShipMode.Launch;
                CallDestroy();
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate () {
		if (GameManager.Instance.state != GameState.GamePlay)
			return;
        if(SpaceShipMode.Orbit == spaceShip)
        {
            OrbitAround();
        }else
        {
            Launch();
        }
	}

    private void OrbitAround()
    {
        transform.RotateAround(centerOrbit.position, Vector3.forward, speedRotateAround * Time.fixedDeltaTime);
    }

    private void Launch(){
        transform.Translate(Vector3.up * (speedLaunch * Time.fixedDeltaTime));
    }

    private void CallDestroy()
    {
        Invoke("DestroyMe", 1f);
    }

    void DestroyMe()
    {
        Destroy(this.gameObject);
        RocketsManager.Instance.Build();
    }

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.transform.CompareTag(meteorTag)){
			Destroy (collision.gameObject);
			DestroyMe ();

		}
	}

}
