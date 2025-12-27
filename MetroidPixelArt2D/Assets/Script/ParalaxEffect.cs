using UnityEngine;

public class ParalaxEffect : MonoBehaviour
{
    [SerializeField]
    float delay = 0.4f;

    Transform cameraFollow;
    Vector3 cameraLastPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cameraFollow = Camera.main.transform;
        cameraLastPosition = cameraFollow.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 movement = cameraFollow.position - cameraLastPosition;
        transform.position += new Vector3(movement.x * delay, movement.y, 0);
        cameraLastPosition = cameraFollow.position;
    }
}
