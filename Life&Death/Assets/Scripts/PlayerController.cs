using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    private float rotationSpeed = 5;

    [SerializeField]
    private float MovementSpeed = 0.2f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal")* rotationSpeed;
        float moveVertical = Input.GetAxis("Vertical") * MovementSpeed;
        Debug.Log(moveHorizontal + " : " + moveVertical);

        this.transform.Translate(0, 0, moveVertical);
        this.transform.Rotate(0,moveHorizontal,0);

        if (Input.GetKeyDown("space"))
        {

        }
    }
}
