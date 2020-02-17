using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    [SerializeField] private LayerMask platformsLayerMask;
    [SerializeField] private LayerMask enemyCollision;
    public Animator animator;
    //public float animator = 1f;
    public float moveSpeed = 7f;
    public float jumpVelocity = 15f;
    public double knockbackCount = 0f;
    public float maxVelocity = 15f;
    public float health = 2f;

    float horizontalMove = 0f;
    private Rigidbody2D rb2d;
    private BoxCollider2D bc2d;
    //public Transform trnsfrm;

    public float knockbackSide = 4f;
    public float knockbackUp = 7f;
    // Start is called before the first frame update
    void Start() {
        rb2d = GetComponent<Rigidbody2D>();
        bc2d = GetComponent<BoxCollider2D>();
        //trnsfrm = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update() {
        
        if (rb2d.velocity.y == 0 && Input.GetKeyDown(KeyCode.Space)) {
            rb2d.velocity = Vector2.up * jumpVelocity;
        }

        //Vector2.ClampMagnitude(rb2d.velocity, maxVelocity);
        //CapVelocity();

        Vector3 characterScale = transform.localScale;
        if(Input.GetAxis("Horizontal") < 0 && knockbackCount <= 0) {
            characterScale.x = -1;
            //knockbackSide = 4f;
            
        }
        if (Input.GetAxis("Horizontal") > 0 && knockbackCount <= 0) {
            characterScale.x = 1;
            //knockbackSide = -4f;
        }
        transform.localScale = characterScale;

        if (knockbackCount <= 0) {
            CapVelocity();
            Movement();
        }
        if (knockbackCount >= 0.2) {
            rb2d.velocity = new Vector2(+knockbackSide, +knockbackUp);
            knockbackCount -= Time.deltaTime;
        }
        if(knockbackCount < 0.2 && knockbackCount > 0) {
            knockbackCount -= Time.deltaTime;
        }

        horizontalMove = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("speed", Mathf.Abs(horizontalMove));
        //Debug.Log(horizontalMove);
        animator.SetFloat("jumping", Mathf.Abs(rb2d.velocity.y));
        //IsGrounded();

        
    }


    private void OnCollisionEnter2D(Collision2D collision) {
        
        EnemyLogic enemy = collision.collider.GetComponent<EnemyLogic>();
        if(enemy != null) {
            RaycastHit2D enemyTop = Physics2D.BoxCast(bc2d.bounds.center, bc2d.bounds.size, 0f, Vector2.down, .1f, enemyCollision);

            foreach (ContactPoint2D point in collision.contacts) {
                Debug.DrawLine(point.point, point.point + point.normal, Color.red, 10);
            }
            //Debug.Log(enemyTop.collider);


            if (enemyTop.collider != null) {
                //Destroy(enemy.gameObject);
                enemy.Kill();
                if (Input.GetKey(KeyCode.Space)) {
                    rb2d.velocity = new Vector2(0, +15);
                }
                else {
                    rb2d.velocity = new Vector2(0, +7);
                }
                
            } else {
                Debug.Log("ouch");
                health--;
                knockbackCount = 0.3;
                if(enemy.transform.position.x < transform.position.x) {
                    knockbackSide = 4f;
                }
                else if (enemy.transform.position.x > transform.position.x) {
                    knockbackSide = -4f;
                }
                //transform.position = new Vector2(rb2d.position.x, 8);
            }

        }
    }



    private bool IsGrounded() {
        
            RaycastHit2D rh2d = Physics2D.BoxCast(bc2d.bounds.center, bc2d.bounds.size, 0f, Vector2.down, .1f, platformsLayerMask);
            Debug.Log(rh2d.collider);
            //Debug.Log("test");
            //return rb2d.velocity.y == 0;

            return rh2d.collider != null;

        
    }

    private void Movement() {
        
        if (Input.GetKey(KeyCode.LeftArrow) && Input.GetAxis("Horizontal") < 0) {
            rb2d.velocity = new Vector2(-moveSpeed, rb2d.velocity.y);
        }
        else {
            if (Input.GetKey(KeyCode.RightArrow) && Input.GetAxis("Horizontal") > 0) {
                rb2d.velocity = new Vector2(+moveSpeed, rb2d.velocity.y);
            }
            else {
                rb2d.velocity = new Vector2(0, rb2d.velocity.y);
            }
            /*if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.RightArrow)) {
                rb2d.velocity = new Vector2(0, rb2d.velocity.y);
            }*/
        }
        
    }

    public void CapVelocity() {
        float cappedYVelocity = Mathf.Min(Mathf.Abs(rb2d.velocity.y), maxVelocity) * Mathf.Sign(rb2d.velocity.y);
        rb2d.velocity = new Vector2(moveSpeed, cappedYVelocity);
    }
}
