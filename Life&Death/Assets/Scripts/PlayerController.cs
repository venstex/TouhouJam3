using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    private float rotationSpeed = 5;

    [SerializeField]
    private float movementSpeed = 0.2f;

    [SerializeField]
    private float bombRadius = 5f;

    [SerializeField]
    private int genkiToBomb = 10;

    private int genkiBombCounter = 0;
    private bool hasBomb = false;

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
        float moveHorizontal = Input.GetAxisRaw("Horizontal") * rotationSpeed;
        float moveVertical = Input.GetAxis("Vertical") * movementSpeed;

        this.transform.Translate(0, 0, moveVertical);
        this.transform.Rotate(0, moveHorizontal, 0);

        if (Input.GetKeyDown("space"))
        {
            if (hasBomb)
            {
                slashGhosts();
            }            
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

            if (genkiBombCounter<genkiToBomb)
            {
                genkiBombCounter++;
            }

            if (genkiBombCounter>= genkiToBomb)
            {
                hasBomb = true;
            }
        }

        if (other.tag == "Enemy")
        {
            GameController.StopGame();
            genkiBombCounter = 0;
            hasBomb = false;
        }

        print(genkiBombCounter+" "+ genkiToBomb + " " + hasBomb);

    }

    private void slashGhosts()
    {
        Collider[] hitColliders = Physics.OverlapSphere(this.transform.position, bombRadius);

        foreach (Collider ghost in hitColliders)
        {
            if (ghost.gameObject.tag=="Collect")
            {
                Destroy(ghost.gameObject);
                GameController.Score -= 1;
            }

            if (ghost.gameObject.tag == "Enemy")
            {
                Destroy(ghost.gameObject);
            }
        }
        genkiBombCounter = 0;
        hasBomb = false;
    }
}
