using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    [SerializeField] private GameObject blockParent;
    [SerializeField] private GameObject blockPrefab;
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private GameObject basket;

    private int numberOfBlock;
    private static bool ballDestroyed = false;

    public static int score = 0;
    public static int turn = 1;
    public static int live = 3;

    void Start()
    {
        SpawnBlock();
    }

    void Update()
    {
        if(blockParent.transform.childCount == 0)
        {
            NextTurn();
        }

        if(ballDestroyed)
        {
            basket.transform.position = new Vector3(0f, -9f, 10f);
            ballDestroyed = false;
        }

        if(live == -1)
        {
            GameOver.score = score.ToString("00");
            GameOver.turn = turn.ToString("00");
            GameOver.time = Auxiliary.GetTimeString(Time.timeSinceLevelLoad);
            SceneManager.LoadScene(2);
        }
    }

    private void SpawnRandom()
    {
        float blockRadius = 0.49f;
        int x;
        int y;
        Vector2 position;
        int count = 0;

        while(true)
        {
            x = UnityEngine.Random.Range(-4, 5);
            y = UnityEngine.Random.Range(-2, 9);
            position = new Vector2(x, y);

            if(!Auxiliary.IsEmptyPosition(blockRadius, "Block", position))
            {
                Instantiate(blockPrefab, new Vector3(x, y, 10), Quaternion.identity, blockParent.transform);
                break;
            }

            if(count++ >= 5000)
            {
                break;
            }
        }
    }

    private void SpawnBlock()
    {
        numberOfBlock = UnityEngine.Random.Range(30, 99);
        for(int i = 0; i < numberOfBlock; i++)
        {
            SpawnRandom();
        }
    }

    public static void AddScore()
    {
        score++;
    }

    public static void SubLive()
    {
        ballDestroyed = true;
        live--;
    }

    private void NextTurn()
    {
        SpawnBlock();
        turn++;
        live++;
        Ball.speed = Ball.speed + 0.3f;
    }
}
