using UnityEngine;

public class GameControler : MonoBehaviour
{
    public int points;
    [SerializeField]
    public float timeGame = 500;
    float _timeGame;

    bool gameEnd;

    PlayerBehavior player;
    HUBControler controlerHUB;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        _timeGame = timeGame;
        player = FindAnyObjectByType<PlayerBehavior>();
        controlerHUB = FindAnyObjectByType<HUBControler>();

        for (int i = 0; i < player.lifes; i++)
        {
            controlerHUB.CreateLife();
        }
    }


    // Update is called once per frame
    void Update()
    {
        _timeGame -= Time.deltaTime;

        controlerHUB.UpdateLifeText(player.lifes);
        controlerHUB.UpdatePointsText(points);
        controlerHUB.UpdateTimeText(_timeGame);


        gameEnd = _timeGame < 0;

        if (gameEnd)
        {
            player.EndGame();
        }
    }



}
