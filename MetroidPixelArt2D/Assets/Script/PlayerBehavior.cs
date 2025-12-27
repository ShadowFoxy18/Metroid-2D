using UnityEditor.Tilemaps;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    [SerializeField]
    int speed = 2;

    [SerializeField]
    int JumpCapacity = 5;

    [SerializeField]
    int lifes = 5;

    Rigidbody2D rb;
    SpriteRenderer sr;


    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate() {
        float movePlayer = Input.GetAxis("Horizontal");

        rb.linearVelocity = new Vector2(movePlayer * speed, rb.linearVelocity.y);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && ColissionFloor())
        {
            rb.AddForce(JumpCapacity * Vector2.up, ForceMode2D.Impulse);
        }

        // Read if the player turn left or right, if tourn left (linearvelocity < 0), the sprite flip in x
        sr.flipX = rb.linearVelocityX < 0;
    }


    // ---------------------------------------------------------------- Collisions ----------------------------------------------------------- //
    bool ColissionFloor()
    {
        RaycastHit2D hit;

        hit = Physics2D.Raycast(transform.position + new Vector3(0, -2f, 0), Vector2.down, 0);

        return hit.collider != null;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            LostLife(collision.GetComponent<EnemyBehavior>().enemyDamege);
        }
    }


    // ---------------------------------------------------- Player Behavior ---------------------------------- //
    void LostLife(int damage)
    {
        lifes -= damage;
        if (lifes < 0)
        {
            EndGame();
        }
    }




    void EndGame()
    {
        Debug.Log("EndGame");
    }

}
