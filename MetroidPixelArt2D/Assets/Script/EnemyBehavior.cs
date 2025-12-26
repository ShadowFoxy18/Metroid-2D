using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    [SerializeField]
    int speed = 2;

    public Vector3 startPosition, endPosition;
    bool moveToEnd;

    private void Start()
    {
        startPosition = transform.position;
        moveToEnd = true;
    }

    private void Update()
    {
        if (moveToEnd)
        {
            transform.position = Vector3.MoveTowards(transform.position, endPosition, speed * Time.deltaTime);

            // Arrive to end position
            if (transform.position == endPosition) 
                moveToEnd = false;
        } else
        {
            transform.position = Vector3.MoveTowards(transform.position, startPosition, speed * Time.deltaTime);

            // Arrive to start position
            if (transform.position == startPosition)
                moveToEnd = true;
        }
    }
}
