using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingFloor : MonoBehaviour
{

    Material material;
    [SerializeField]
    private float speed = 5;
    float currentscroll;

    //float offset;
    //float scrollSpeed = 5;


    // Start is called before the first frame update
    void Start()
    {
        material = GetComponent<Renderer>().material;
    }

    void Update()
    {
        currentscroll += speed * Time.deltaTime;
        material.mainTextureOffset = new Vector2(currentscroll, 0);
    }
}