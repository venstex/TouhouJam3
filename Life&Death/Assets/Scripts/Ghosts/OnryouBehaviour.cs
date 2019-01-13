using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnryouBehaviour : MonoBehaviour
{

    
    //[Header("Field limits")]
    //[SerializeField]
    private float LimitZ;

    //[SerializeField]
    private float LimitX;
    


    public float speed = 0.001F;
    private GameObject Player;

    public Vector3 destination;

    bool isShiftKeyDown = false;
    bool isCtrlKeyDown = false;

    // Start is called before the first frame update
    void Start()
    {
        LimitX = GameController.HorizontalFloor;
        LimitZ = GameController.VerticalFloor;

        Player = GameObject.FindGameObjectWithTag("Player");

        InvokeRepeating("MoveToPlayer", 0f,2f/Time.time * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3.Angle(this.transform.position, Player.transform.position);
        Hover();

        isShiftKeyDown = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
        isCtrlKeyDown = Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl);
    }

    void MoveToPlayer()
    {

        float SpeedModifier = GameController.PlayTime / 5;

        if (isCtrlKeyDown)
        {
            this.transform.LookAt(2 * transform.position - Player.transform.position, Vector3.up);
        } else
        {
            this.transform.LookAt(Player.transform, Vector3.up);
        }

        //transform.Translate(new Vector3(0,0, 0.1f * Time.deltaTime));
        if (isShiftKeyDown || isCtrlKeyDown)
        {
            transform.Translate(new Vector3(0, 0, 0.1f * Time.deltaTime * 2 *SpeedModifier));
        } else
        {
            transform.Translate(new Vector3(0, 0, 0.1f * Time.deltaTime * SpeedModifier));
        }
        HandleBounds();
    }

    void Hover()
    {
        Vector3 _position = this.transform.position;
        float HoveringHeight = Mathf.Sin(Time.time);
        this.transform.position = new Vector3(_position.x, HoveringHeight + 2f, _position.z);
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
