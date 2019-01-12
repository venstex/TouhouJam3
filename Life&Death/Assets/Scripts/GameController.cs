﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject Spawner;

    public static int Score;
    public static bool GameStarted;

    public static float HorizontalFloor = 1;
    public static float VerticalFloor = 1;

    public Text ScoreField;
    public Text TimeField;

    public static int PlayTime;
    float ElapsedTime;

    GameObject ActiveSpawner;

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

        }
        else
        {
            ElapsedTime = 0;
            Score = 0;
            Destroy(ActiveSpawner);
        }

    }

    public void StartGame()
    {
        GameStarted = true;
        ActiveSpawner = Instantiate(Spawner);
    }

    public static void StopGame()
    {
        GameStarted = false;

        GameObject[] CleanEnemies = GameObject.FindGameObjectsWithTag("Enemy");

        GameObject[] CleanCollects = GameObject.FindGameObjectsWithTag("Collect");

        GameObject CleanPlayer = GameObject.FindGameObjectWithTag("Player");

        foreach (GameObject Enemy in CleanEnemies)
        {
            Destroy(Enemy);
        }

        foreach (GameObject Collect in CleanCollects)
        {
            Destroy(Collect);
        }

        Destroy(CleanPlayer);
    }
}
