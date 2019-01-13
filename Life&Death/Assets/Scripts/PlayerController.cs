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

    private int genkiToBomb = 5;

    [Header("Sounds")]
    [SerializeField]
    private AudioClip collectGenki = null;

    [SerializeField]
    private AudioClip scythSwing = null;

    private int genkiBombCounter = 0;
    private bool hasBomb = false;

    private float LimitZ;
    private float LimitX;

    [SerializeField]
    Animator m_Animator;

    // Start is called before the first frame update
    void Start()
    {
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
            GetComponent<AudioSource>().clip = this.collectGenki;
            GetComponent<AudioSource>().Play();            

            Destroy(other);
            GameController.Score += 1;

            if (genkiBombCounter<genkiToBomb)
            {
                genkiBombCounter += 1;
                updateGenkiCounter(genkiBombCounter);
            }

            if (genkiBombCounter>= genkiToBomb)
            {
                hasBomb = true;
            }
        }

        if (other.tag == "Enemy")
        {
            GameController.StopGame();
            updateGenkiCounter(0);
            hasBomb = false;
        }

    }

    private void slashGhosts()
    {

        GetComponent<AudioSource>().clip = this.scythSwing;
        GetComponent<AudioSource>().Play();

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

        m_Animator.SetTrigger("Bomb");

        updateGenkiCounter(0);
        hasBomb = false;
    }

    private void updateGenkiCounter(int genkiCounter)
    {
        this.genkiBombCounter = genkiCounter;
        GameController.GenkiCharge = genkiCounter;

    }
}
