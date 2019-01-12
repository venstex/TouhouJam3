using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{

    [SerializeField]
    private GameObject PlayerPrefab;

    bool PlayerSpawned;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameController.GameStarted && PlayerSpawned == false)
        {
            Instantiate(PlayerPrefab);
        }
    }
}
