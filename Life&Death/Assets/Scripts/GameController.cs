using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject Spawner;

    public static int Score;
    public static bool GameStarted;

    public static float HorizontalFloor = 50;
    public static float VerticalFloor = 40;

    public Text ScoreField;
    public Text TimeField;

    int PlayTime;
    float ElapsedTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameStarted)
        {
            PlayTime = Mathf.RoundToInt(ElapsedTime += Time.deltaTime);

            ScoreField.text = Score.ToString();
            TimeField.text = PlayTime.ToString();

            Spawner.SetActive(true);

        }
        else
        {
            ElapsedTime = 0;
            Score = 0;
        }
    }

    public void StartGame()
    {
        GameStarted = true;
    }

}
