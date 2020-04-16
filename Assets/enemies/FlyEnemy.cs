using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyEnemy : EnemyLogic {
    public float speed;
    public bool up = true;
    public float maxY;
    public float minY;

    void Update() {
        if (alive)
        {
            Movement();
            ChangeDir();
        }
    }
    private void Movement()
    {
        if (up)
        {
            speed = 1f;
        }
        else if (!up)
        {
            speed = -1f;
        }
        rb2d.velocity = new Vector2(rb2d.velocity.x, +speed);
        Debug.Log("moving");
    }

    private void ChangeDir()
    {
        if(trnsfrm.position.y >= maxY)
        {
            up = false;
        }
        if(trnsfrm.position.y <= minY)
        {
            up = true;
        }
    }
}
