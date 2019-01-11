using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenkiBehaviour : MonoBehaviour
{

    [Header("Starting velocity")]
    [SerializeField]
    private float startVelocity;

    [Header("Modifiers")]
    [SerializeField]
    private float modVelocity;
    [SerializeField]
    private float modDirection;

    [Header("Field limits")]
    [SerializeField]
    private float LimitZ = 5f;

    [SerializeField]
    private float LimitX = 5f;

    private float currentVelocity;
    private float currentDirection;
    
    // Start is called before the first frame update
    void Start()
    {
        this.currentVelocity = startVelocity;
        this.currentDirection = getStartDirection();
    }

    // Update is called once per frame
    void Update()
    {  

        float newVelocity = getRandomVelocity();
        float newDirection = getRandomDirection();

        this.transform.Translate(0, 0, newVelocity * Time.deltaTime);
        this.transform.Rotate(0, newDirection, 0);

        this.currentVelocity = newVelocity;
        this.currentDirection = newDirection;

        HandleBounds();
    }

    private float getRandomVelocity()
    {
        float randomRangeBottom = this.currentVelocity - this.modVelocity;
        float randomRangeTop = this.currentVelocity + this.modVelocity;
        float randomVelocityMod = Random.Range(randomRangeBottom, randomRangeTop);

        if (randomVelocityMod<this.currentVelocity)
        {
            return this.currentVelocity - randomVelocityMod;
        } else
        {
            return this.currentVelocity + randomVelocityMod;
        }
    }

    private float getRandomDirection()
    {
        float randomRangeBottom = this.currentDirection - this.modDirection;
        float randomRangeTop = this.currentDirection + this.modDirection;
        float randomDirectionMod = Random.Range(randomRangeBottom, randomRangeTop);

        if (randomDirectionMod < this.currentDirection)
        {
            return this.currentDirection - randomDirectionMod;
        }
        else
        {
            return this.currentDirection + randomDirectionMod;
        }
        return 0;
    }

    private float getStartDirection()
    {

        float randomDirection = Random.Range(1, 360);
        return randomDirection;
    }

    private void HandleBounds()
    {
        if (this.transform.position.z > LimitZ)
        {
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, LimitZ);
        }

        if (this.transform.position.z < -LimitZ)
        {
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, -LimitZ);
        }

        if (this.transform.position.x > LimitX)
        {
            this.transform.position = new Vector3(LimitX, this.transform.position.y, this.transform.position.z);
        }

        if (this.transform.position.x < -LimitX)
        {
            this.transform.position = new Vector3(-LimitX, this.transform.position.y, this.transform.position.z);
        }
    }
}
