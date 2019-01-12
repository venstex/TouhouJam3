using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorBasedBounds : MonoBehaviour
{
    float horizontalBounds;
    float verticalBounds;

    // Start is called before the first frame update
    void Start()
    {
        GameController.HorizontalFloor = this.transform.localScale.x / 2;
        GameController.VerticalFloor = this.transform.localScale.z / 2;
    }

    private void Update()
    {

    }






}
