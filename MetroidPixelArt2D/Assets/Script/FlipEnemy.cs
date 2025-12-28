using UnityEngine;

public class FlipEnemy : MonoBehaviour
{
    SpriteRenderer sr;

    float lastXPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        lastXPosition = transform.position.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        sr.flipX = lastXPosition < transform.parent.position.x;
        lastXPosition = transform.position.x;
    }
}
