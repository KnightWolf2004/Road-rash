using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyCar : MonoBehaviour
{
    public float enemySpeed = 5f;

    //Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * enemySpeed * Time.deltaTime);
        if(transform.position.y < -11f)
        {
            Destroy(gameObject);
        }

    }

}
