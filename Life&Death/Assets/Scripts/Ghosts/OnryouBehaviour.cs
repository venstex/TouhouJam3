using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnryouBehaviour : MonoBehaviour
{
    public float speed = 0.001F;
    private GameObject Player;

    public Vector3 destination;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");

        InvokeRepeating("MoveToPlayer", 0f,2f/GameController.PlayTime);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3.Angle(this.transform.position, Player.transform.position);

        Hover();

    }

    void MoveToPlayer()
    {
        this.transform.LookAt(Player.transform, Vector3.up);

        transform.Translate(new Vector3(0,0,0.1f));
    }

    void Hover()
    {
        Vector3 _position = this.transform.position;
        float HoveringHeight = Mathf.Sin(Time.time);
        this.transform.position = new Vector3(_position.x, HoveringHeight + 2f, _position.z);
    }
}
