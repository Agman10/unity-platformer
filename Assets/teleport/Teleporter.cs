using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private BoxCollider2D bc2d;
    //var player = GameObject.Find("player");
    //public Transform trnsfrm;
    void Start() {
        rb2d = GetComponent<Rigidbody2D>();
        bc2d = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        /*PlayerController player = collision.collider.GetComponent<PlayerController>();
        Debug.Log(player);*/
        //PlayerController player = GetComponent<PlayerController>();
        if (collision.tag == "Player" || collision.tag == "enemy") {
            Teleport(collision.transform);
            //Debug.Log();
            //Debug.Log("test");
        }
    }

    protected virtual void Teleport(Transform objectTransform) {

    }

}
