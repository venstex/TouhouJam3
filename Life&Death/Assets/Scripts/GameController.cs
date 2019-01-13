using System.Collections;
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
    public static int GenkiCharge;

    float ElapsedTime;

    GameObject ActiveSpawner;

    [SerializeField]
    private GameObject GenkiObject1;
    [SerializeField]
    private GameObject GenkiObject2;
    [SerializeField]
    private GameObject GenkiObject3;
    [SerializeField]
    private GameObject GenkiObject4;
    [SerializeField]
    private GameObject GenkiObject5;


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

        Debug.Log(GenkiCharge);

        if (GenkiCharge > 0)
        {
            GenkiObject1.SetActive(true);
            if (GenkiCharge > 1)
            {
                GenkiObject2.SetActive(true);
                if (GenkiCharge > 2)
                {
                    GenkiObject3.SetActive(true);
                    if (GenkiCharge > 3)
                    {
                        GenkiObject4.SetActive(true);
                        if (GenkiCharge > 4)
                        {
                            GenkiObject5.SetActive(true);
                        }
                        else
                        {
                            GenkiObject5.SetActive(false);
                        }
                    }
                    else
                    {
                        GenkiObject4.SetActive(false);
                    }
                }
                else
                {
                    GenkiObject3.SetActive(false);
                }
            }
            else
            {
                GenkiObject2.SetActive(false);
            }
        }
        else
        {
            GenkiObject1.SetActive(false);
            GenkiObject2.SetActive(false);
            GenkiObject3.SetActive(false);
            GenkiObject4.SetActive(false);
            GenkiObject5.SetActive(false);
        }

        //Transform[] GenkiArray = GenkiObject.GetComponentsInChildren<Transform>();

        //for (int i = 0; i < GenkiCharge; i++)
        //{
        //    GenkiArray[i].gameObject.SetActive(true);
        //}

        //if (GenkiCharge == 0)
        //{
        //    foreach (Transform GenkiObject in GenkiArray)
        //    {
        //        GenkiObject.gameObject.SetActive(false);
        //    }
        //}

    }

    public void StartGame()
    {
        if (!GameStarted)
        {
            GameStarted = true;
            ActiveSpawner = Instantiate(Spawner);
        }        
    }

    public void QuitGame()
    {
        Application.Quit();
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

        GenkiCharge = 0;
    }
}
