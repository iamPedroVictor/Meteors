using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour {

	const string worldTag = "World";

	void Update(){
		if (GameManager.Instance.state == GameState.GameOver) {
			Destroy (this.gameObject);
		}
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
		if (collision.transform.CompareTag(worldTag)){
			RocketsManager.Instance.CancelInvoke ("InstantiateMeteor");
			GameManager.Instance.GameOver ();

        }
    }

    public void DestroyMeteor(){
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        GetComponent<Animator>().SetTrigger("Destroy");
    }

    private void Destroy()
    {
        Destroy(this.gameObject);
    }

}
