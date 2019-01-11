using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiritSpawner : MonoBehaviour
{

    public GameObject LevelFloorForBounds;
    private float LimitZ;
    private float LimitX;

    [SerializeField]
    private float SpawnRateGenki;
    public Transform Genki;


    [SerializeField]
    private float SpawnRateOnryou;
    public Transform Onryou;

    // Start is called before the first frame update
    void Start()
    {
        Vector2 FloorBounds = LevelFloorForBounds.GetComponent<FloorBasedBounds>().GetBounds();
        Debug.Log(FloorBounds);
        LimitX = FloorBounds.x;
        LimitZ = FloorBounds.y;

        InvokeRepeating("SpawnGenkiSpirit", 2f ,SpawnRateGenki);
        InvokeRepeating("SpawnOnryouSpirit", 2f ,SpawnRateOnryou);

    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnGenkiSpirit()
    {
        Vector3 position = new Vector3(Random.Range(-LimitX, LimitX), 2, Random.Range(-LimitZ, LimitZ));

        Instantiate(Genki, position, Quaternion.identity);
    }

    void SpawnOnryouSpirit()
    {
        Vector3 position = new Vector3(Random.Range(-LimitX, LimitX), 3, Random.Range(-LimitZ, LimitZ));

        Instantiate(Onryou, position, Quaternion.identity);
    }

}
