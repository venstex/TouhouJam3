using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject PlayerPrefab = null;

    private Vector3 PlayerSpawnLocation;

    bool PlayerSpawned;

    // Start is called before the first frame update
    void Start()
    {
        PlayerSpawnLocation = new Vector3(0, 2, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameController.GameStarted && PlayerSpawned == false)
        {
            Instantiate(PlayerPrefab, PlayerSpawnLocation , Quaternion.identity);
            PlayerSpawned = true;
        }
    }
}
