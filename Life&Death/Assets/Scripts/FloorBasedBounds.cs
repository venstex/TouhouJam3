﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorBasedBounds : MonoBehaviour
{
    float horizontalBounds;
    float verticalBounds;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public Vector2 GetBounds()
    {
        horizontalBounds = this.transform.localScale.x / 2;
        verticalBounds = this.transform.localScale.z / 2;

        Vector2 levelBounds = new Vector2(horizontalBounds,verticalBounds);

        return levelBounds;
    }



}