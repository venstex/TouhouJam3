using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenkiBehaviour : MonoBehaviour
{

    [Header("Velocity")]
    [SerializeField]
    private float startVelocity = 2;

    [SerializeField]
    private float minVelocity = 1;

    [SerializeField]
    private float maxVelocity = 2;

    [Header("Modifiers")]
    [SerializeField]
    private float modVelocity = 1;
    [SerializeField]
    private float modDirection = 1;

    [Header("Field limits")]
    [SerializeField]
    private float LimitZ = 20f;

    [SerializeField]
    private float LimitX = 25f;

    private float currentVelocity;
    private float currentDirection;

    private bool isMovingAwayFromEdge = false;
    private bool isMovingAwayFromEdgeDirectionLeft = true;

    private bool isIgnoringTurningFrames = false;
    private int ignoreTurningFrames = 20;
    private int ignoreTurningFramesCounter = 0;

    // Start is called before the first frame update
    void Start()
    {
        this.currentVelocity = startVelocity;
        this.currentDirection = getStartDirection();
    }

    // Update is called once per frame
    void Update()
    {

        float newVelocity = 0;
        float newDirection = 0;

        if (this.isMovingAwayFromEdge && (ignoreTurningFrames > ignoreTurningFramesCounter))
        {
            newVelocity = this.currentVelocity;
            newDirection = this.currentDirection;
            ignoreTurningFramesCounter++;
        }
        else
        {
            ignoreTurningFramesCounter = 0;
            newVelocity = getRandomVelocity();
            newDirection = getRandomDirection();
        }



        this.transform.Translate(0, 0, newVelocity * Time.deltaTime);
        this.transform.eulerAngles = new Vector3(0, newDirection, 0);

        this.currentVelocity = newVelocity;
        this.currentDirection = newDirection;

        HandleBounds();
        Hover();
    }

    private float getRandomVelocity()
    {
        float randomRangeBottom = this.currentVelocity - this.modVelocity;
        float randomRangeTop = this.currentVelocity + this.modVelocity;
        float randomVelocityMod = Random.Range(randomRangeBottom, randomRangeTop);

        float newVelocity = randomVelocityMod;

        if (newVelocity < minVelocity)
        {
            newVelocity = minVelocity;
        }

        if (newVelocity > maxVelocity)
        {
            newVelocity = maxVelocity;
        }

        return newVelocity;
    }

    private void setMoveAway(bool isMoveAway)
    {
        if (!this.isMovingAwayFromEdge || !isMoveAway)
        {
            if (isMoveAway)
            {
                this.isMovingAwayFromEdge = true;
                if (Random.value < 0.5f)
                {
                    isMovingAwayFromEdgeDirectionLeft = true;
                }
                else
                {
                    isMovingAwayFromEdgeDirectionLeft = false;
                }
            }
            else
            {
                this.isMovingAwayFromEdge = false;
            }
        }
    }

    private float getRandomDirection()
    {
        float modDirectionBias = 0;
        Vector3 position = this.transform.position;

        if (position.x > (LimitX / 1.1) ||
            position.x < -(LimitX / 1.1) ||
            position.z > (LimitZ / 1.1) ||
            position.z < -(LimitZ / 1.1))
        {
            setMoveAway(true);
        }
        else
        {
            setMoveAway(false);
        }

        if (this.isMovingAwayFromEdge)
        {
            if (isMovingAwayFromEdgeDirectionLeft)
            {
                modDirectionBias = -20;
            }
            else
            {
                modDirectionBias = +20;
            }

        }

        //if (position.x == (-LimitX) ||
        //position.x == (LimitX) ||
        //position.z == (-LimitZ) ||
        //position.z == (LimitZ))
        //{
        //    modDirectionBias = 180;
        //}

        float randomRangeBottom = (this.currentDirection - modDirection) - modDirectionBias;
        float randomRangeTop = (this.currentDirection + modDirection) + modDirectionBias;
        float randomDirectionMod = Random.Range(randomRangeBottom, randomRangeTop);

        return randomDirectionMod + modDirectionBias;
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

    void Hover()
    {
        Vector3 _position = this.transform.position;
        float HoveringHeight = Mathf.Sin(Time.time);
        this.transform.position = new Vector3(_position.x, HoveringHeight + 2f, _position.z);
    }
}
