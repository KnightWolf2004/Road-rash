 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
    public float scrollSpeed = 2f;
    Vector3 initPos;
    //public float timer = 20f;

    // Start is called before the first frame update
    private void Start()
    {
        initPos = transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > (initPos + new Vector3(0, -30, 0)).y)
            transform.position += Vector3.down * scrollSpeed * Time.deltaTime;
        else
            transform.position = initPos;

        /*timer = timer - Time.deltaTime;
        if(timer < 0f)
        {
            scrollSpeed = scrollSpeed + 0.5f;
            timer = 1f;
        }*/
    }
}
