using UnityEngine;

public class GameControler : MonoBehaviour
{
    public int points;
    [SerializeField]
    public float timeGame = 500;
    float _timeGame;

    bool gameEnd;

    PlayerBehavior player;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        _timeGame = timeGame;
        player = FindAnyObjectByType<PlayerBehavior>();
    }

    // Update is called once per frame
    void Update()
    {
        _timeGame -= Time.deltaTime;

        gameEnd = _timeGame < 0;

        if (gameEnd)
        {
            player.EndGame();
        }
    }
}
