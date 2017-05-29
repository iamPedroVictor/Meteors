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


    public void Start()
    {
        spaceShip = SpaceShipMode.Orbit;
    }

    private void Update()
    {
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
        Invoke("DestroyMe", 2f);
    }

    void DestroyMe()
    {
        Destroy(this.gameObject);
        RocketsManager.Instance.Build();
    }

}
