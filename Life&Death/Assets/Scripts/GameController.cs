using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public static int Score;
    public static bool GameStarted;

    public Text ScoreField;
    public Text TimeField;

    int PlayTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayTime = Mathf.RoundToInt(Time.time);

        ScoreField.text = Score.ToString();
        TimeField.text = PlayTime.ToString();

    }

    public void StartGame()
    {
        GameStarted = true;
    }

}
