using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testes : MonoBehaviour {

    public Sprite mySprite;

    public Vector3 touchPosWorld;

    public float duration;

    public float speedX, speedY;

    public ParticleSystem particleSystem;

	// Use this for initialization
	void Start () {
        mySprite = GetComponent<SpriteRenderer>().sprite;
        particleSystem = GetComponent<ParticleSystem>();

    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            touchPosWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Vector2 touchPosWorld2D = new Vector2(touchPosWorld.x, touchPosWorld.y);
            ButtonCommand(touchPosWorld2D);
        }
    }

    public void ButtonCommand(Vector2 PosWorld2D)
    {
        RaycastHit2D hitInformation = Physics2D.Raycast(PosWorld2D, Camera.main.transform.forward);
        if (hitInformation.collider != null)
        {
            //VerifyTriangle(hitInformation);   
            Particle(mySprite.uv);
        }
    }

    public void Particle(Vector2[] renderer)
    {
        if (particleSystem == null) return;

        foreach(Vector2 v in renderer)
        {
            print(v);
        }

    }



}
