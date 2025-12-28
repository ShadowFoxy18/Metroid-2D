using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    [SerializeField]
    int speed = 2;
    public int enemyDamege = 1;

    [SerializeField]
    Transform spriteStart, spriteEnd;
    Vector3 startPosition, endPosition;
    bool moveToEnd;

    private void Awake()
    {
        startPosition = spriteStart.position;
        endPosition = spriteEnd.position;

        moveToEnd = true;
    }

    private void Start()
    {
        transform.position = startPosition;
    }

    private void Update()
    {
        Vector3 DestinationPosition = !moveToEnd ? startPosition : endPosition;
        MoveEnemy(DestinationPosition);
    }

    void MoveEnemy(Vector3 positonToMove)
    {
        transform.position = Vector3.MoveTowards(transform.position, positonToMove, speed * Time.deltaTime);

        if (transform.position == positonToMove)
        {
            moveToEnd = !moveToEnd;
        }
    }
}
