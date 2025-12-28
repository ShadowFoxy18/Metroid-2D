using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBehavior : MonoBehaviour
{
    [SerializeField]
    int speed = 2;

    [SerializeField]
    int JumpCapacity = 5;

    [SerializeField]
    int lifes = 5;

    [SerializeField]
    float invulnerableTime = 3f;
    float _invulnerableTime;
    [SerializeField]
    Color invulnerableColor = Color.yellow;
    bool vulnerable = true;

    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator ani;

    

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        ani = GetComponent<Animator>();
    }

    private void FixedUpdate() {
        float movePlayer = Input.GetAxis("Horizontal");

        rb.linearVelocity = new Vector2(movePlayer * speed, rb.linearVelocity.y);

        // Read if the player turn left or right, if tourn left (linearvelocity < 0), the sprite flip in x
        sr.flipX = rb.linearVelocityX < 0;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && ColissionFloor())
        {
            rb.AddForce(JumpCapacity * Vector2.up, ForceMode2D.Impulse);
        }

        InvulnerableMethod();

        AnimatePlayer();
    }


    // --------------------------------------------------- Collisions ------------------------------------------------------- //
    bool ColissionFloor()
    {
        RaycastHit2D hit;

        hit = Physics2D.Raycast(transform.position + new Vector3(0, -2f, 0), Vector2.down, 0);

        return hit.collider != null;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && vulnerable)
        {
            LostLife(collision.GetComponent<EnemyBehavior>().enemyDamege);
            vulnerable = false;
            rb.AddForce(new Vector3(rb.linearVelocityX * -1, 0 ,0), ForceMode2D.Impulse);
        }
    }


    // ---------------------------------------------------- Player Behavior ------------------------------------------------- //
    void LostLife(int damage)
    {
        lifes -= damage;
        if (lifes < 0)
        {
            EndGame();
        }
    }

    public void EndGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    void InvulnerableMethod()
    {
        if (!vulnerable)
        {

            _invulnerableTime -= Time.deltaTime;
            vulnerable = _invulnerableTime < 0;

            sr.color = invulnerableColor;

        }
        else if (vulnerable)
        {
            _invulnerableTime = invulnerableTime;
            sr.color = Color.white;
        }
    }

    void AnimatePlayer()
    {
        // Jump Action
        if (!ColissionFloor()) ani.Play("playerJump");

        // Run Action
        else if (rb.linearVelocityX > 1 || rb.linearVelocityX < -1) ani.Play("playerRun");

        // Iddle Action
        else ani.Play("playerIddle");
        // if ((rb.linearVelocityX > 1 || rb.linearVelocityX < -1) && rb.linearVelocityY == 0) 
    }
}
