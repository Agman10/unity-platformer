using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLogic : MonoBehaviour{
    public Rigidbody2D rb2d;
    public BoxCollider2D bc2d;
    public void Start() {

        rb2d = GetComponent<Rigidbody2D>();
        bc2d = GetComponent<BoxCollider2D>();
    }
    protected virtual private void OnTriggerEnter2D(Collider2D collision) {
        
    }
    protected virtual void OnHit() {

    }
}
