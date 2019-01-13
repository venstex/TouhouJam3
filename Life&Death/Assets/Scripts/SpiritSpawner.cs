using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiritSpawner : MonoBehaviour
{

    public GameObject LevelFloorForBounds;
    private float LimitZ;
    private float LimitX;

    [SerializeField]
    private float SpawnRateGenki = 1;
    public Transform Genki;

    [SerializeField]
    private float SpawnRateOnryou = 1;
    public Transform Onryou;

    [SerializeField]
    private float minSpawnRadius = 3;

    [SerializeField]
    private float maxEnemies = 50;

    private bool stopSpawningEnemies = false;

    private GameObject[] players;
    private Vector3 playerLocation;

    private GameObject[] enemies;

    private int spawnCounter = 0;
    private int maxSpawnCounter = 10;

    // Start is called before the first frame update
    void Start()
    {
        //Vector2 FloorBounds = LevelFloorForBounds.GetComponent<FloorBasedBounds>().GetBounds();
        LimitX = GameController.HorizontalFloor;
        LimitZ = GameController.VerticalFloor;

        InvokeRepeating("SpawnGenkiSpirit", 2f ,SpawnRateGenki);
        InvokeRepeating("SpawnOnryouSpirit", 2f ,SpawnRateOnryou);

    }

    // Update is called once per frame
    void Update()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject player in players)
        {
            playerLocation = player.transform.position;
        }

        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        print(enemies.Length);
        if (enemies.Length >= maxEnemies)
        {
            stopSpawningEnemies = true;
        }
        else
        {
            stopSpawningEnemies = false;
        }
    }

    void SpawnGenkiSpirit()
    {
        Vector3 position = new Vector3(Random.Range(-LimitX, LimitX), 2, Random.Range(-LimitZ, LimitZ));

        Instantiate(Genki, position, Quaternion.identity);
    }

    void SpawnOnryouSpirit()
    {
        //Vector3 position = new Vector3(Random.Range(-LimitX, LimitX), 3, Random.Range(-LimitZ, LimitZ));        
        if (!stopSpawningEnemies)
        {
            Vector3 position = spawnNotTooCloseTooPlayer(playerLocation);
            Instantiate(Onryou, position, Quaternion.identity);
        }
        
    }

    Vector3 spawnNotTooCloseTooPlayer(Vector3 playerLocation)
    {

        Vector3 spawnLocation = new Vector3(Random.Range(-LimitX, LimitX), 3, Random.Range(-LimitZ, LimitZ));

        if (spawnCounter>=maxSpawnCounter)
        {
            spawnCounter = 0;
            return spawnLocation;
        } else
        {
            spawnCounter++;
        }

        if (isSpawnTooClose(spawnLocation, playerLocation))
        {
            return spawnNotTooCloseTooPlayer(playerLocation);
        } else
        {
            return spawnLocation;
        }
    }

    bool isSpawnTooClose(Vector3 me, Vector3 other)
    {
        float ghost_x = me.x;
        float ghost_z = me.z;

        float player_x = other.x;
        float player_z = other.z;

        float minX = player_x - this.minSpawnRadius;
        float maxX = player_x + this.minSpawnRadius;

        float minZ = player_z - this.minSpawnRadius;
        float maxZ = player_z + this.minSpawnRadius;
        
        if (ghost_x <= maxX &&
            ghost_x > minX &&
            ghost_z <= maxZ &&
            ghost_z > minZ)
        {
            print("maxX: "+ghost_x + " " + maxX);
            return true;
        }
        return false;       

    }

}
