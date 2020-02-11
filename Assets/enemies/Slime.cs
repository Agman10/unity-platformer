using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : EnemyLogic{
    public float speed = 1f;
    public bool ledgeWalkoff = false;

    private void Update() {
        Movement();
    }

    private void Movement() {
        rb2d.velocity = new Vector2(+speed, rb2d.velocity.y);
        Debug.Log("moving");
    }
    protected override void OnHit() {

    }
}
