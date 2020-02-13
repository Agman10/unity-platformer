using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : EnemyLogic{
    public float speed;
    public bool ledgeWalkoff = false;
    public bool right = true;
    

    private void Update() {
        if (alive) Movement();


        Vector2 lineCastPosRight = trnsfrm.position + trnsfrm.right * width;
        Vector2 lineCastPosLeft = trnsfrm.position - trnsfrm.right * width;
        Debug.DrawLine(lineCastPosRight, lineCastPosRight + Vector2.down, Color.red);
        Debug.DrawLine(lineCastPosLeft, lineCastPosLeft + Vector2.down, Color.blue);

        //Debug.Log(lineCastPosRight);

        bool isGroundedRight = Physics2D.Linecast(lineCastPosRight, lineCastPosRight + Vector2.down, ObjectCollision);
        bool isGroundedLeft = Physics2D.Linecast(lineCastPosLeft, lineCastPosLeft + Vector2.down, ObjectCollision);
        if (!isGroundedRight && !ledgeWalkoff) {
            right = false;
        }
        if (!isGroundedLeft && !ledgeWalkoff) {
            right = true;
        }
        //Debug.Log(isGrounded);
    }

    public void OnCollisionEnter2D(Collision2D collision) {

    }

    private void Movement() {
        if (right) {
            speed = 1f;
        }
        else if (!right) { 
            speed = -1f;
        }
        rb2d.velocity = new Vector2(+speed, rb2d.velocity.y);
        //Debug.Log("moving");
    }

    public override void Kill() {
        alive = false;
        //animator.SetBool("dead", true);
        animator.SetTrigger("death");
        speed = 0f;
        
        Destroy(gameObject, 0.48f);
        //Destroy(gameObject, 4f);
    }
    protected override void OnHit() {

    }
}
