using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLogic : MonoBehaviour{
    [SerializeField] public LayerMask ObjectCollision;
    public Rigidbody2D rb2d;
    public BoxCollider2D bc2d;
    public Transform trnsfrm;
    public Animator animator;
    public float width;
    public void Start() {
        trnsfrm = GetComponent<Transform>();
        width = GetComponent<SpriteRenderer>().bounds.extents.x;
        rb2d = GetComponent<Rigidbody2D>();
        bc2d = GetComponent<BoxCollider2D>();
    }
    /*public void OnCollisionEnter2D(Collision2D collision) {
        RaycastHit2D enemycollision = Physics2D.BoxCast(bc2d.bounds.center, bc2d.bounds.size, 0f, Vector2.zero, .1f, ObjectCollision);
        Debug.Log(enemycollision.collider + "test");
        foreach (ContactPoint2D point in collision.contacts) {
            Debug.DrawLine(point.point, point.point + point.normal, Color.red, 10);
        }

    }*/

    public virtual void Kill() {
        
    }
    protected virtual void OnHit() {

    }
}
