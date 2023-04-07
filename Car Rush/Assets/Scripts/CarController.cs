using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;

public class CarController : MonoBehaviour
{
    public float carSpeed;
    Vector3 carPosition;
    public float maxLeft;
    public float maxRight;
    public float timer = 20f;
    public float tank=30f;
    public uiManager ui;
    public ParticleSystem explosionParticle;
    // Start is called before the first frame update
    void Start()
    {
        carPosition = transform.position;    
    }

    // Update is called once per frame
    void Update()
    {
        carPosition.x += Input.GetAxis("Horizontal") * carSpeed * Time.deltaTime;
        carPosition.x = Mathf.Clamp(carPosition.x, maxLeft, maxRight);
        transform.position = carPosition;

        timer = timer - Time.deltaTime;
        if(timer < 0)
        {
            Time.timeScale = Time.timeScale + 0.2f;
            timer = 20f;
            Time.timeScale = Mathf.Clamp(Time.timeScale, 0, 20);
        }

        tank = tank - Time.deltaTime;

        if(tank < 0)
        {
            Destroy(gameObject);
            ui.OnCollisionwith();
            Time.timeScale = 1;
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
            ui.OnCollisionwith();
            Time.timeScale = 1;
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
        }

        if(collision.gameObject.tag == "Fuel")
        {
            tank = 30f;
            Destroy(collision.gameObject);
          
        }
    }
}
