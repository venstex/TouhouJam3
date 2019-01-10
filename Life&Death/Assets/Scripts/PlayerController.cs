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
    private float LimitZ = 5f;

    [SerializeField]
    private float LimitX = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal")* rotationSpeed;
        float moveVertical = Input.GetAxis("Vertical") * movementSpeed;
        Debug.Log(moveHorizontal + " : " + moveVertical);

        this.transform.Translate(0, 0, moveVertical);
        this.transform.Rotate(0,moveHorizontal,0);

        if (Input.GetKeyDown("space"))
        {

        }



        if (this.transform.position.z > LimitZ)
        {
            this.transform.position = new Vector3(this.transform.position.x,this.transform.position.y,LimitZ);
        }

        if (this.transform.position.z > -LimitZ)
        {
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, LimitZ);
        }

        if (this.transform.position.z > LimitX)
        {
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, LimitX);
        }

        if (this.transform.position.z > -LimitX)
        {
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, LimitX);
        }

    }
}
