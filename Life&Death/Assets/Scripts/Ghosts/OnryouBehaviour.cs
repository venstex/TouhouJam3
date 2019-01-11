using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnryouBehaviour : MonoBehaviour
{

    private GameObject Player;


    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");

        InvokeRepeating("MoveToPlayer",2f,2f);
    }

    // Update is called once per frame
    void Update()
    {
        //float dist = Vector3.Distance(this.transform.position, Player.transform.position);
        Vector3.Angle(this.transform.position, Player.transform.position);

        Hover();
    }


    void MoveToPlayer()
    {
        this.transform.LookAt(Player.transform, Vector3.up);
        this.transform.Translate(Vector3.forward);

    }

    void Hover()
    {
        Vector3 _position = this.transform.position;
        float HoveringHeight = Mathf.Sin(Time.time);
        this.transform.position = new Vector3(_position.x, HoveringHeight + 1f, _position.z);
    }
}
