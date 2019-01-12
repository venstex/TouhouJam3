using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    private float rotationSpeed = 5;

    [SerializeField]
    private float movementSpeed = 0.2f;

    public GameObject LevelFloorForBounds;
    private float LimitZ;
    private float LimitX;

    // Start is called before the first frame update
    void Start()
    {
        //Vector2 FloorBounds = LevelFloorForBounds.GetComponent<FloorBasedBounds>().GetBounds();
        LimitX = GameController.HorizontalFloor;
        LimitZ = GameController.VerticalFloor;

    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();
        HandleBounds();
    }

    private void HandleInput()
    {
        float moveHorizontal = Input.GetAxis("Horizontal") * rotationSpeed;
        float moveVertical = Input.GetAxis("Vertical") * movementSpeed;

        this.transform.Translate(0, 0, moveVertical);
        this.transform.Rotate(0, moveHorizontal, 0);

        if (Input.GetKeyDown("space"))
        {

        }
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

    private void OnCollisionEnter(Collision collision)
    {
        GameObject other = collision.gameObject;

        if (other.tag == "Collect")
        {
            Destroy(other);
            GameController.Score += 1;
        }

        if (other.tag == "Enemy")
        {
            GameController.StopGame();
        }
    }
}
