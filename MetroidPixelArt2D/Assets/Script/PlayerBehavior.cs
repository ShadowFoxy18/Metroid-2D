using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    [SerializeField]
    int speed = 2;

    [SerializeField]
    int JumpCapacity = 5;

    Rigidbody2D rb;


    private void Start() {
        rb = GetComponent<Rigidbody2D>();
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
    }


    bool ColissionFloor()
    {
        RaycastHit2D hit;

        hit = Physics2D.Raycast(transform.position + new Vector3(0, -2f, 0), Vector2.down, 0);

        return hit.collider != null;
    }
}
