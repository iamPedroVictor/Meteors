using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour {

    public string tag;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag(tag)){
            print("Colidiu com o mundo");
        }
    }


}
